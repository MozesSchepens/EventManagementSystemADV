using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManagementSystemADV.Data;
using EventManagementSystemADV.Models;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagementSystemADV.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var events = _context.Events.Include(e => e.Category).Include(e => e.Volunteers);
            return View(await events.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = _context.Categories.ToList();
            ViewData["Volunteers"] = _context.Volunteers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event @event, int[] volunteerIds)
        {
            if (ModelState.IsValid)
            {
                @event.Volunteers = _context.Volunteers.Where(v => volunteerIds.Contains(v.Id)).ToList();
                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = _context.Categories.ToList();
            ViewData["Volunteers"] = _context.Volunteers.ToList();
            return View(@event);
        }
    }
}
