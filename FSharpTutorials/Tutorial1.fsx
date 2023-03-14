let myOne:double = 1.0
let myTwo:double = 2.0


let add x y = x + y
//Lambda expression
let add' = fun x y -> x + y
let add'' x = fun y -> x + y



let add1 = add myOne myTwo
let add5 x =
    let five = 5
    x + five
let add3 = (+) 3
let times2 = (*) 2
let pow2 (number:int) : int = pown number 2
let pow2Alternative (number:int) : int = int (float number ** 2.0)

let operation number =
    pow2 (times2 (add3 number))
    
let operationRefactored number =
    let add = add3 number
    let times = times2 add
    pow2 times
    
//Pipe operator 
let operationRefactoredFunctional number =
    number
    |> add3
    //  is the same as: add3 number 
    |> times2
    |> pow2
//Composition operator 
let operationRefactoredFunctionalTwo =
    add3 >> times2 >> pow2 

