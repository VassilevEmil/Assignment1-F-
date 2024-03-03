module Drinks

type Drink = 
| Coffee
| Tee
| Juice

type Size = {
    Small: float
    Medium: float
    Large: float
}

let drinkPrices = 
    let coffeePrices = {Small = 1.5; Medium = 2; Large = 3}
    let teaPrices = {Small = 1.0; Medium = 1.5; Large = 2}
    let juicePrices = {Small = 1.5; Medium = 2; Large = 2.5}
    dict [Coffee, coffeePrices; Tee, teaPrices; Juice, juicePrices]

let computePrice (drink : Drink) (size : string) =
    match drink with
    | Coffee -> 
        (match size with
            | "Small" -> drinkPrices.[Coffee].Small
            | "Medium" -> drinkPrices.[Coffee].Medium
            | "Large" -> drinkPrices.[Coffee].Large
        )
    | Tee -> 
        (match size with
            | "Small" -> drinkPrices.[Tee].Small   
            | "Medium" -> drinkPrices.[Tee].Medium
            | "Large" -> drinkPrices.[Tee].Large
        )
    | Juice -> 
        (match size with
            | "Small" -> drinkPrices.[Juice].Small
            | "Medium" -> drinkPrices.[Juice].Medium
            | "Large" -> drinkPrices.[Juice].Large
        )