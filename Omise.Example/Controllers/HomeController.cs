using System.Web.Mvc;

namespace Omise.Example.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return string.IsNullOrEmpty(SessionSecretKey) ?
                RedirectToRoute(new { Controller = "Sessions", Action = "Index" }) :
                RedirectToRoute(new { Controller = "Charges", Action = "Index" });
        }
    }
}
