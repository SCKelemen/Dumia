﻿namespace Dumia.Http.Controllers

open System.Web.Http
open Dumia.Domain
open System.Collections.Generic

[<RoutePrefix("api/product")>]
type ProductController() = 
    inherit ApiController()
    [<HttpGet; Route("")>]
    member this.Get() = this.Ok([| 1; 2; 3; 4 |])

[<RoutePrefix("api/inventory")>]
type InventoryController(getProducts : unit -> Result<Inventory [], string>) = 
    inherit ApiController()

    [<HttpGet; Route("")>]
    member this.Get() : IHttpActionResult = 
        match getProducts() with
        | Success products -> this.Ok(products) :> _
        | Failure msg -> this.BadRequest(msg) :> _
