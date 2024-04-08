using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Complain.Data;
using Complain.Models;

namespace Complaint.Controllers
{
    public class ProblemsController : Controller
    {
        private readonly Db_ComplaintModel _context;

        public ProblemsController(Db_ComplaintModel context)
        {
            _context = context;
        }

        // GET: Problems
        public async Task<IActionResult> Index()
        {
            return View(await _context.Problems.ToListAsync());
        }

        // GET: Problems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .FirstOrDefaultAsync(m => m.ProblemId == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // GET: Problems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProblemId,ProblemName")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(problem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(problem);
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProblemId,ProblemName")] Problem problem)
        {
            if (id != problem.ProblemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.ProblemId))
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
            return View(problem);
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .FirstOrDefaultAsync(m => m.ProblemId == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var problem = await _context.Problems.FindAsync(id);
            if (problem != null)
            {
                _context.Problems.Remove(problem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemExists(string id)
        {
            return _context.Problems.Any(e => e.ProblemId == id);
        }
    }
}
