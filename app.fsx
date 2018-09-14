#r "./packages/Fake/tools/FakeLib.dll"
open Fake.Boot
#load "./presentations.fsx"
#load "./config.fsx"

open Presentations.Operations
open Config
open Fake
open Fake.IO
open System.IO

let sourcePath = Path.Combine(__SOURCE_DIRECTORY__,Config.getSourceDirectory);
let buildPath = Path.Combine(__SOURCE_DIRECTORY__,Config.getDestionationDirectory)

Target "Clean" (fun _ -> 
    Shell.CleanDir buildPath
)

Target "Build" (fun _ -> 
    trace "Building Presentations"
    let files = Directory.GetFiles(sourcePath)    
    writePresentation files
    trace "Presentations Built"
)

Target "Default" (fun _ -> 
    trace (sprintf "Source directory cleaned %s" sourcePath)
)

"Clean"
    ==> "Build"
    ==> "Default"

RunTargetOrDefault "Default"