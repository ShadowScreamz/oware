module Oware

type StartingPosition =
    | South
    | North 

let getSeeds n board = 
    let rec get seeds =
        let housenum = (1, 2, 3, 4, 5, 6)
        let a, b, c, d, e, f = housenum
        match housenum with 
        |seeds -> housenum
        |_ -> failwith "Not Implemented"

failwith "Not implemented"

let useHouse n board = failwith "Not implemented"

//game should start at the southern end 
let start position = 
    match position with 
    |South -> StartingPosition.South
    |_ -> failwith "No Player available"

let score board = 
    failwith "Not implemented"

let gameState board = 
     failwith "Not implemented"


//Player: a player owns houses and seeds
type Player = 
    {   houses: int * int * int * int * int *  int
        seeds: int                                       //48 in total
    }

//Board: The board contains players, scoreboards and the general state of the game
type Board = 
    {  
        scoreboards: int * int  
        state: string                              
        players1: Player           
        players2: Player 
    }

 
[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
