using System.ComponentModel.DataAnnotations;

namespace Web_Api_Payments.Models.BindingModels
{
    public class PaymentPostModel
    {
        public int Id { get; set; }
        [Required]
        public int CreditCardId { get; set; }
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335", ErrorMessage = "Amount Should be greator than 0.")]
        public decimal Amount { get; set; }
        [Required]
        public string NameOnCard { get; set; }
        [Required]
        [CreditCard(ErrorMessage = "Card number is not valid.")]
        public long CreditCardNumber { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "The Security Code must be at least 3 characters long.", MinimumLength = 3)]
        public string SecurityCode { get; set; }
    }
}