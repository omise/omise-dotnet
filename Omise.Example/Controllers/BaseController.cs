using System.Web.Mvc;

namespace Omise.Example.Controllers
{
    public abstract class BaseController : Controller
    {
        // temp data
        protected string Notice
        {
            get { return TempData["Notice"] as string; }
            set { TempData["Notice"] = value; }
        }

        // session
        protected string AccountEmail
        {
            get { return Session["Omise-Account-Email"] as string; }
            set { Session["Omise-Account-Email"] = value; }
        }

        protected string AccountCurrency
        {
            get { return Session["Omise-Account-Currency"] as string; }
            set { Session["Omise-Account-Currency"] = value; }
        }

        protected string SessionSecretKey
        {
            get { return Session["Omise-Secret-Key"] as string; }
            set { Session["Omise-Secret-Key"] = value; }
        }

        protected string SessionPublicKey
        {
            get { return Session["Omise-Public-Key"] as string; }
            set { Session["Omise-Public-Key"] = value; }
        }

        protected Client BuildClient()
        {
            return new Client(pkey: SessionPublicKey, skey: SessionSecretKey);
        }
    }
}
