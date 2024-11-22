using Microsoft.AspNetCore.Mvc;
using EventManagementSystemADV.Models;
using EventManagementSystemADV.Data;

namespace EventManagementSystemADV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _context.Events.ToList(); 
            return View(events); 
        }
    }
}