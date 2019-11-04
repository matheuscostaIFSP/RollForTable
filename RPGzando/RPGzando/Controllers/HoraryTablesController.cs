using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPGzando.Models;

namespace RPGzando.Controllers
{
    public class HoraryTablesController : Controller
    {
        private readonly Context _context;

        public HoraryTablesController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var context = _context.HoraryTable.Include(h => h.TableGame);
            return View(await context.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["TableGameId"] = new SelectList(_context.TableGames, "TableGameId", "DescriptionGame");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HoraryTableId,DateAvailableTable,HoraryTableInitial,HoraryTableFinal,TableGameId")] HoraryTable horaryTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horaryTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TableGameId"] = new SelectList(_context.TableGames, "TableGameId", "DescriptionGame", horaryTable.TableGameId);
            return View(horaryTable);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaryTable = await _context.HoraryTable.FindAsync(id);
            if (horaryTable == null)
            {
                return NotFound();
            }
            ViewData["TableGameId"] = new SelectList(_context.TableGames, "TableGameId", "DescriptionGame", horaryTable.TableGameId);
            return View(horaryTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HoraryTableId,DateAvailableTable,HoraryTableInitial,HoraryTableFinal,TableGameId")] HoraryTable horaryTable)
        {
            if (id != horaryTable.HoraryTableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horaryTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoraryTableExists(horaryTable.HoraryTableId))
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
            ViewData["TableGameId"] = new SelectList(_context.TableGames, "TableGameId", "DescriptionGame", horaryTable.TableGameId);
            return View(horaryTable);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horaryTable = await _context.HoraryTable
                .Include(h => h.TableGame)
                .FirstOrDefaultAsync(m => m.HoraryTableId == id);
            if (horaryTable == null)
            {
                return NotFound();
            }

            return View(horaryTable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var horaryTable = await _context.HoraryTable.FindAsync(id);
            _context.HoraryTable.Remove(horaryTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoraryTableExists(int id)
        {
            return _context.HoraryTable.Any(e => e.HoraryTableId == id);
        }
    }
}
