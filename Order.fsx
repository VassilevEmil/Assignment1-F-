module Order

#load "Product/Product.fsx"
#load "Payment/Payment.fsx"
#load "Customer/Customer.fsx"

open Product
open Payment
open Customer

// Define a simple data type for orders
type Order =
    { Customer: Customer
      Product: Product
      SizeOption: string
      Quantity: float
      PaymentType: Payment
      LeaveComment: string }

// Define a function to calculate VAT
let calculateVAT (percent: float) (price: float) = price * (percent / 100.0)

// Define a function to place an order
// Define a function to place an order
let placeOrder (order: Order) =
    printfn "Receipt:"

    // Calculate price
    let price =
        match order.Product with
        | Product.Drink drink -> computePrice (Product.Drink drink) order.SizeOption * float order.Quantity
        | Product.Food food -> computePrice (Product.Food food) order.SizeOption * float order.Quantity
        | Product.Fruit fruit -> computePrice (Product.Fruit fruit) order.SizeOption * float order.Quantity

    // Apply VAT if applicable
    let vatRate =
        match order.Product with
        | Product.Drink _ -> 10.0 // 10% VAT for drinks
        | _ -> 0.0 // No VAT for other products

    let vatAmount = calculateVAT vatRate price
    let finalPrice = price + vatAmount

    // Print customer details
    match order.Customer with
    | VIACustomer viaCustomer -> printfn "Customer: %s\nAddress: %s" viaCustomer.Name viaCustomer.Address
    | SOSUCustomer sosuCustomer -> printfn "Customer: %s\nEmployeeID: %s" sosuCustomer.Name sosuCustomer.EmployeeID

    // Print product details
    let productDescription =
        match order.Product with
        | Product.Drink drink -> sprintf "Drink: %A" drink
        | Product.Food food -> sprintf "Food: %A" food
        | Product.Fruit fruit -> sprintf "Fruit: %A" fruit

    printfn "%s\nQuantity: %.2f\nSize: %s" productDescription order.Quantity order.SizeOption

    // Print payment method details
    match order.PaymentType with
    | Payment.ViaCard viaCard ->
        printfn "Payment Method: Via Card\nAccount Number: %s\nPin: %s" viaCard.AccountNumber viaCard.Pin
    | Payment.MobilePay mobilePay ->
        printfn
            "Payment Method: Mobile Pay\nPhone Number: %s\nVerification Code: %s"
            mobilePay.PhoneNumber
            mobilePay.VerificationCode
    | Payment.CreditCard creditCard ->
        printfn
            "Payment Method: Credit Card\nCard Number: %s\nExpiry Date: %s\nCVV: %s"
            creditCard.CardNumber
            creditCard.ExpiryDate
            creditCard.CVV

    // Print VAT amount only if applicable
    if vatRate > 0.0 then
        printfn "VAT (%.2f%%): $%.2f" vatRate vatAmount

    // Print total amount to pay and comments
    printfn "Total amount to pay: $%.2f" finalPrice
    printfn "Comments: %s" order.LeaveComment
    printfn "-----------------------------------"

type OrderMsg = OrderMsg of Order

let orderAgent =
    MailboxProcessor.Start(fun inbox ->
        let rec loop () =
            async {
                let! msg = inbox.Receive()

                match msg with
                | OrderMsg order ->
                    try
                        placeOrder order
                    with ex ->
                        printfn "========ERRROR=======\n"

                        printfn
                            "Error processing order for %s: %s doesn't exist in database! \n"
                            order.LeaveComment
                            order.SizeOption

                        printfn "========ERRROR=======\n"
                        return ()

                return! loop ()
            }

        loop ())
