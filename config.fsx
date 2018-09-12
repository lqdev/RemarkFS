#r "./packages/FSharp.Data/lib/net45/FSharp.Data.dll"

module Config = 

    open FSharp.Data

    type Config = JsonProvider<"./app.config.json">

    let configFile = Config.Load("./app.config.json")

    let getSourceDirectory = 
        configFile.SourceDirectory

    let getDestionationDirectory = 
        configFile.DestinationDirectory