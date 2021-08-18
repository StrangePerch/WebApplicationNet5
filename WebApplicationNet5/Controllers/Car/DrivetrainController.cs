using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationNet5.Data;
using WebApplicationNet5.Entities.Car;

namespace WebApplicationNet5.Controllers.Car
{
    public class DrivetrainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DrivetrainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Drivetrain
        public async Task<IActionResult> Index()
        {
            return View(await _context.Drivetrains.ToListAsync());
        }

        // GET: Drivetrain/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drivetrain = await _context.Drivetrains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivetrain == null)
            {
                return NotFound();
            }

            return View(drivetrain);
        }

        // GET: Drivetrain/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivetrain/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Drivetrain drivetrain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drivetrain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drivetrain);
        }

        // GET: Drivetrain/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drivetrain = await _context.Drivetrains.FindAsync(id);
            if (drivetrain == null)
            {
                return NotFound();
            }
            return View(drivetrain);
        }

        // POST: Drivetrain/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Drivetrain drivetrain)
        {
            if (id != drivetrain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drivetrain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrivetrainExists(drivetrain.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(drivetrain);
        }

        // GET: Drivetrain/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drivetrain = await _context.Drivetrains
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drivetrain == null)
            {
                return NotFound();
            }

            return View(drivetrain);
        }

        // POST: Drivetrain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var drivetrain = await _context.Drivetrains.FindAsync(id);
            _context.Drivetrains.Remove(drivetrain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrivetrainExists(int id)
        {
            return _context.Drivetrains.Any(e => e.Id == id);
        }
    }
}
