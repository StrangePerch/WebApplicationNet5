using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationNet5.Data;

namespace WebApplicationNet5.Controllers.Car
{
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Car
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cars.Include(c => c.Drivetrain).Include(c => c.Model);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Car/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars
                .Include(c => c.Drivetrain)
                .Include(c => c.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();

            return View(car);
        }

        // GET: Car/Create
        public IActionResult Create()
        {
            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "Id", "Name");
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name");
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DrivetrainId,ModelId")] Entities.Car.Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "Id", "Name", car.DrivetrainId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", car.ModelId);
            return View(car);
        }

        // GET: Car/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();
            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "Id", "Name", car.DrivetrainId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", car.ModelId);
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DrivetrainId,ModelId")] Entities.Car.Car car)
        {
            if (id != car.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["DrivetrainId"] = new SelectList(_context.Drivetrains, "Id", "Name", car.DrivetrainId);
            ViewData["ModelId"] = new SelectList(_context.Models, "Id", "Name", car.ModelId);
            return View(car);
        }

        // GET: Car/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var car = await _context.Cars
                .Include(c => c.Drivetrain)
                .Include(c => c.Model)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null) return NotFound();

            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}