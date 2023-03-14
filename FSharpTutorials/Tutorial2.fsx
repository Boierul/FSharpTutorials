// Product types
// -- Record
// -- Tuple
// -- Anonymous Record

type Person = { Name: string; Age: int }
type Day = { DayOfTheMonth: int; Month: int }

let Ben: Person = { Name = "Ben"; Age = 30 }
printf "%s is %d years old" Ben.Name Ben.Age 

