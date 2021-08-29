using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationNet5.Data;
using WebApplicationNet5.Entities.Catalog;

namespace WebApplicationNet5.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catalog
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Catalogs.Include(c => c.ParentCatalog);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Catalog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var catalog = await _context.Catalogs
                .Include(c => c.ParentCatalog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalog == null) return NotFound();

            return View(catalog);
        }

        // GET: Catalog/Create
        public IActionResult Create()
        {
            ViewData["ParentCatalogId"] = new SelectList(_context.Catalogs, "Id", "Name");
            return View();
        }

        // POST: Catalog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ParentCatalogId")] Catalog catalog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catalog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ParentCatalogId"] = new SelectList(_context.Catalogs, "Id", "Name", catalog.ParentCatalogId);
            return View(catalog);
        }

        // GET: Catalog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog == null) return NotFound();
            ViewData["ParentCatalogId"] = new SelectList(_context.Catalogs, "Id", "Name", catalog.ParentCatalogId);
            return View(catalog);
        }

        // POST: Catalog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ParentCatalogId")] Catalog catalog)
        {
            if (id != catalog.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalogExists(catalog.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["ParentCatalogId"] = new SelectList(_context.Catalogs, "Id", "Name", catalog.ParentCatalogId);
            return View(catalog);
        }

        // GET: Catalog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var catalog = await _context.Catalogs
                .Include(c => c.ParentCatalog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (catalog == null) return NotFound();

            return View(catalog);
        }

        // POST: Catalog/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            _context.Catalogs.Remove(catalog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalogExists(int id)
        {
            return _context.Catalogs.Any(e => e.Id == id);
        }
    }
}