using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProspectRegistration.Models;

namespace ProspectRegistration.Controllers
{
    public class ProspectsController : Controller
    {
        private readonly ProspectDbContext _context;

        public ProspectsController(ProspectDbContext context)
        {
            _context = context;
        }

        // GET: Prospects
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prospects.ToListAsync());
        }

        // GET: Prospects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospect = await _context.Prospects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prospect == null)
            {
                return NotFound();
            }

            return View(prospect);
        }

        // GET: Prospects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prospects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,FirstName,Email,Comment")] Prospect prospect)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prospect);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prospect);
        }

        // GET: Prospects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospect = await _context.Prospects.FindAsync(id);
            if (prospect == null)
            {
                return NotFound();
            }
            return View(prospect);
        }

        // POST: Prospects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FirstName,Email,Comment")] Prospect prospect)
        {
            if (id != prospect.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prospect);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProspectExists(prospect.Id))
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
            return View(prospect);
        }

        // GET: Prospects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prospect = await _context.Prospects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prospect == null)
            {
                return NotFound();
            }

            return View(prospect);
        }

        // POST: Prospects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prospect = await _context.Prospects.FindAsync(id);
            if (prospect != null)
            {
                _context.Prospects.Remove(prospect);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProspectExists(int id)
        {
            return _context.Prospects.Any(e => e.Id == id);
        }
    }
}
