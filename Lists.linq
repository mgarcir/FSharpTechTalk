<Query Kind="FSharpProgram" />

[] |> Dump
[1;2;3;4;] |> Dump
1::2::3::4::[] |> Dump

let myList = [1..100]
let abc = ['a'..'z']

let head::tail = myList
head |> Dump
tail |> Dump

myList
    |> List.filter ((>) 50) 
    |> List.fold (fun acc next -> acc + next) 0 
    |> Dump
    
myList
    |> List.filter ((>) 50) 
    |> List.sum
    |> Dump
    
myList
    |> List.filter ((>) 10) 
    |> List.iter (fun item -> printfn "The value is: %d" item) 

let toUpper x = x.ToString().ToUpper()

abc
    |> List.map (fun x -> x.ToString().ToUpper())
    |> Dump
    |> ignore
    
abc
    |> List.map toUpper
    |> Dump
    |> ignore