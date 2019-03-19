module Oware


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
        player1: Player           
        player2: Player 
    }

type StartingPosition =
    | South
    | North 

let getSeeds n board = 
        let housenum = (1, 2, 3, 4, 5, 6) //number of houses
        let a, b, c, d, e, f = housenum   //names of houses
            match n = housenum && seeds = 4 with 
            |{Board.player1.houses = housenum; } -> collect(seeds -1)(acc + 1)
            |_ -> acc 
        collect 4

let useHouse n board = failwith "Not implemented"

//game should start at the southern end 
let start position = 
    match position with 
    |South -> StartingPosition.South
    |_ -> failwith "No Player available"

let score board = 
    let brd =
        match brd = board with
        | {Board.scoreboards = board} -> (southscore, northscore)
        |_ -> failwith "Not implemented"

let gameState board = 
     failwith "Not implemented"

 
[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
