module Program
open FParsec
open Parser1
open Parser2
open Parser3
open Parser4
open Parser5

[<EntryPoint>]
let main argv = 

    let result = parser5

    // printing result
    match result with
    | Success (v, _, _) ->
          printf "Syntax tree: %A" v
    | Failure (msg, err, _) ->
          printfn "%s" msg

    ignore (System.Console.ReadLine())
    0