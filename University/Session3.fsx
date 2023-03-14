// Session 3 - Exercise 1

let countNumOfVowels (inputStr : string) : int * int * int * int * int =
    // let vowels = "aeiouAEIOU"
    inputStr
    |> Seq.fold (fun (a, e, i, o, u) character ->
        match character with
        | 'a' | 'A' -> (a + 1, e, i, o, u)
        | 'e' | 'E' -> (a, e + 1, i, o, u)
        | 'i' | 'I' -> (a, e, i + 1, o, u)
        | 'o' | 'O' -> (a, e, i, o + 1, u)
        | 'u' | 'U' -> (a, e, i, o, u + 1)
        | _ -> (a, e, i, o, u)) (0, 0, 0, 0, 0)

let a, e, i, o, u as theVowels = countNumOfVowels "Higher-order functions can take and return functions of any order"

let vowelsSum =
          match theVowels with
          | (a, b, c, d, e) -> a + b + c + d + e

printfn $"There are %d{vowelsSum} vowels in the provided text,
        and they are: (a=%d{a}, e=%d{e}, i=%d{i}, o=%d{o}, u=%d{u})"
// printfn "(a=%d, e=%d, i=%d, o=%d, u=%d)" a e i o u
// printfn $"%A{theVowels}" // prints (5, 4, 2, 2, 1)


// Session 3 - Exercise 2

// Check if a number is not divisible by any integer between 2 and its square root
// let isPrime argNumber =
let isPrime n =
    match n with
    | 1 -> false
    | 2 -> true
    | _ ->
        let upperBound = sqrt(double(n)) |> int
        List.exists (fun x -> n % x = 0) [2..upperBound] |> not

let primesUpTo n =
    [2..n]
    |> List.filter isPrime
    
primesUpTo 10

// Session 3 - Exercise 3

let rec pclFib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> pclFib (n-1) + pclFib (n-2)
    
let fibonacciResult = pclFib 10
printfn $"The 10th Fibonacci number is %d{fibonacciResult}"



// Session 3 - Exercise 4

// a.
let doubleNum x = 2 * x
let sqrNum x = x * x

// b.
let pclQuad x = doubleNum >> doubleNum

// c.
let pclFourth x = sqrNum >> sqrNum





