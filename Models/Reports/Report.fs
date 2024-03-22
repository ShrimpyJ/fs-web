namespace FSharp_Web1

open System

type FileContent = 
    | Text of string
    | Image of byte[]

type Report = {
    Title: string
    CreationDate: DateTime
    Content: FileContent
}

type FaxDelivery = {
    To: string
    Content: FileContent
}

type EmailDelivery = {
    To: string
    Subject: string
    Body: string
}

type SMSDelivery = {
    To: string
    Message: string
}

type Delivery = 
    | Fax of FaxDelivery
    | Email of EmailDelivery
    | SMS of SMSDelivery

type ReportService =
    member this.SendReport(report: Report, delivery: Delivery) =
        printf "Sending Report %s..." report.Title

        match delivery with
        | Fax f ->
            let str = $"Faxing {f.To}..."
            match f.Content with
            | Text t -> str + "\n\nCONTENTS:\n\n" + t
            | Image _ -> str
        | Email e -> $"To: {e.To}, Subject: {e.Subject}"
        | SMS s -> $"SMS sent to {s.To}"