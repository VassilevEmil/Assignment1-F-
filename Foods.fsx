module Foods

type Food = 
 | Pasta
 | Tacos
 | Paella 

type PastaTypes = {
    SpaghettiCarbonara : float
    FettuccineAlfredo : float
    RigatoniTuna : float
}

type TacosTypes = {
    Beef : float
    Chicken : float
    Pork : float
}

type PaellaTypes = {
    FruttiDiMare : float
    Cioppino : float
    Chicken : float
}

let pastaPrice = 
    let pastas = { SpaghettiCarbonara = 6.5; FettuccineAlfredo = 7.0; RigatoniTuna = 7.0 }
    dict [Pasta, pastas]

let tacoPrice = 
    let tacos = { Beef = 6.5 ; Chicken = 5.5; Pork = 5.0 }
    dict [Tacos, tacos]

let paellaPrice = 
    let paellas = { FruttiDiMare = 7.0; Cioppino = 7.0; Chicken = 7.0 }
    dict [Paella, paellas]


let computePrice (foodType: Food) (ingredient: string) =
    match foodType with
    | Pasta -> (
        match ingredient with
        | "Spaghetti Carbonara" -> pastaPrice.[Pasta].SpaghettiCarbonara
        | "FettuccineAlfredo" -> pastaPrice.[Pasta].FettuccineAlfredo
        | "Rigatoni" -> pastaPrice.[Pasta].RigatoniTuna
    )
    | Tacos -> (
        match ingredient with
        | "Beef" -> tacoPrice.[Tacos].Beef
        | "Chicken" -> tacoPrice.[Tacos].Chicken
        | "Pork" -> tacoPrice.[Tacos].Pork
    )
    | Paella -> (
        match ingredient with
        | "FruttiDiMare" -> paellaPrice.[Paella].FruttiDiMare
        | "Cioppino" -> paellaPrice.[Paella].Cioppino
        | "Chicken" -> paellaPrice.[Paella].Chicken
    )