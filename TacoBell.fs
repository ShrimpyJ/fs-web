namespace FSharp_Web1

open System

type Item = {
    ItemName: string
    Price: decimal
}

type Order = {
    Items: Item list
    TotalPrice: decimal
}

type TacoBell =
    member this.NewOrder(itemNames: string list) =
        let pricePerItem = 5.00M

        let items = itemNames |> List.map (fun name -> { ItemName = name; Price = pricePerItem; })

        let totalPrice = items |> List.sumBy (fun item -> item.Price)

        { Items = items; TotalPrice = totalPrice }