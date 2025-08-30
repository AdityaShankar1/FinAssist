#r "nuget: FSharp.Data, 6.3.0"

open System
open System.IO
open FSharp.Data

// Input/output files
let inputFile  = "Finance_data.csv"
let outputFile = "cleaned_data.csv"

// Load CSV using FSharp.Data
type RawData = CsvProvider<"Finance_data.csv">
let raw = RawData.Load(inputFile) 

// Example cleaning steps:
// 1. Keep only specific columns (Gender, Age, Investment_Avenues, Mutual_Funds ...)
// 2. Remove rows with missing values
// 3. Normalize column names if needed

let cleanedRows =
    raw.Rows
    |> Seq.filter (fun r -> not (String.IsNullOrWhiteSpace r.Gender))
    |> Seq.map (fun r -> 
        sprintf "%s,%d,%s,%d,%d,%d,%d,%d,%d,%s,%s,%s,%s,%s,%s,%s"
            r.Gender
            r.Age
            r.Investment_Avenues
            r.Mutual_Funds
           // r.Equity_Market
            r.Government_Bonds
            r.Fixed_Deposits
            r.PPF
            r.Gold
            r.Stock_Marktet
            r.Expect
            r.Avenue
            r.Reason_Equity
            r.Reason_Mutual
            r.Reason_Bonds
            r.Reason_FD
            // r.Source is optional — include if you want
    )

// Write header + rows to output CSV
let header = "Gender,Age,Investment_Avenues,Mutual_Funds,Equity_Market,Government_Bonds,Fixed_Deposits,PPF,Gold,Stock_Marktet,Expect,Avenue,Reason_Equity,Reason_Mutual,Reason_Bonds,Reason_FD"
File.WriteAllLines(outputFile, Seq.append [header] cleanedRows)

printfn "Data cleaned and saved to %s" outputFile