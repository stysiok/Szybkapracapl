using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Szybkapracapl.Models;
using Szybkapracapl.ViewModels;

namespace Szybkapracapl.Controllers
{
    public class OffersController : Controller
    {
        private ApplicationDbContext _context;

        public OffersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Offers
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(OfferFormViewModel viewModel)
        {
            var employerId = User.Identity.GetUserId();
            var employer = _context.Users.Single(u => u.Id == employerId);

            var offer = new Offer
            {
                Employer = employer,
                Name = viewModel.Name,
                //City = viewModel.City,
                Date = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                Description = viewModel.Description,
                Sallary = (double) viewModel.Sallary
            };

            _context.Offers.Add(offer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}