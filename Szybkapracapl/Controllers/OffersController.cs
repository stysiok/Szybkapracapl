﻿using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
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
            var cities = _context.Cities.ToList();

            var viewModel = new OfferFormViewModel()
            {
                Cities = cities,
            };
            
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(OfferFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Cities = _context.Cities.ToList();
                return View("Create", viewModel);
            }

            var offer = new Offer
            {
                EmployerId = User.Identity.GetUserId(),
                Name = viewModel.Name,
                CityId = viewModel.City,
                Date = viewModel.GetDateTime(),
                Description = viewModel.Description,
                Sallary = (double) viewModel.Sallary
            };

            _context.Offers.Add(offer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewOffers()
        {
            var offers = _context.Offers.Include(o => o.City).Include(o => o.Employer)
                .Where(o => o.Date > DateTime.Now); //tu dodac walidacje przez miasto i uzytkownika

            return View(offers);
        }
    }
}