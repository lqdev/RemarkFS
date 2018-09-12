#load "./packages/FSharp.Formatting/FSharp.Formatting.fsx"
#r "./packages/HtmlAgilityPack/lib/netstandard2.0/HtmlAgilityPack.dll"
#r "./packages/Fue/lib/netstandard2.0/Fue.dll"

namespace Presentations
    open FSharp.Markdown

    type Presentation = {Title:string;Content:MarkdownDocument}

    module Operations = 
        
        open System.Text.RegularExpressions
        open System.IO
        open Fue.Data
        open Fue.Compiler

        let getTitle(line:MarkdownParagraph) = 
                match line with
                | Heading (1,heading) -> 
                    match heading with
                    | [Literal title] -> title
                    | _ -> "Title"
                | _ -> "No Heading"

        let getIndex (myString:string) = 
            match myString.Length with
            | x when x < 45 -> myString.Length
            | _ -> 45

        let getSlug(title:string) = 
            let lowercase = title.ToLower()
            let invalidChars = Regex.Replace(lowercase,@"[^a-z0-9\s-]", "")
            let removeMultipleSpaces = Regex.Replace(invalidChars,@"\s+", " ").Trim()
            let trimmed = removeMultipleSpaces.Substring(0, (getIndex removeMultipleSpaces)).Trim();
            let hyphenate = Regex.Replace(trimmed, @"\s", "-");
            hyphenate

        let toMarkdown content = 
            (content,Markdown.Parse content)

        let createPresentation (rawContent:string,content:MarkdownDocument) =     
            let title = 
                content.Paragraphs
                |> List.map(getTitle)
                |> List.filter(fun x -> (x <> "No Heading" && x <> "Title"))
                |> List.head

            let presentation = 
                { Title=title
                  Content=content }
                    
            (rawContent,presentation)

        let processFile = File.ReadAllText >> toMarkdown >> createPresentation  
        let writePresentation files = 
            files
            |> Array.map(fun file -> sprintf "%s" file)
            |> Array.map processFile
            |> List.ofArray
            |> List.map(fun (content,presentation) -> content,presentation.Title,presentation.Content)
            |> List.map(fun (rawContent,title,content) -> 
                let filename = sprintf "%s.html" (getSlug title)     
                let template = __SOURCE_DIRECTORY__ + "/templates/presentation.html"
                
                let compiledHTML = 
                    init
                    |> add "title" title
                    |> add "content" rawContent
                    |> fromFile template

                File.WriteAllText((sprintf "./public/%s" filename),compiledHTML,System.Text.Encoding.UTF8)
            )