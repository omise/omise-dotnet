using System;
using System.Web.Mvc;
using System.Collections.Generic;
using Omise.Models;
using System.Linq;
using Omise.Example.ViewModels.Charges;

namespace Omise.Example.Controllers
{
    public class ChargesController : BaseController
    {
        public ActionResult Index()
        {
            var model = new Index();

            try
            {
                model.Charges = BuildClient()
                    .Charges
                    .GetList()
                    .Result
                    .Data;
            }
            catch (Exception e)
            {
                Notice = e.Message;
            }

            return View(model);
        }
    }
}