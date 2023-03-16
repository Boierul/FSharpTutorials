// Pattern matching, discriminated union


// 1. Declare a typeIntegerTree representing a tree of integers and define a recursive
// function sumIntegerTree that sums all the values in the tree.Test your solution with a couple of inputs

// Define a type for a binary tree of integers
type IntegerTree =
    | Leaf of int
    | Node of IntegerTree * IntegerTree

// Define a function to sum the integers in a tree    
let rec sumIntegerTree tree =
    match tree with
    | Leaf x -> x
    | Node (left, right) -> sumIntegerTree left + sumIntegerTree right

// Example usage
let tree = Node(Node(Leaf(1), Node(Leaf(2), Leaf(3))), Node(Leaf(4), Leaf(5)))
let sum = sumIntegerTree tree // Output: 15

// 2. We can use tuples as well as records to return a pair of numbers.
// For instance, we can count and return the number of words and letters
// in a given string in a tuple as follows:

let countWordnLetter (str:string) =
    let wordCount = str.Split [|' '|]
    let letterCount = wordCount |> Array.sumBy (fun w -> w.Length)
    (wordCount.Length, letterCount) // test it
countWordnLetter "be happy everything is gonna be okay"

// Convert countWordnLetter function above to use records instead of tuples.
type WordCount = {
    WordCount : int
    LetterCount : int
}

let countWordnLetterMK2 (str:string) =
    let wordCount = str.Split [|' '|]
    let letterCount = wordCount |> Array.sumBy (fun w -> w.Length)
    { WordCount = wordCount.Length; LetterCount = letterCount }
countWordnLetterMK2 "be happy everything is gonna be okay"

