namespace Web_Api_Payments.Models.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public int CreditCardId { get; set; }
        public decimal Amount { get; set; }
        public string NameOnCard { get; set; }
        public long CreditCardNumber { get; set; }
        public string SecurityCode { get; set; }
        public bool Approved { get; set; }
    }
}