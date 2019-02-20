<Query Kind="FSharpProgram" />

let tupleOne = (1,"One")
let tupleTwo = (2, "Two")

tupleOne |> Dump
tupleTwo |> Dump

let intValue, stringValue = tupleOne

intValue |> Dump
stringValue |> Dump

let bigTuple = (1,2,3,4,5,6,7,8,9,0,"Big")
let bigTupleIntValue,_,_,_,_,_,_,_,_,_,bitTupleStringValue = bigTuple

bigTupleIntValue |> Dump
bitTupleStringValue |> Dump