// https://www.codewars.com/kata/55bf01e5a717a0d57e0000ec/train/fsharp
let totalDigits (n:int) =
    match n with
    | 0 -> 1
    | _ -> (int) (log10 ((float)n)) + 1
let multDigits (n:int) =
    n.ToString() |> Seq.fold (fun n x-> (n * (int)(System.Char.GetNumericValue x))) 1
let rec persistence n = 
    match totalDigits n with
    | 1 -> 0
    | _ -> 1 + persistence(multDigits n)
