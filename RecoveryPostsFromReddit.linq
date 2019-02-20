<Query Kind="FSharpProgram">
  <NuGetReference>FSharp.Data</NuGetReference>
</Query>

open FSharp.Data

type PostsFromReddit = JsonProvider<"https://www.reddit.com/.json">

let fsharpPosts = PostsFromReddit.Load("https://www.reddit.com/r/fsharp/.json")

let printRecords (records:PostsFromReddit.Child[]) = 

   let urls = records |> Array.map (fun record -> record.Data.Id, record.Data.Url) |> Array.toList
   let titles = records |> Array.map (fun record -> record.Data.Id, record.Data.Title) |> Array.toList
   let summaries = records |> Array.map (fun record -> record.Data.Id, record.Data.Name) |> Array.toList
   
   let postsParsed = records |> Array.map (fun record -> record.Data.Id, record.Data.Title, record.Data.Permalink, record.Data.Url) |> Array.toList
   
   postsParsed.Dump("Title")
  
printRecords (fsharpPosts.Data.Children)