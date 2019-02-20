<Query Kind="FSharpProgram" />

type Union = 
| Tuple   of string * int
| Text of string 
| Number of int

let (|IsABigTuple|_|) x =
    match x with
    | Tuple(text,number) when (number > 10) -> Some (text, number)
    | _ -> None
    
let printUnion (theUnion:Union) =
    match theUnion with
    |IsABigTuple(text, number) -> printfn "Is a big tuple: %s and %d." text number
    |Tuple(text,number) -> printfn "Is a tuple: %s and %d." text number
    |Text text -> printfn "Only a string: %s." text
    |Number number -> printfn "A number: %d." number
    
let aTuple = Tuple("One",1)
let aBigTuple = Tuple("One",100)
let aText = Text("My Text")
let aNumber = Number(25)

aTuple |> Dump
aText |> Dump
aNumber |> Dump
aBigTuple |> Dump

aTuple |> printUnion
aText |> printUnion
aNumber |> printUnion
aBigTuple |> printUnion

//let aSimpleTuple = ("One",1)
//printUnion |> printUnion