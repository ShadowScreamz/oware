module Oware

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

    
    /////////////////////////



    

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

     

        






        

let score board = failwith "Not implemented"

let gameState board = failwith "Not implemented"

[<EntryPoint>]
let main _ =
    printfn "Hello from F#!"
    0 // return an integer exit code
