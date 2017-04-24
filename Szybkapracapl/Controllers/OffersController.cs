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
            var id = User.Identity.GetUserId();

            var works = _context.Works
                .Where(w => w.EmployeeId == id)
                .ToList();

            var offers = _context.Offers
                .Include(o => o.City)
                .Include(o => o.Employer)
                .Where(o => o.Date > DateTime.Now)
                .Where(o => o.EmployerId != id)
                .ToList();

            foreach (var work in works)
            {
                offers.RemoveAll(o => o.Id == work.OfferId);
            }

            var viewModel = new ViewOffersViewModel()
            {
                Offers = offers,
                Cities = _context.Cities.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ViewOffers(ViewOffersViewModel model)
        {
            var id = User.Identity.GetUserId();

            var works = _context.Works
                .Where(w => w.EmployeeId == id)
                .ToList();

            var offers = _context.Offers
                .Include(o => o.City)
                .Include(o => o.Employer)
                .Where(o => o.Date > DateTime.Now)
                .Where(o => o.EmployerId != id)
                .Where(o => o.CityId == model.CityId)
                .ToList();

            foreach (var work in works)
            {
                offers.RemoveAll(o => o.Id == work.OfferId);
            }

            var viewModel = new ViewOffersViewModel()
            {
                Offers = offers,
                Cities = _context.Cities.ToList()
            };

            return View(viewModel);
        }

        public ActionResult MyOffers()
        {
            var myId = User.Identity.GetUserId();

            var myOffers = _context.Offers.Include(o => o.City).Where(o => o.EmployerId == myId).ToList();

            var myWorks = _context.Works
                .Include(w => w.Employee)
                .Include(w => w.Employer)
                .Include(w => w.Offer.City)
                .Where(w => w.EmployeeId == myId).ToList();

            

            var myOffersViewModel = new MyOffersViewModel()
            {
                MyOffers = myOffers,
                MyWorks = myWorks
            };
            return View(myOffersViewModel);
        }
    }
}