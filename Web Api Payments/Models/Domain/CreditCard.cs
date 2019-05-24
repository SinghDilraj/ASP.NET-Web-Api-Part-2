namespace Web_Api_Payments.Models.Domain
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string Brand { get; set; }
    }
}