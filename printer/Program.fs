// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open FParsec
open Parser
open Printer
open System.IO

[<EntryPoint>]
let main argv = 

    let query = "select userid, firstname from users"
    let result = parser query

    let getParseResults parseResult  =
      match parseResult with
      | Success(result, _, _) -> getCSharpDeclaration result query
      | Failure(msg, _, _) -> "{ error parsing " + msg + "}"


    let csharprec = getParseResults result

    printfn "%s" csharprec

    File.WriteAllText("..\..\..\csharptest\users.cs", csharprec)

    ignore (System.Console.ReadLine())
    0 
