// module Tests.Test2

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
    printfn"%d" i

for i= 5 downto 1 do
    printfn"%d" i
