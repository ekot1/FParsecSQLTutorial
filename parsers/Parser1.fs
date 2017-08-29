module Parser1

open FParsec
    // AST
    type statement = Select


let parser1 = 
    let pSelect = stringReturn "select" Select

    run pSelect "select"

