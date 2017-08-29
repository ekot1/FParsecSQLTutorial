module Parser5

open FParsec
    // AST
    type statement = Select of (string list * string)
    
let parser5 = 
    let identifier = manyMinMaxSatisfy2L 1 128 isLetter isLetter "identifier"

    let pSpaces = anyOf " \t\r\n"

    let ws1 = skipMany1 pSpaces

    let ws = skipMany pSpaces

    let pSelectKeyword = pstring "select" .>> ws1

    let pColumns = sepBy identifier (pstring "," .>> ws)

    // table name
    let pTable = pstring "from" .>> ws1 >>. identifier

    let pSelectWithColumns = pSelectKeyword >>. pColumns .>> ws1
    
    let pSelect = pipe2 pSelectWithColumns pTable (fun columns table -> Select (columns, table))

    run pSelect "select userid, firstname from users"
