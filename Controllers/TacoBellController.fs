namespace FSharp_Web1.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open FSharp_Web1
open Microsoft.AspNetCore.Http

[<ApiController>]
[<Route("[controller]")>]
type TacoBellController (logger : ILogger<TacoBellController>) =
    inherit ControllerBase()
    let baseURL = "/tacobell/"

    [<HttpGet>]
    member _.Get() =
        let d = "%d"
        let age = 29
        let content = $"
            <div class=\"title\">
                <h1>Taco Bell</h1>
            </div>
            <div class=\"links\">
                <ul>
                    <li><a href=\"{baseURL}special\">Special</a></li>
                    <li><a href=\"{baseURL}items\">Items</a></li>
                </ul>
            </div>
        "
        ContentResult(Content = content, ContentType = "text/html")

    [<HttpGet("special")>]
    member _.GetSpecial() =
        let content = "<h1>Special Content</h1>
                       <p>This is a special route within the TacoBellController.</p>"
        ContentResult(Content = content, ContentType = "text/html")

    [<HttpGet("items")>]
    member _.GetItems() =
        let content = $""

        ContentResult(Content = content, ContentType = "text/html")