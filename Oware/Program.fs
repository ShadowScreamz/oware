module Oware

open System.Security.Cryptography.ECCurve
open System.Security.Cryptography.ECCurve


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
 failwith "Not implemented"      

let useHouse n board = failwith "Not implemented"

//game should start at the southern end 
let start position = 
    match position with 
    |South -> StartingPosition.South
    |_ -> failwith "No Player available"

let score board = 
    let brd =
        match board with
        | {Board.scoreboards = board} -> (southscore`q, northscore)
        |_ -> failwith "Not implemented"
    brd

let gameState board = 
    let b =
        match board with
        |{Board.state = b} -> "Souths turn"
        |{Board.state = b} -> "Norths turn"
        |{Board.state = b} -> "Game ended in draw"
        |{Board.state = b} -> "South won"
        |{Board.state = b} -> "North won"
    b

 
[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
