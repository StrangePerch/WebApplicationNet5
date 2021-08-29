using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationNet5.Data;
using WebApplicationNet5.Entities.Post;

namespace WebApplicationNet5.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posts
                .Include(m => m.Category)
                .ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var post = await _context.Posts
                .Include(m => m.Category)
                .Include(p => p.Tags)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null) return NotFound();

            return View(post);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewBag.Tags = new SelectList(_context.Tags, "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // ReSharper disable once InconsistentNaming
        public async Task<IActionResult> Create([Bind("Id,Title,Slug")] Post post, int Category, int[] Tags)
        {
            if (!ModelState.IsValid) return View(post);

            post.Category = await _context.Categories.FindAsync(Category);
            post.Tags = _context.Tags.Where(t => Tags.Contains(t.Id)).ToList();
            _context.Attach(post.Category);
            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var post = await _context.Posts
                .Include(m => m.Category)
                .Include(m => m.Tags)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null) return NotFound();

            ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", post.Category.Id);
            ViewBag.Tags = new MultiSelectList(_context.Tags, "Id", "Name", post.Tags.Select(t => t.Id).ToList());
            ViewBag.PostTags = post.Tags;

            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Slug")] Post post, int Category, int[] Tags)
        {
            if (id != post.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    post.Category = await _context.Categories.FindAsync(Category);
                    post.Tags = _context.Tags.Where(t => Tags.Contains(t.Id)).ToList();
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null) return NotFound();

            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}