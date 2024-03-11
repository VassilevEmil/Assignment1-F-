module Payment

#load "ViaCard.fsx"
#load "CreditCard.fsx"
#load "MobilePay.fsx"

open ViaCard
open MobilePay
open CreditCard


type Payment = 
| ViaCard of ViaCard
| MobilePay of MobilePay
| CreditCard of CreditCard

    override this.ToString() =
         match this with 
        | ViaCard viaId -> viaId.ToString()
        | MobilePay mpId -> mpId.ToString()
        | CreditCard creditcrd -> creditcrd.ToString()      
