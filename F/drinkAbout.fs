// https://www.codewars.com/kata/56170e844da7c6f647000063/train/fsharp
let peopleWithAgeDrink (old:int) =
  match old with
  | i when i < 14 -> "drink toddy"
  | i when i < 18 -> "drink coke"
  | i when i < 21 -> "drink beer"
  | _ -> "drink whisky"
