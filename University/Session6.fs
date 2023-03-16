// module University.Session6
open System
open System.Threading

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

let tesla =
    { Make = "Tesla"
      Model = "Model X"
      Miles = 0 }

let bmw =
    { Make = "BMW"
      Model = "i4"
      Miles = 50000 }

driveForASeason tesla

// --------------------------------------------------------------------------------------------- //

// Units of Measure - allow you to pass along unit information with a floating-point value
[<Measure>]
type fahrenheit

let printTemperature (temp: float<fahrenheit>) =
    if temp < 32.0<_> then printfn "Below Freezing!"
    elif temp < 65.0<_> then printfn "Cold"
    elif temp < 75.0<_> then printfn "Just right!"
    elif temp < 100.0<_> then printfn "Hot!"
    else printfn "Scorching!"

let horsens = 78.0<fahrenheit>
printTemperature horsens

// Calling the function with an invalid unit of measure will result in a compile-time error ▪.
[<Measure>]
type celsius

let viborg = 12.0<celsius>

// This code uses array comprehension to generate an array of perfect squares of the numbers from 1 to 7 (inclusive).
let perfectSquares = [| for i in 1..7 -> i * i |]
let a = [| 1; 3; 5 |]
a.[1] <- 7 + a.[1]


// While Loops
let mutable i = 0

while i < 10 do
    i <- i + 1
    printfn "i = %d" i

// For Loops
for i = 1 to 5 do
    printfn "%d" i

for i = 5 downto 1 do
    printfn "%d" i

// --------------------------------------------------------------------------------------------- //

// For Loops with Pattern Matching
type Pet =
    | Cat of string * int // Name, Lives
    | Dog of string // Name

let famousPets = [ Dog("Lassie"); Cat("Felix", 9); Dog("Rin Tin Tin") ]

for Dog (name) in famousPets do
    printfn "%s was a famous dog." name

// --------------------------------------------------------------------------------------------- //

// What will execute on each thread
let threadBody() =
    for i in 1 .. 5 do
     Thread.Sleep(100) // Wait 1/10 of a second
     printfn"[Thread %d] %d..."
        Thread.CurrentThread.ManagedThreadId
        i
    
let spawnThread() =
   let thread = new Thread(threadBody)
   thread.Start()

// --------------------------------------------------------------------------------------------- //

// 
let isPrimeNumber x =
    let mutable i = 2
    let mutable isFactorFound= false
    while not isFactorFound && i < x do
        if x % i = 0 then
            isFactorFound<-true
        i <-i + 1
    not isFactorFound
    
let intArray = [| for i in 10000000..10004000 -> i |]
resetstop()
let primeDetails1 =
    intArray
        |> Array.map (fun x -> (x, isPrimeNumber x))
ShowTime()