// https://www.codewars.com/kata/58678d29dbca9a68d80000d7/train/fsharp
let flip (a:char) : char =
    match a with
    | '0'  -> '1'
    | '1' -> '0'
    | _ -> raise (System.ArgumentException("shit is fucked"))
let findClosing (arr: char array, start:int) : int =
    let mutable openingCount = 0
    let mutable closingIndex = 0
    for i = start to arr.Length - 1 do
        match arr.[i] with
        | '[' -> openingCount <- openingCount + 1
        | ']' when openingCount = 0 -> match closingIndex with
                                       | 0 -> closingIndex <- i
                                       | _ -> ()
        | ']' when openingCount > 0 -> openingCount <- openingCount - 1
        | _ -> ()
    closingIndex
let findOpening (arr: char array, start:int) : int =
    let mutable endingCount = 0
    let mutable openingIndex = 0
    for i = start downto 0 do
        match arr.[i] with
        | ']' -> endingCount <- endingCount + 1
        | '[' when endingCount = 0 -> match openingIndex with
                                      | 0 -> openingIndex <- i
                                      | _ -> ()
        | '[' when endingCount > 0 -> endingCount <- endingCount - 1
        | _ -> ()
    openingIndex
let rec executeInstructions (instructions: char array, tape: char array, instructionsLoc: int, tapeLoc: int) : string =
    match instructionsLoc with
    | i when i = instructions.Length -> new System.String(tape)
    | _ -> match instructions.[instructionsLoc] with
           | '<' -> match tapeLoc with
                    | 0 -> new System.String(tape)
                    | _ -> executeInstructions(instructions, tape, instructionsLoc + 1, tapeLoc - 1)
           | '>' -> match tapeLoc with
                    | i when i = tape.Length - 1 -> new System.String(tape)
                    | _ -> executeInstructions(instructions, tape, instructionsLoc + 1, tapeLoc + 1)
           | '*' -> tape.[tapeLoc] <- flip tape.[tapeLoc]
                    executeInstructions(instructions, tape, instructionsLoc + 1, tapeLoc)
           | '[' -> match tape.[tapeLoc] with
                    | '0' -> executeInstructions(instructions, tape, findClosing(instructions, instructionsLoc + 1), tapeLoc)
                    | _ -> executeInstructions(instructions, tape, instructionsLoc + 1, tapeLoc)
           | ']' -> match tape.[tapeLoc] with
                    | '1' -> executeInstructions(instructions, tape, findOpening(instructions, instructionsLoc - 1), tapeLoc)
                    | _ -> executeInstructions(instructions, tape, instructionsLoc + 1, tapeLoc)
           | _ -> executeInstructions(instructions, tape, instructionsLoc + 1, tapeLoc)
let interpreter (code: string) (tape: string) =
    executeInstructions(code.ToCharArray(), tape.ToCharArray(), 0, 0).ToString()
 
