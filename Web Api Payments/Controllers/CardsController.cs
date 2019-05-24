using System.Linq;
using System.Web.Http;
using Web_Api_Payments.Models.ViewModels;

namespace Web_Api_Payments.Controllers
{
    [RoutePrefix("Api/Cards")]
    public class CardsController : BaseController
    {
        // GET: api/Cards
        public IHttpActionResult GetAllCards()
        {
            System.Collections.Generic.List<CreditCardViewModel> cards = DbContext.CreditCards
                .Select(p => new CreditCardViewModel
                {
                    Id = p.Id,
                    IdentificationNumber = p.IdentificationNumber,
                    Brand = p.Brand
                }).ToList();

            return cards.Any() ? Ok(cards) : (IHttpActionResult)NotFound();
        }

        [Route("{cardId:int}")]
        // GET: api/Cards/5
        public IHttpActionResult GetCard(int cardId)
        {
            Models.Domain.CreditCard card = DbContext.CreditCards.FirstOrDefault(p => p.Id == cardId);

            if (card != null)
            {
                CreditCardViewModel viewModel = new CreditCardViewModel
                {
                    Id = card.Id,
                    IdentificationNumber = card.IdentificationNumber,
                    Brand = card.Brand
                };

                return Ok(viewModel);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
