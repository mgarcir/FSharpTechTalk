<Query Kind="FSharpProgram">
  <NuGetReference>FSharp.Data</NuGetReference>
  <NuGetReference>XPlot.GoogleCharts</NuGetReference>
  <NuGetReference>XPlot.Plotly</NuGetReference>
</Query>

type Mail = string
type Telephone = int
type Address = Email of Mail | TelephoneNumber of Telephone
type Status = New | Processed | Signed | Failed | Closed

type EviMail = {
                id: int
                address: Mail
                hash: string
            } 
            
type EviSms = {
                id: int
                address: Telephone
                hash: string
            }
            
type EviSign = {
                uniqueId: Guid
                address: Address
                hash: string
                status: Status
                version: Option<int>                
            }
           
type Evidence =
    | EviMail of EviMail
    | EviSms of EviSms
    | EviSign of EviSign
    
let printEvidenceInfo evidence =
    let printEviSignWithVersion (eviSign:EviSign) = 
        printfn "EviSign -> UniqueId: %A. Address: %A. Hash: %s. Version: %i" (eviSign.uniqueId) (eviSign.address) (eviSign.hash) (eviSign.version.Value)
    let printEviSignWithOutVersion (eviSign:EviSign) = 
        printfn "EviSign -> UniqueId: %A. Address: %A. Hash: %s." (eviSign.uniqueId) (eviSign.address) (eviSign.hash)
    let printEviMail (eviMail:EviMail) = 
        printfn "EviMail ->Id: %A. Address: %A. Hash: %s." (eviMail.id) (eviMail.address) (eviMail.hash)
        
    match evidence with 
    | EviSign eviSign when (eviSign.version.IsSome) -> 
                    eviSign |> printEviSignWithVersion
    | EviSign eviSign -> 
                    eviSign |> printEviSignWithOutVersion
    | EviMail eviMail ->
                    eviMail |> printEviMail
    | _ -> failwith "Invalid Evidence type!?" //printfn "Invalid Evidence type!?"
    
let myEvisignWithEmailAddress = EviSign({uniqueId = Guid.NewGuid(); address = Email("myMail"); hash = "abcde1234560"; version = None; status = Status.Processed })
let myEvisignWithTelephoneAddress = EviSign({uniqueId = Guid.NewGuid(); address = TelephoneNumber(123456789); hash = "abcde1234561"; version = Some(1); status = Status.Signed })

let myEviMail = EviMail({id= 1; address= "myMail"; hash = "abcde1234562"})

//let myWrongEviSms = EviMail({id= 1; address= "myMail"; hash = "abcde1234562"})
//let myWrongEviMail = EviMail({id= 1; address= 1234567; hash = "abcde1234562"})

let myEviSms = EviSms({id= 1; address= 1234567; hash = "abcde1234563"})

[myEvisignWithEmailAddress; myEvisignWithTelephoneAddress; myEviMail; myEviSms]
    |> List.iter (fun evidence -> printEvidenceInfo evidence)