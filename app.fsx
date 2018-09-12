#load "./presentations.fsx"

open System.IO
open Presentations.Operations

let sourcePath = Path.Combine(__SOURCE_DIRECTORY__ + "/src")
let files = Directory.GetFiles(sourcePath)    

writePresentation files