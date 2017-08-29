module Parser4

open FParsec
    // AST
    type statement = Select of string list


let parser4 = 
    let identifier = manyMinMaxSatisfy2L 1 128 isLetter isLetter "identifier"

    let pSpaces = anyOf " \t\r\n"

    let ws1 = skipMany1 pSpaces

    let ws = skipMany pSpaces

    let pSelectKeyword = pstring "select" .>> ws1

    // list of columns
    let pColumns = sepBy identifier (pstring "," .>> ws)

    let pSelect = pSelectKeyword >>. pColumns |>> (fun columns -> Select columns)

    run pSelect "select userid, firstname"
