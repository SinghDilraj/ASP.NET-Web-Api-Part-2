using System.Linq;
using System.Web.Http;
using Web_Api_Payments.Models.BindingModels;
using Web_Api_Payments.Models.Domain;
using Web_Api_Payments.Models.ViewModels;

namespace Web_Api_Payments.Controllers
{
    [RoutePrefix("Api/Payments")]
    public class PaymentsController : BaseController
    {
        //// GET: api/Payments
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Payments/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Payments
        public IHttpActionResult PostNewPayment(PaymentPostModel model)
        {
            if (ModelState.IsValid)
            {
                CreditCard card = DbContext.CreditCards.FirstOrDefault(p => p.Id == model.CreditCardId);

                if (card != null)
                {
                    Payment payment = new Payment
                    {
                        CreditCard = card,
                        CreditCardId = card.Id,
                        Amount = model.Amount,
                        SecurityCode = model.SecurityCode,
                        CreditCardNumber = model.CreditCardNumber,
                        NameOnCard = model.NameOnCard,
                        Approved = true
                    };

                    DbContext.Payments.Add(payment);
                    DbContext.SaveChanges();

                    if (payment.Approved)
                    {
                        PaymentViewModel viewModel = new PaymentViewModel
                        {
                            Id = payment.Id,
                            SecurityCode = payment.SecurityCode,
                            Amount = payment.Amount,
                            CreditCardNumber = payment.CreditCardNumber,
                            NameOnCard = payment.NameOnCard,
                            CreditCard = new CreditCardViewModel
                            {
                                Id = payment.CreditCard.Id,
                                Brand = payment.CreditCard.Brand,
                                IdentificationNumber = payment.CreditCard.IdentificationNumber
                            }
                        };

                        return Ok(viewModel);
                    }
                    else
                    {
                        return BadRequest("The Payment has not been approved. This could be because we don't support all credit cards yet.");
                    }
                }
                else
                {
                    return BadRequest("Credit card Id not valid.");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //// PUT: api/Payments/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Payments/5
        //public void Delete(int id)
        //{
        //}
    }
}
