using HARMIC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HARMIC.Controllers
{
    public class AccomodationController : Controller
    {
        private readonly Travel_BookerContext _context;
        public AccomodationController(Travel_BookerContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var accomodation = _context.Accomodations.Include(x => x.AccomodationName).SingleOrDefault(x => x.AccomodationId==id);
            if (accomodation != null) 
            { 
                return RedirectToAction("Index"); 
            }
            return View(accomodation);
            return View();
        }
    }
}
