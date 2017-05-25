using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Omise;

namespace Omise.Example.Controllers
{
    public class SessionsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            SessionPublicKey = collection["PublicKey"];
            SessionSecretKey = collection["SecretKey"];

            try
            {
                var client = BuildClient();
                var account = client.Account.Get().Result;
                AccountEmail = account.Email;
                AccountCurrency = account.Currency;

                return RedirectToRoute(new { Controller = "Charges", Action = "Index" });
            }
            catch (Exception e)
            {
                SessionPublicKey = null;
                SessionSecretKey = null;
                AccountEmail = null;
                AccountCurrency = null;

                Notice = e.Message;
                return View("Index");
            }
        }
    }
}