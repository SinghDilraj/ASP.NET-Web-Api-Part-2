using System.Web.Http;
using Web_Api_Payments.Models;

namespace Web_Api_Payments.Controllers
{
    public class BaseController : ApiController
    {
        public readonly ApplicationDbContext DbContext;
        public BaseController()
        {
            DbContext = new ApplicationDbContext();
        }
    }
}
