//  Option data -> Discriminated union that represents optional data

type Option<'a> =
    | Some of 'a
    | None
    
//  Biggest pro -> No more null pointer exceptions


//  Fixed size. Mutable data.
let arr = [|1..10|]
//  Reassigning the value at index 0 to 5
arr.[0] <- 5

//  Dynamic size. Immutable data.
let list = [1..10]
['a' .. 'z'] //  List of characters
