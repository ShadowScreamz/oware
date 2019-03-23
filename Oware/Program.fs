module Oware

//open System.Security.Cryptography.ECCurve

//open System.Security.Cryptography.ECCurve
//open System.Security.Cryptography.ECCurve



//There are two players in the game, either can start in position north or south
type StartingPosition =
    | South
    | North 

//A player has 6 houses that contain 4 seeds each
type Player = 
    {
        seeds : int
        house: int*int*int*int*int*int
    }

//The game can be in different states depending on the player and their position
type State = 
    |SouthWon 
    |NorthWon  
    |SouthTurn  
    |NorthTurn  
    |DrawState

//The board contains two players in different states
type Board = 
    {
        player1 : Player
        player2 : Player
        gameState: State
        score: int * int
    }

//At the beginning of the game there are 2 players 
//each player begins with no seeds captured
//there are 4 seeds in each house
let start position =
    let N = {seeds = 0 ; house = 4,4,4,4,4,4 }
    let S = {seeds = 0 ; house = 4,4,4,4,4,4 }
    let STATE  = 
        match position with
        |South  -> SouthTurn
        |_ -> NorthTurn
    let Board = {player1= N ; player2 = S; gameState = STATE; score = (0,0) }
    Board
 
let getSeeds n board = 
    let {player1 = P1 ; player2 = P2} = board
    let (a,b,c,d,e,f) = P1.house
    let (a',b',c',d',e',f') = P2.house
    match n with
    |1 -> a
    |2 -> b
    |3 -> c
    |4 -> d
    |5 -> e
    |6 -> f
    |7 -> a'
    |8 -> b'
    |9 -> c'
    |10 -> d'
    |11 -> e'
    |12 -> f'


let score board = failwith "Not implemented"
   (* match board with
    |(southscore, northscore) -> (South, North)
    |_ -> failwith "Score not updated"*)
 

let gameState board = failwith "Not implemented"
   (* match board with
    |South -> "Souths turn"
    |North -> "Norths turn"
    |DrawState -> "Game ended in draw"
    |SouthWon -> "South won"
    |NorthWon -> "North won"*)
   
let useHouse n board = failwith "Not implemented"
 
[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
