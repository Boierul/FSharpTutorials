// InClass exercises & assignments

// Function to calculate the sum of a list of integers
let rec sumList lst =
    match lst with
    | [] -> 0
    | hd :: tl -> hd + sumList tl

sumList [ 1..100 ]
printfn $"Sum in the list is: %d{sumList [ 1..10 ]}"


// Recursive function to calculate the factorial of a number with tail recursion
let accFactorial x =
    if x < 0 then
        failwith "Non-natural number arg"
    // Keep track of both x and acc value
    let rec tailRecursiveFactorial x acc =
        if x <= 1 then
            acc
        else
            tailRecursiveFactorial (x - 1) (acc * x)

    tailRecursiveFactorial x 1

accFactorial 5

// Recursive function to calculate the sum of a number with tail recursion
let sumListTR2 ls =
    let rec sumListTailRecursionHelper (ls, total) =
        match ls with
        | [] -> ls
        | hd :: tl ->
            let ntotal = (hd + total)
            sumListTailRecursionHelper (tl, ntotal)

    sumListTailRecursionHelper (ls, 0)

let list = [ 1..5 ]
sumListTR2 list

let sumListTailRecursion x =
    let rec sumListTailRecursionHelper x acc =
        if x <= 1 then
            acc
        else
            sumListTailRecursionHelper (x - 1) (acc + x)

    sumListTailRecursionHelper x 1


// Print a list in reverse order -- continuation
let printListReverse ls =
    let rec printListRevTR ls cont =
        match ls with
        // For empty list, execute the continuation
        | [] -> cont ()
        // For other lists, print the current node as a part of cont (continuation)
        | hd :: tl ->
            printListRevTR tl (fun () ->
                printf $"%A{hd}"
                cont ())

    printListRevTR ls (fun () -> printfn "Done!")

printListReverse [ 'A'; 'C'; 'T'; 'G' ] // G T C A Done



// Define a sequence of all positive 32-bit integers
let allPositiveIntsSeq =
    seq {
        for i in 1 .. System.Int32.MaxValue do
            yield i
    }

allPositiveIntsSeq |> Seq.take 3


let allPositivesList =
    [ for i in 1 .. System.Int32.MaxValue do
          yield i ]


let comingEvents =
    [ ("Plamesondag", "April 2nd");
      ("Sondergarden", "April 5th");
      ("Vejle", "April 10th") ]
    |> Map.ofList
    
comingEvents.["Vejle"]