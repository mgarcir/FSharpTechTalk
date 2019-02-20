<Query Kind="FSharpProgram">
  <NuGetReference>Argu</NuGetReference>
  <NuGetReference>FSharp.Charting</NuGetReference>
  <NuGetReference>FSharp.Data</NuGetReference>
  <NuGetReference>XPlot.GoogleCharts</NuGetReference>
  <NuGetReference>XPlot.Plotly</NuGetReference>
</Query>

open FSharp.Data

open XPlot.GoogleCharts

let worldDataBank = WorldBankData.GetDataContext()

let gdp = worldDataBank
            .Countries.``Spain``
            .Indicators.``Gross capital formation (% of GDP)``
gdp
    |> Dump
    |> Chart.Line
    |> Chart.Show