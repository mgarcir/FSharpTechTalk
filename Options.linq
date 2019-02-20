<Query Kind="FSharpProgram" />

let (|>>) x f = Option.bind f x
let (||>) f x = Option.bind f x
let inc value = Some <| value + 1
let (++) x y = x ** y

let optionWithValue = Some(42)
let optionWithOutValue = None

optionWithValue |>> inc |>> inc |> Dump
inc ||> optionWithValue |> Dump

2.0 ** 2.0 |> Dump