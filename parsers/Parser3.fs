module Parser3

open FParsec
    // AST
    type statement = Select of string


let parser3 = 
    let identifier = manyMinMaxSatisfy2L 1 128 isLetter isLetter "identifier"

    let pSpaces = anyOf " \t\r\n"

    let ws1 = skipMany1 pSpaces

    let pSelectKeyword = pstring "select" .>> ws1

    let pSelect = pSelectKeyword >>. identifier |>> (fun s -> Select s)

    // running parser
    let result = run pSelect "select firstname"
    result
