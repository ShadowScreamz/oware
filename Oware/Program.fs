module Oware


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



let score board = //failwith "Not implemented"
    let {score = SCORE} = board
    let (southScore, northScore) = SCORE
    match board with
    |{score = (southScore, northScore)} -> SCORE
    |_ -> failwith "Score not updated"
    SCORE

let gameState board =     
    match board.gameState with
    |SouthTurn -> "Souths turn"
    |NorthTurn -> "Norths turn"
    |DrawState -> "Game ended in draw"
    |SouthWon -> "South won"
    |NorthWon -> "North won" 


//function to turn the board from n to s

let useHouse n board = // failwith "Game is in neutral"
//fuction to check if the house is zero
    let {player1 = P1 ; player2 = P2} = board
    let (a,b,c,d,e,f) = P1.house
    let (a',b',c',d',e',f') = P2.house
    match n with
    |1 -> {board with player1 = {board.player1 with house = 0,b,c,d,e,f}}
    |2 -> {board with player1 = {board.player1 with house = a,0,c,d,e,f}}
    |3 -> {board with player1 = {board.player1 with house = a,b,0,d,e,f}}
    |4 -> {board with player1 = {board.player1 with house = a,b,c,0,e,f}}
    |5 -> {board with player1 = {board.player1 with house = a,b,c,d,0,f}}
    |6 -> {board with player1 = {board.player1 with house = a,b,c,d,e,0}}
    |7 -> {board with player2 = {board.player2 with house = 0,b',c',d',e',f'}}
    |8 -> {board with player2 = {board.player2 with house = a',0,c',d',e',f'}}
    |9 -> {board with player2 = {board.player2 with house = a',b',0,d',e',f'}}
    |10 -> {board with player2 = {board.player2 with house = a',b',c',0,e',f'}}
    |11 -> {board with player2 = {board.player2 with house = a',b',c',d',0,f'}}
    |12 -> {board with player2 = {board.player2 with house = a',b',c',d',e',0}}
    |_ -> failwith "Game is in neutral"
//function to check which house we are using
let updatehouse n (a,b,c,d,e,f, a',b',c',d',e',f')= 
    match n with
    |1 -> (a+1),b,c,d,e,f,a',b',c',d',e',f'
    |2 -> a,(b+1),c,d,e,f,a',b',c',d',e',f'
    |3 -> a,b,(c+1),d,e,f,a',b',c',d',e',f'
    |4 -> a,b,c,(d+1),e,f,a',b',c',d',e',f'
    |5 -> a,b,c,d,(e+1),f,a',b',c',d',e',f'
    |6 -> a,b,c,d,e,(f+1),a',b',c',d',e',f'
    |7 -> a,b,c,d,e,f,(a'+1),b',c',d',e',f'
    |8 -> a,b,c,d,e,f,a',(b'+1),c',d',e',f'
    |9 -> a,b,c,d,e,f,a',b',(c'+1),d',e',f'
    |10 -> a,b,c,d,e,f,a',b',c',(d'+1),e',f'
    |11 -> a,b,c,d,e,f,a',b',c',d',(e'+1),f'
    |12 -> a,b,c,d,e,f,a',b',c',d',e',(f'+1)
    |_ -> failwith "Game is in neutral" 
//function to check whose turn it is
let turn n player =
    match player with
    |SouthTurn ->    match n with
                    |1|2|3|4|5|6 -> true
                    |_ ->   NorthTurn  
                            match n with
                            |7|8|9|10|11|12 -> true
                            |_ -> failwith "Game is in neutral"

    


 
[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
