open System.IO

let outputFile = "output.txt" // Specify the name of the output file

// Define a function to write the output to a file
let writeToOutput (text: string) =
    use writer = new StreamWriter(outputFile, true)
    writer.WriteLine(text)

// Import functions from Order.fsx
#load "Order.fsx"

open Order


// Define a function to create test orders
let createTestOrders () =
    // Create test customers
    let viaCustomer =
        Customer.VIACustomer
            { Name = "John Doe"
              Address = "123 Main St"
              ViaCardNumber = "1234 5678 9012 3456" }

    let sosuCustomer =
        Customer.SOSUCustomer
            { Name = "Jane Smith"
              EmployeeID = "456 Elm St" }

    let viaCardJohn =
        Payment.ViaCard
            { AccountNumber = "1234567890"
              Pin = "1234" }

    let creditCardJane =
        Payment.CreditCard
            { CardNumber = "5678901234"
              ExpiryDate = "12/24"
              CVV = "123" }

    let mobilePayJohn =
        Payment.MobilePay
            { PhoneNumber = "9876543210"
              VerificationCode = "4567" }

    let viaCardJane =
        Payment.ViaCard
            { AccountNumber = "0987654321"
              Pin = "5678" }

    let mobilePayJohnAgain =
        Payment.MobilePay
            { PhoneNumber = "9876543210"
              VerificationCode = "4567" }

    let creditCardJaneAgain =
        Payment.CreditCard
            { CardNumber = "1234567890"
              ExpiryDate = "12/24"
              CVV = "789" }

    // Create test products
    let coffee = Product.Drink(Drink.Coffee)
    let tea = Product.Drink(Drink.Tea)
    let juice = Product.Drink(Drink.Juice)
    let burger = Product.Food(Food.Burger)
    let pizza = Product.Food(Food.Pizza)
    let apple = Product.Fruit(Fruit.Apple)
    let banana = Product.Fruit(Fruit.Banana)

    // Create test orders
    let order1 =
        { Customer = viaCustomer
          Product = coffee
          SizeOption = "Small"
          Quantity = 2.0
          PaymentType = viaCardJohn
          LeaveComment = "order1" }

    let order2 =
        { Customer = sosuCustomer
          Product = burger
          SizeOption = "Regular"
          Quantity = 1.0
          PaymentType = creditCardJane
          LeaveComment = "order2" }

    let order3 =
        { Customer = viaCustomer
          Product = apple
          SizeOption = "Regular"
          Quantity = 3.0
          PaymentType = mobilePayJohn
          LeaveComment = "order3" }

    let order4 =
        { Customer = sosuCustomer
          Product = tea
          SizeOption = "Small" // Adjust size option to match available options for tea
          Quantity = 2.0
          PaymentType = viaCardJane
          LeaveComment = "order4" }

    let order5 =
        { Customer = viaCustomer
          Product = pizza
          SizeOption = "Margherita" // Adjust size option to match available options for pizza
          Quantity = 1.0
          PaymentType = mobilePayJohnAgain
          LeaveComment = "order5" }

    let order6 =
        { Customer = sosuCustomer
          Product = banana
          SizeOption = "Large"
          Quantity = 4.0
          PaymentType = creditCardJaneAgain
          LeaveComment = "order6" }

    let order7 =
        { Customer = viaCustomer
          Product = juice
          SizeOption = "Medium"
          Quantity = 2.0
          PaymentType = viaCardJohn
          LeaveComment = "order7" }

    let order8 =
        { Customer = sosuCustomer
          Product = burger
          SizeOption = "VeggieBurger"
          Quantity = 3.0
          PaymentType = creditCardJane
          LeaveComment = "order8" }

    [ order1; order2; order3; order4; order5; order6; order7; order8 ]

// Define a function to test placing orders
let testPlaceOrders () =
    let orders = createTestOrders ()
    orders |> List.iter (fun order -> Order.orderAgent.Post(Order.OrderMsg order))

printf "\n\n\n\n\n\n\n\n\n\n\n\n"
printf "======================================STARTTEST====================================== \n"
// Call the test method
testPlaceOrders ()
