using EventManagementSystemADV.Data;
using EventManagementSystemADV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystemADV.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string category, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Events
                .Include(e => e.Category)
                .Include(e => e.Volunteers)
                .Where(e => !e.IsDeleted)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(e => e.Category.Name == category);
            }

            if (startDate.HasValue)
            {
                query = query.Where(e => e.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(e => e.Date <= endDate.Value);
            }

            var events = await query.ToListAsync();
            ViewBag.Categories = new SelectList(await _context.Categories.ToListAsync(), "Name", "Name");
            return View(events);
        }

        public async Task<IActionResult> Details(int id)
        {
            var eventDetails = await _context.Events
                .Include(e => e.Category)
                .Include(e => e.Volunteers)
                .FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            if (eventDetails == null) return NotFound();

            return View(eventDetails);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                eventToDelete.IsDeleted = true; 
                _context.Update(eventToDelete);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
