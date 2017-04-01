using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Szybkapracapl.Controllers
{
    public class OffersController : Controller
    {
        // GET: Offers
        public ActionResult Create()
        {
            return View();
        }
    }
}