using Microsoft.AspNet.Identity;
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

            var offer = new Offer
            {
                EmployerId = User.Identity.GetUserId(),
                Name = viewModel.Name,
                CityId = viewModel.City,
                Date = viewModel.DateTime,
                Description = viewModel.Description,
                Sallary = (double) viewModel.Sallary
            };

            _context.Offers.Add(offer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}