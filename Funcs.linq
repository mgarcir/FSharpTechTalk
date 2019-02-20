<Query Kind="FSharpProgram" />

let log arg func = 
    printfn "Arg is %A." arg
    func(arg)

let inc = (+) 1
let duplicate = (*) 2
let compose = inc >> duplicate

1 |> inc |> Dump
1 |> duplicate |> Dump
1 |> compose |> Dump

log 1 compose |> Dump
log 2 duplicate |> Dump
log 3 inc |> Dump