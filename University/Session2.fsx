module University.Session2_fsx

let classId = "IT-PLC1-S23"
classId.Length;;
classId.[7];;

let rec factorialPM n = 
    match n with
    | 0 -> 1
    | _ -> n * factorialPM (n-1)


//  Construction of tuples
let student1 = (279487, "Dan")

// Triple tuple
let student2 = (279488, "Huipaimi", "IOT")

//  Deconstruction - using fst, snd or pattern
let studentId = fst student1
let studentName = snd student1

let (x',y') = student1

let vecAdd (x1, y1) (x2, y2) =
    (x1 + x2, y1 + y2) 

1::2::3::[];;
let n1 = [1..12];;
let nstep = [0..10 .. 50];;

//  Fibonacci sequence - recursive
let rec fib n =
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> fib (n-1) + fib (n-2)

let x = 
    [ let negate x = -x
      for i in 1 .. 10 do
        if i % 2 = 0 then
            yield negate i
        else
            yield i]
    
let multipleOf x = [for i in 1 .. 10 do yield x*1]
let multipleOf2 x = [for i in 1 .. 10 -> x*i]

// Session 2 - Exercise 1

// This function takes a function `argFunction`, an initial accumulator value `accumulator`, and a list `list`.

// It applies the function `argFunction` to the first element of the list and the accumulator value,
// then recursively calls itself with the updated accumulator and the rest of the list until the list is empty.
let rec pclFold argFunction accumulator arrList =
    match arrList with
    | [] -> accumulator
    | headElement :: tailElement -> pclFold argFunction (argFunction accumulator headElement) tailElement

// This function takes a list `lst` and returns the sum of all elements in the list.
let pclSumWithFold lst = pclFold (+) 0 lst
let lst = [ 1; 2; 3 ]
pclSumWithFold lst


// Session 2 - Exercise 2

let rec pclFoldBack argFunction accumulator argList =
    match argList with
    | [] -> accumulator
    | headElement :: tailElement -> argFunction headElement (pclFoldBack argFunction accumulator tailElement)

let pclSumWithFoldBack lst = pclFoldBack (+) 0 lst
let demoList = [ 1; 2; 3; 4; 5 ]
pclSumWithFoldBack demoList

// The main difference between pclFold and pclFoldBack is the direction in which they fold the list.
// pclFold folds the list from left to right, while pclFoldBack folds the list from right to left.
// For most operations, the direction of folding doesn't matter, and the results will be the same whether
// you use pclFold or pclFoldBack. However, for some operations like division and subtraction,
// the order of the operands matters, so the result of folding the list from left to right may be different
// from folding the list from right to left.


// Session 2 - Exercise 3

let rec pclIncList lst =
    match lst with
    | [] -> []
    | headElement::tailElement -> (headElement + 1) :: pclIncList tailElement

pclIncList [2; 3; 1; 4] // returns [3; 4; 2; 5]


// Session 2 - Exercise 4

let rec pclMap argFunc argList =
    match argList with
    | [] -> []
    | headElement :: tailElement -> argFunc headElement :: pclMap argFunc tailElement

let pclIncListWithMap argList = pclMap (fun x -> x + 1) argList
pclIncListWithMap [2; 3; 1; 4] // returns [3; 4; 2; 5]


// Session 2 - Exercise 5

let rec pclFilter predicate argList =
    match argList with
    | [] -> []
    | x :: xs' -> if predicate x
                    then x :: pclFilter predicate xs'
                    else pclFilter predicate xs'

// The pclFilter function takes two arguments: a predicate function `predicate` and a list `argList`.
// The function recursively filters out elements from `argList` that do not satisfy the predicate
// and returns a new list containing the remaining elements.

let pclEven x = x % 2 = 0

let testList = [0; 1; 2; 3; 4; 5; 6; 7; 8; 9]
let result = pclFilter pclEven testList
printfn $"%A{result}" // prints [0; 2; 4; 6; 8]

