module Product

#load "Drinks.fsx"
#load "Foods.fsx"
#load "Fruits.fsx"

open Drinks
open Foods
open Fruits

type Product =
    | Drink of Drinks
    | Food of Foods
    | Fruit of Fruits

let computePrice (product: Product) (option: string) =
    match product with
    | Drink drink -> computePrice drink option
    | Food food -> computePrice food option
    | Fruit fruit -> computePrice fruit option