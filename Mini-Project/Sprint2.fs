// Define a type Drink with three values: Coffee, Tea, and Juice
type DrinkType  =
    | Coffee
    | Tea
    | Juice

// Define a type Size with three values: Small, Medium, and Large
type DrinkSize = { Name: string; Price: decimal }

// Define a type Drink with two fields: DrinkType and DrinkSize
type Drink =
    { Type: DrinkType
      Size: DrinkSize }
    
// Define a function that takes defines the drink size and the price of the drink
let small = { Name = "Small"; Price = 1.99m }
let medium = { Name = "Medium"; Price = 2.99m }
let large = { Name = "Large"; Price = 3.99m }


// Define a list of coffee drinks
let coffee = [
    { Type = Coffee; Size = small }
    { Type = Coffee; Size = medium }
    { Type = Coffee; Size = large }
]

// Define a list of tea drinks
let tea = [
    { Type = Tea; Size = small }
    { Type = Tea; Size = medium }
    { Type = Tea; Size = large }
]

// Define a list of juice drinks
let juice = [
    { Type = Juice; Size = small }
    { Type = Juice; Size = medium }
    { Type = Juice; Size = large }
]

// Function to compute the price of a drink
let computePrice (drink: Drink) =
    match drink.Type with
    | Coffee -> 
        match drink.Size.Name with
        | "Small" -> drink.Size.Price + 0.5m
        | "Medium" -> drink.Size.Price
        | "Large" -> drink.Size.Price + 1.0m
        | _ -> failwith "Invalid size"
    | Tea ->
        match drink.Size.Name with
        | "Small" -> drink.Size.Price + 0.25m
        | "Medium" -> drink.Size.Price
        | "Large" -> drink.Size.Price + 0.5m
        | _ -> failwith "Invalid size"
    | Juice ->
        match drink.Size.Name with
        | "Small" -> drink.Size.Price
        | "Medium" -> drink.Size.Price + 0.25m
        | "Large" -> drink.Size.Price + 0.5m
        | _ -> failwith "Invalid size"
        
        
let drinkOne = { Type = Juice; Size = small }
let drinkTwo = { Type = Juice; Size = large }
let priceTEST = computePrice drinkOne
let priceTEST2 = computePrice drinkTwo



// ------------------------------------------------------------ //

// Define a type to represent the messages that can be sent to the agent
type OrderDrinkMsg =
    | OrderDrink of Drink * int  // Drink and quantity
    | LeaveAComment of string    // Comment text


// Define a function to compute the VAT-inclusive price given a VAT rate and a VAT-free price
let gtgVAT (n: int) (x: decimal) =
    let vatRate = decimal n / 100.0m
    x * (1.0m + vatRate)

// Define an agent to process the OrderDrinkMsg and LeaveAComment messages
let gtgAgent = MailboxProcessor.Start(fun inbox ->
    let rec loop() =
        async {
            let! msg = inbox.Receive()
            match msg with
            | OrderDrink(drink, qty) ->
                let price =
                        gtgVAT 25 (drink.Size.Price * decimal qty)
                printfn "Please pay DKK %.2f for your %d %s %s drinks. Thanks!" price qty (drink.Size.Name) (match drink.Type with Coffee -> "coffee" | Tea -> "tea" | Juice -> "juice")
            | LeaveAComment(comment) ->
                printfn "Thank you for your comment: %s" comment
            return! loop()
        }
    loop()
)

// Define a function to send an OrderDrinkMsg to the gtgAgent
let orderDrink (drink: Drink) (qty: int) =
    gtgAgent.Post(OrderDrink(drink, qty))

// Define a function to send a LeaveAComment message to the gtgAgent
let leaveComment (comment: string) =
    gtgAgent.Post(LeaveAComment(comment))

// TESTING: Order two small lattes and leave a comment
orderDrink { Type = Tea; Size = medium } 2
leaveComment "Comment-super!"

