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
        
        
let drinkOne = { Type = Coffee; Size = small }
let drinkTwo = { Type = Juice; Size = large }
let price = computePrice drinkTwo