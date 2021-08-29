using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationNet5.Data;
using WebApplicationNet5.Entities.School;

namespace WebApplicationNet5.Controllers.School
{
    public class GroupController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Group
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groups.Include(g => g.Teacher);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Group/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var group = await _context.Groups
                .Include(g => g.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (group == null) return NotFound();

            return View(group);
        }

        // GET: Group/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers.Where(t => t.Group == null), "Id", "Name");
            return View();
        }

        // POST: Group/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TeacherId")] Group group)
        {
            if (ModelState.IsValid)
            {
                _context.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["TeacherId"] =
                new SelectList(_context.Teachers.Where(t => t.Group == null), "Id", "Name", group.TeacherId);
            return View(group);
        }

        // GET: Group/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var group = await _context.Groups.FindAsync(id);
            if (group == null) return NotFound();
            ViewData["TeacherId"] =
                new SelectList(_context.Teachers.Where(t => t.Group == null), "Id", "Name", group.TeacherId);
            return View(group);
        }

        // POST: Group/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TeacherId")] Group group)
        {
            if (id != group.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["TeacherId"] =
                new SelectList(_context.Teachers.Where(t => t.Group == null), "Id", "Name", group.TeacherId);
            return View(group);
        }

        // GET: Group/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var group = await _context.Groups
                .Include(g => g.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (group == null) return NotFound();

            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}