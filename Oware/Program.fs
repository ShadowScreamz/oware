module Oware

//open System.Security.Cryptography.ECCurve
//open System.Security.Cryptography.ECCurve




type StartingPosition =
    
    | South
    | North 

type Player = {
    captured : int
    House: int*int*int*int*int*int
    }


type State = 
    |SouthWon 
    |NorthWon  
    |SouthTurn  
    |NorthTurn  
    |DrawState 

type Board = {
    Player1 : Player
    Player2 : Player
    gameState: State}

    




    

let getSeeds n board = 
    let {Player1 = P1 ; Player2 = P2} = board
    let (a,b,c,d,e,f) = P1.House
    let (a',b',c',d',e',f') = P2.House

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
    |11  -> e'
    |_ -> f'




   
    


let useHouse n board = failwith "Not implemented"

let start position =
    let N = { captured = 0 ; House = 4,4,4,4,4,4 }
    let S = {captured = 0 ; House = 4,4,4,4,4,4 }
    
    let STATE  = 
        match position with
        |South  -> SouthTurn
        |_ -> NorthTurn
    let Board = {Player1= N ; Player2 = S; gameState = STATE }
    Board

     

        






        
=======
 
let getSeeds n board = 
 failwith "Not implemented"      

let useHouse n board = failwith "Not implemented"

//game should start at the southern end 
let start position = 
    match position with 
    |South -> StartingPosition.South
    |_ -> failwith "No Player available"
>>>>>>> f532a42b72caaa0b1ee603dd2dd140a8586239d6

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
