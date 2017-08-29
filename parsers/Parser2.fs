module Parser2

open FParsec
    // AST
    type statement = Select


let parser2 = 
    let pSpaces = anyOf " \t\r\n"

    let ws1 = skipMany1 pSpaces

    let pSelectKeyword = pstring "select" .>> ws1

    let pSelect = pSelectKeyword |>> (fun s -> Select)

    run pSelect "select"
