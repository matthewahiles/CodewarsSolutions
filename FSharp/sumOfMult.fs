// https://www.codewars.com/kata/57f36495c0bb25ecf50000e7/train/fsharp
let (|MultOf|_|) div i = if i % div = 0 then Some() else None
let checkMult n =
    match n with
    | MultOf 3 | MultOf 5 -> n
    | _ -> 0
let rec findSum n = 
    [1..n] |> Seq.fold (fun s n -> s + checkMult n) 0
