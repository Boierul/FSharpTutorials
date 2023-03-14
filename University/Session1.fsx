module University.Session1

// Introduction to F# programming
// ==============================

// A function to add 2 to a number
let square x = x * x

// This function uses the square function 
// to build a more complex function
let sumSqr(x,y) = square x + square y

// This function concatenates 2 strng
let concate(i1:string, i2:string) = i1 + i2

// This function return the factorial of the number
let rec factorial (n:int) = if n = 0 then 1 else n * factorial (n-1)

printfn "%i" (sumSqr(4,5))
printfn "%s" (concate("pidar", "prost"))




// Session 1 - Exercise 1
let x = 23
let myName = "Dan"
let age = 25
let country = "Denmark"
let y = 6 + 6

let a = 5
let b = let a = 10 in a + 5
let c = a + b


// Session 1 - Exercise 2
let addNum1 = 2 + 1
let addNum10 num = num + 10
let addNum20 x = addNum10 (addNum10 x)
let consoleAddNum20 = addNum20(5)
printfn "The val of the function: %d" consoleAddNum20


// Session 1 - Exercise 3
let max2(x,y) = 
    if x > y 
    then x
    else y

let evenOrOdd x = 
    if x % 2 = 0 
    then printfn "even number"
    else printfn "odd number"

let addXY x y = 
    printfn "%d + %d = %d" x y (x + y)


// Session 1 - Exercise 4
let rec addNum(j,k) = 
    if k = 0 
    then j
    else addNum10(addNum (j,(k - 1)))