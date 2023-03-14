//  Pattern matching with let and fun

type OrderId = OrderId of int

let incrementOrderId (OrderId id) =
    id + 1
    |> OrderId
    
let incrementOrderIdAlt = function
    | OrderId id -> OrderId (id + 1)
    
let incrementOrderIdAltTwo =
    fun (OrderId id) -> OrderId (id + 1)
    
incrementOrderId (OrderId 418) 
incrementOrderId (OrderId 419) 