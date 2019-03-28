﻿module Oware


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
    match board.score with
    |southScore, northScore -> SCORE
    |_ -> failwith "Score not updated"
    SCORE

let gameState board =     
    match board.gameState with
    |SouthTurn -> "Souths turn"
    |NorthTurn -> "Norths turn"
    |DrawState -> "Game ended in draw"
    |SouthWon -> "South won"
    |NorthWon -> "North won" 

//function to turn the board from n to
let selectedhousezero n board = 
    let {player1 = P1 ; player2 = P2} = board
    let (a,b,c,d,e,f) = P1.house
    let (a',b',c',d',e',f') = P2.house
    match n with
//failwith "Game is in neutral
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


let useHouse n board = 
    let seednum = getSeeds n board
    match turn n board.gameState with
    |true -> board
    |_ -> 
    match seednum  with
    |0 -> board 
    |_ -> 
    //match phase
    let (a,b,c,d,e,f) = (selectedhousezero n board ).player1.house
    let (a',b',c',d',e',f') = (selectedhousezero n board ).player2.house
    let newboard = (a,b,c,d,e,f, a',b',c',d',e',f')
    let rec move n seed nb numhouse  =
        let p = // put seeds in p
                match n with
                |13 -> 1 
                |_ -> n
        match seed<>0 with
        |false ->nb  // return board with player1 and 2 split newboard 
        |_ ->    match p = numhouse with
                    |true ->    move (p+1) seed nb numhouse 
                    |_ ->   move (p+1) (seed-1) (updatehouse p nb) numhouse
    let a = move (n + 1) seednum newboard n

    let N = {seeds = 0 ; house = 4,4,4,4,4,4 }
    let S = {seeds = 0 ; house = 4,4,4,4,4,4 }
    let board = {player1= N ; player2 = S; gameState = board.gameState; score = (0,0) }
   

    //currenthousenum seedenum board orighouse


  (*  let {player1 = P1 ; player2 = P2} = board
    let (seednum, housenum)= getSeeds n board, n
    let rec addValue board house=
        match seednum= 0 with
        |true ->
            match (seednum,housenum) with
            |1 -> addValue (a+1,b,c,d,e,f,a',b',c',d',e',f') (seednum - 1) (housenum + 1)
            |2 -> addValue(a,b+1,c,d,e,f,a',b',c',d',e',f') (seednum - 1) (housenum + 1)
            |3 -> addValue(a,b,c+1,d,e,f,a',b',c',d',e',f') (seednum - 1) (housenum + 1)
            |4 -> addValue(a,b,c,d+1,e,f,a',b',c',d',e',f') (seednum - 1) (housenum + 1)
            |5 -> addValue(a,b,c,d,e+1,f,a',b',c',d',e',f') (seednum - 1) (housenum + 1)
            |6 -> addValue(a,b,c,d,e,f+1,a',b',c',d',e',f') (seednum - 1) (housenum + 1)
            |7 -> addValue(a,b,c,d,e,f,a'+ 1,b',c',d',e',f')(seednum - 1) (housenum + 1)
            |8 -> addValue(a,b,c,d,e,f,a',b'+1,c',d',e',f')(seednum - 1) (housenum + 1)
            |9 -> addValue(a,b,c,d,e,f,a',b',c'+1,d',e',f')(seednum - 1) (housenum + 1)
            |10 -> addValue(a,b,c,d,e,f,a',b',c',d'+1,e',f')(seednum - 1) (housenum + 1)
            |11 -> addValue(a,b,c,d,e,f,a',b',c',d',e'+1,f') (seednum - 1) (housenum + 1)
            |12 -> addValue(a,b,c,d,e,f,a',b',c',d',e',f'+1)(seednum - 1) (housenum + 1)
        |_ -> board
    addValue 0 board *)


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

    

//The method removes seeds from a given house (Method 1)
let Collecting n board =
    let {player1 = P1; player2=P2; gameState = state} = board //extraction 
    let (a,b,c,d,e,f) = P1.house //extraction
    let (a',b',c',d',e',f') = P2.house //extraction
    let numseeds= getSeeds n board //checking how many seeds are in the given house
    match numseeds>0 with //check that the given house does actually contain seeds
    |true ->
        //if it has seeds,then...
        match state with
        //check who's turn is it to play. Assuming that Player1 is South
        |NorthTurn -> match n with
                    //If gameState dictates that it's North's turn ti play
                  |7 -> {board.player2 with house = 0,b',c',d',e',f'}
                  |8 -> {board.player2 with house = a',0,c',d',e',f'}
                  |9 -> {board.player2 with house = a',b',0,d',e',f'}
                  |10 -> {board.player2 with house = a',b',c',0,e',f'}
                  |11 -> {board.player2 with house = a',b',c',d',0,f'}
                  |12 -> {board.player2 with house = a',b',c',d',e',0}
                  |_->{board.player1 with house=P1.house}//player2 can't collect on player1's houses
        |SouthTurn -> match n with//If gameState dictates that it's South's turn ti play
                  |1 -> {board.player1 with house = a-numseeds,b,c,d,e,f}
                  |2 -> {board.player1 with house = a,b-numseeds,c,d,e,f}
                  |3 -> {board.player1 with house = a,b,c-numseeds,d,e,f}
                  |4 -> {board.player1 with house = a,b,c,d-numseeds,e,f}
                  |5 -> {board.player1 with house = a,b,c,d,e-numseeds,f}
                  |6 -> {board.player1 with house = a,b,c,d,e,f-numseeds}
                  |_-> {board.player2 with house=P2.house}//player1 can't collect on player2's houses
        |_->{board.player2 with house=P2.house}//other states don't invoke the collection of seeds
    |_ ->
        //these are really just for completeness
        match state with
        |NorthWon-> {board.player2 with house = P2.house}
        |SouthWon ->{board.player1 with house = P1.house}
        |_ ->{board.player2 with house = P2.house}
    
    
 // Method 1

 //Makin a move with the sow methos (function 2)
 (* LOGIC:
    now we wanna distribute the seeds, depending on the number of seeds collected,from which house (n).
    1. So we basically need to go around, starting fron house n+1 and keep droppin a seed
    2. When we run out of seeds,we need to check how many seeds we have in that last house visited
    3. We call the Capture function (if seeds are < 4)
 *)
let sow n board = //
    let {player1 = P1; player2=P2; gameState = state} = board //extraction 
    let (a,b,c,d,e,f) = P1.house //extraction
    let (a',b',c',d',e',f') = P2.house //extraction
    let numseeds = getSeeds n board
    let rec distri (a,b,c,d,e,f,a',b',c',d',e',f') numseeds acc =
        match state,numseeds=0 with
        | NorthTurn,true -> {board.player2 with house=(a',b',c',d',e',f')} //North's turn but no more seeds to distribute
        | NorthTurn,false ->match (n+1)%13 with //the %13 enures that we don't go over 12 for the houses i.e for n+1=13 we have that (n+1)%13=1
                          |7 -> distri (a,b,c,d,e,f,a'+1,b',c',d',e',f') (numseeds-1) ((acc+1)%13)
                          |8 -> distri (a,b,c,d,e,f,a',b',c'+1,d',e',f') (numseeds-1) ((acc+1)%13)
                          |9 -> distri (a,b,c,d,e,f,a',b',c',d'+1,e',f') (numseeds-1) ((acc+1)%13)
                          |10 -> distri (a,b,c,d,e,f,a',b',c',d',e'+1,f') (numseeds-1) ((acc+1)%13)
                          |11 -> distri (a,b,c,d,e,f,a',b',c',d',e',f'+1) (numseeds-1) ((acc+1)%13)
                          |12 -> distri (a,b,c,d,e,f,a+1,b,c,d,e,f) (numseeds-1) ((acc+1)%13)
                          |_->{board.player2 with house=(a',b',c',d',e',f')}
        | SouthTurn,true -> {board.player1 with house=(a,b,c,d,e,f)} //South's turn but no more seeds to distribute
        | SouthTurn,false -> match (n+1)%13 with
                          |1 -> distri (a+1,b,c,d,e,f,a',b',c',d',e',f') (numseeds-1) ((acc+1)%13)
                          |2 -> distri (a,b,c+1,d,e,f,a',b',c',d',e',f') (numseeds-1) ((acc+1)%13)
                          |3 -> distri (a,b,c,d+1,e,f,a',b',c',d',e',f') (numseeds-1) ((acc+1)%13)
                          |4 -> distri (a,b,c,d,e+1,f,a',b',c',d',e',f') (numseeds-1) ((acc+1)%13)
                          |5 -> distri (a,b,c,d,e,f+1,a',b',c',d',e',f') (numseeds-1) ((acc+1)%13)
                          |6 -> distri (a+1,b,c,d,e,f,a',b',c',d',e',f') (numseeds-1) ((acc+1)%13)
                          |_->{board.player2 with house=(a',b',c',d',e',f')}
        | _->{board.player2 with house=(a',b',c',d',e',f')}
    match numseeds>0 with
    |false ->{board.player2 with house=(a',b',c',d',e',f')}
    |_-> distri ((a,b,c,d,e,f,a',b',c',d',e',f')) numseeds n 
    //let (housenum)= getSeeds n board
       // let (a,b,c,d,e,f,a',b',c',d',e',f') = board
       (* let rec addValue (a,b,c,d,e,f,a',b',c',d',e',f')=
            match n = 0 with
            |true ->    match (housenum) with
                    |1 -> addValue(a+1,b,c,d,e,f,a',b',c',d',e',f') (seed - 1) (house + 1)
                    |2 -> addValue(a,b+1,c,d,e,f,a',b',c',d',e',f') (seed - 1) (house + 1)
                    |3 -> addValue(a,b,c+1,d,e,f,a',b',c',d',e',f') (seed - 1) (house + 1)
                    |4 -> addValue(a,b,c,d+1,e,f,a',b',c',d',e',f') (seed - 1) (house + 1)
                    |5 -> addValue(a,b,c,d,e+1,f,a',b',c',d',e',f') (seed - 1) (house + 1)
                    |6 -> addValue(a,b,c,d,e,f+1,a',b',c',d',e',f') (seed - 1) (house + 1)
                    |7 -> addValue(a,b,c,d,e,f,a'+ 1,b',c',d',e',f') (seed - 1) (house + 1)
                    |8 -> addValue(a,b,c,d,e,f,a',b'+1,c',d',e',f') (seed - 1) (house + 1)
                    |9 -> addValue(a,b,c,d,e,f,a',b',c'+1,d',e',f') (seed - 1) (house + 1)
                    |10 -> addValue(a,b,c,d,e,f,a',b',c',d'+1,e',f') (seed - 1) (house + 1)
                    |11 -> addValue(a,b,c,d,e,f,a',b',c',d',e'+1,f') (seed - 1) (house + 1)
                    |12 -> addValue(a,b,c,d,e,f,a',b',c',d',e',f'+1) (seed - 1) (house + 1)
                    |_ -> failwith "no house given"
            |_ -> board
        addValue  *)


   
[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
