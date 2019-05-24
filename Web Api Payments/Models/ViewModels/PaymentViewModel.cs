namespace Web_Api_Payments.Models.ViewModels
{
    public class PaymentViewModel
    {
        public int Id { get; set; }
        public CreditCardViewModel CreditCard { get; set; }
        public decimal Amount { get; set; }
        public string NameOnCard { get; set; }
        public long CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public bool Approved { get; set; }
    }
}