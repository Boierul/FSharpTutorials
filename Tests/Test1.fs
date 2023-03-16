open System

// A record is a type that contains a fixed number of fields - Mutable Records
type MutableCar =
    { Make: string
      Model: string
      mutable Miles: int }

// Always put the mutable keyword before the type
let driveForASeason (car: MutableCar) =
    let rng = new Random()
    // You can mutate the fields of a mutable record
    car.Miles <- car.Miles + rng.Next() % 10000
    printfn "After a season of driving, the %s %s has %d miles on it." car.Make car.Model car.Miles

let tesla = { Make = "Tesla"; Model = "Model X"; Miles = 0 }
let bmw = { Make = "BMW"; Model = "i4"; Miles = 50000 }
driveForASeason tesla