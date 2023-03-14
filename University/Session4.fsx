// a -> define a type PclShape, which can be any geometric shape
type PclShape =
    | Rectangle of float * float
    | RightTriangle of float * float


// b -> instantiate two shapes
let rect1 = Rectangle(5.0, 10.0)
let tri1 = RightTriangle(3.0, 4.0)

// c -> implement a function pclArea, which calculates the area of a shape
let pclArea (shape: PclShape) =
    match shape with
    | Rectangle (a, b) -> a * b
    | RightTriangle (a, b) -> 0.5 * a * b

// d -> implement a function pclPerimeter, which calculates the perimeter of a shape
let pclPerimeter (shape: PclShape) =
    match shape with
    | Rectangle (a, b) -> 2.0 * (a + b)
    | RightTriangle (a, b) -> a + b + sqrt(a*a + b*b)

// e -> Redefine the PclShape to use records instead of tuples (PclShapeR).

// Deprecated in favor of the new record syntax.
// type PclShapeR =
//     | RectangleR of { width: float; height: float }
//     | RightTriangleR of { base: float; height: float }

type RectangleR = { width: float; height: float }
type RightTriangleR = { t_base: float; height: float }

type PclShapeR =
    | Rectangle of RectangleR
    | RightTriangle of RightTriangleR
 
 // We can create values using this new data type declaration in the same way as before.
 // The only difference is that we have to use record syntax to create the values:   
let rect2 = Rectangle { width = 5.0; height = 10.0 }
let tri2 = RightTriangle { t_base = 3.0; height = 4.0 }

// The functions pclArea and pclPerimeter will also need to be updated to use the record syntax
let pclAreaR (shape: PclShapeR) =
    match shape with
    | Rectangle { width = w; height = h } -> w * h
    | RightTriangle { t_base = b; height = h } -> 0.5 * b * h

let pclPerimeterR (shape: PclShapeR) =
    match shape with
    | Rectangle { width = w; height = h } -> 2.0 * (w + h)
    | RightTriangle { t_base = b; height = h } -> b + h + sqrt(b*b + h*h)


pclPerimeterR tri2
pclAreaR rect2