module Fruits


type Fruit = 
    | Apple
    | Banana
    | Mango


type AppleTypes = {
    green : float
    red : float
    mixed : float
}

type BananaTypes = {
    green : float
    yellow : float
    old : float
}

type MangoTypes = {
    green : float
    ripe : float
    old : float
}

let applePrice = 
    let apples = { green = 0.50 ; red = 0.50 ; mixed = 0.55 }
    dict [Apple, apples]

let bananaPrice = 
    let bananas = { green = 0.40; yellow = 0.50 ; old = 0.30 }
    dict [Banana, bananas]

let mangoPrice = 
    let mangos = { green = 0.70; ripe = 0.9; old = 0.6}
    dict [Mango, mangos]

let computePrice (fruit: Fruit) (typeOfItem: string) =
    match fruit with
    | Apple -> (
        match typeOfItem with
        | "green" -> apples.[Apple].green
        | "red"   -> apples.[Apple].red
        | "mixed" -> apples.[Apple].mixed    
    )
    | Banana -> (
        match typeOfItem with
        | "yellow" -> bananas.[Banana].yellow
        | "green"  -> bananas.[Banana].green
        | "old"    -> bananas.[Banana].old
    )
    | Mango -> (
        match typeOfItem with
        | "green" -> mangos.[Mango].green
        | "ripe"  -> mangos.[Mango].ripe
        | "old"   -> mangos.[Mango].old
    )
