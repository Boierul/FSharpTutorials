//Sum Types

//Discriminated Unions

open System

type Suits =
    | Club
    | Diamond
    | Heart
    | Spade
    
type Ranks =
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack
    | Queen
    | King
    | Ace
    
//    Constructor of an object via Pattern Matching (EX@ |Rectangle -> constructor)
type Shape =
    | Rectangle of width: double * height: double
    | Triangle of bases: double * height: double
    | Circle of radius: double

Shape.Rectangle(10.0, 20.0)

module ShapeMK1 =
    let area shape =
        exn

//Conditionals, but use pattern matching
let yesOrNo bool =
    if bool then "Yes" else "No"
    
//Same conditional but with pattern matching
let yesOrNoAlternative bool =
    match bool with
    | true -> "Yes"
    | false -> "No"
    
let yesOrNoAlternative2  = function
    | true -> "Yes"
    | false -> "No"
    
let isOdd = function
        |x when x % 2 = 0 -> false
        |_ -> true

module ShapeMK2 =
    let area shape =
        match shape with
        | Rectangle (width, height) -> width * height
        | Triangle (bases, height) -> bases * height / 2.0
        | Circle radius -> System.Math.PI * radius * radius
        
let circleTest = Circle 10.0
let triangleTest = Triangle (10.0, 30.0)
ShapeMK2.area circleTest
ShapeMK2.area triangleTest
