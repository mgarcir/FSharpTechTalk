<Query Kind="FSharpProgram" />

type ISBN13(reference)= 

    let mutable ISBN13 = None
    
    let ctor isbn13 =
        let ifTrueThen x = function 
            | true -> Some x 
            | false -> None
        
        let (|NullOrEmpty|_|) = 
            String.IsNullOrEmpty 
            >> ifTrueThen NullOrEmpty
        
        let (|StringLength|_|) f s = 
            f (String.length s) 
            |> ifTrueThen StringLength
        
        let (|NotMatches|_|) pattern s = 
            Regex.IsMatch (pattern, s, RegexOptions.Compiled) 
            |> ifTrueThen NotMatches
        
        let flip f x y = f y x
        
        let (|CheckSum|_|) s =
            let multiplyEvenWith3 i x = if i % 2 <> 0 then x * 3 else x
            let substract10IfNotZero x = if x <> 0 then 10 - x else x
            let numbers = [ for c in s -> c |> string |> int ]
        
            numbers
            |> List.take 12
            |> List.mapi multiplyEvenWith3
            |> List.sum
            |> flip (%) 10
            |> substract10IfNotZero
            |> (<>) <| List.last numbers
            |> ifTrueThen CheckSum
    
        match isbn13 with
        | NullOrEmpty 
        | StringLength ((<>) 13)
        | NotMatches "[0-9]{13}" 
        | CheckSum -> failwith "Error"
        | s -> ISBN13 <- s |> Some
    
    do ctor(reference)
    
    member this.GetReference = ISBN13
    member this.Print = printfn "The reference for your book is: %s" ISBN13.Value

let myISBN13 = new ISBN13("9781566199094")
myISBN13.GetReference |> Dump
myISBN13.Print