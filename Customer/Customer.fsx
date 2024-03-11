module Customer


#load "ViaCustomer.fsx"
#load "SOSUCustomer.fsx"

open ViaCustomer
open  SosuCustomer

type Customer = 
    | VIACustomer of ViaCustomer.ViaCustomer
    | SOSUCustomer of SosuCustomer.SosuCustomer

override this.ToString() {
    match this with 
        | VIACustomer vc ->vuaCustomer.ToString()
        | SOSUCustomer sc->sosuCustomer.ToString()
}
