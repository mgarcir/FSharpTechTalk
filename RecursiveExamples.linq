<Query Kind="FSharpProgram" />

let rec recursiveSum list = 
        match list with
        | [] -> 0
        | head::tail ->
           head + (recursiveSum tail)

let recursiveSumWithTailCall list =
    let rec sum remainders acc =
        match remainders with
        | [] -> acc
        | head::tail ->
            sum tail (acc + head)
    
    sum list 0
    
recursiveSum [1;2;3;4;5;] |> Dump
recursiveSum [1..10000] |> Dump
recursiveSumWithTailCall myList |> Dump