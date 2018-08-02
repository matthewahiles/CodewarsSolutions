// https://www.codewars.com/kata/find-the-missing-term-in-an-arithmetic-progression/fsharp
type 'a IList = 'a System.Collections.Generic.IList
let rec findMissingItem (items:list<int>, diff: int) =
    match items.[1] with
    | i when i - diff = items.[0]-> findMissingItem(items.[1..items.Length - 1], diff)
    | _ ->items.[1] - diff

let findMissing (items : int IList) = 
    let input = items |> Seq.toList
    findMissingItem(input, input.[1] - input.[0])
