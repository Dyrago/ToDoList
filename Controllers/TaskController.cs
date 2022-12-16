using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList1.Data;
using ToDoList1.Models;

namespace ToDoList1.Controllers
{
    public class TaskController : Controller
    {
        private readonly ToDoList1Context _context;

        public TaskController(ToDoList1Context context)
        {
            _context = context;
        }

        // GET: Task
        public async Task<IActionResult> Index()
        {
              return View(await _context.TaskViewModel.ToListAsync());
        }

        // GET: Task/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskViewModel == null)
            {
                return NotFound();
            }

            var taskViewModel = await _context.TaskViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskViewModel == null)
            {
                return NotFound();
            }

            return View(taskViewModel);
        }

        // GET: Task/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,Status,ToDoDate")] TaskViewModel taskViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskViewModel);
        }

        // GET: Task/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskViewModel == null)
            {
                return NotFound();
            }

            var taskViewModel = await _context.TaskViewModel.FindAsync(id);
            if (taskViewModel == null)
            {
                return NotFound();
            }
            return View(taskViewModel);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Content,Status,ToDoDate")] TaskViewModel taskViewModel)
        {
            if (id != taskViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskViewModelExists(taskViewModel.Id))
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
            return View(taskViewModel);
        }

        // GET: Task/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskViewModel == null)
            {
                return NotFound();
            }

            var taskViewModel = await _context.TaskViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskViewModel == null)
            {
                return NotFound();
            }

            return View(taskViewModel);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskViewModel == null)
            {
                return Problem("Entity set 'ToDoList1Context.TaskViewModel'  is null.");
            }
            var taskViewModel = await _context.TaskViewModel.FindAsync(id);
            if (taskViewModel != null)
            {
                _context.TaskViewModel.Remove(taskViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskViewModelExists(int id)
        {
          return _context.TaskViewModel.Any(e => e.Id == id);
        }
    }
}
