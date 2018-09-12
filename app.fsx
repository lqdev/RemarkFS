#load "./presentations.fsx"
#load "./config.fsx"

open System.IO
open Presentations.Operations
open Config

let sourcePath = Path.Combine(__SOURCE_DIRECTORY__ + Config.getSourceDirectory)
let files = Directory.GetFiles(sourcePath)    

writePresentation files