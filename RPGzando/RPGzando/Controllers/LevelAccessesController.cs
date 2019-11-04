using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.Controllers
{
    public class LevelAccessesController : Controller
    {
        private readonly ILevelAccessRepository _levelAccessRepository;
        
        public LevelAccessesController(ILevelAccessRepository levelAccessRepository)
        {
            _levelAccessRepository = levelAccessRepository;
        }

        // GET: LevelAccesses
        public async Task<IActionResult> Index()
        {
            return View(await _levelAccessRepository.CatchAll().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Name")] LevelAccesses levelAccesses)
        {
            if (ModelState.IsValid)
            {
                bool levelExist = await _levelAccessRepository.LevelAccessExist(levelAccesses.Name);

                if (!levelExist)
                {
                    levelAccesses.NormalizedName = levelAccesses.Name.ToUpper();
                    await _levelAccessRepository.Insert(levelAccesses);

                    return RedirectToAction("Index", "LevelAccesses");
                }
            }
            return View(levelAccesses);
        }

        // GET: LevelAccesses/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var levelAccesses = await _levelAccessRepository.PickUpById(id);
            if (levelAccesses == null)
            {
                return NotFound();
            }
            return View(levelAccesses);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Description,Name")] LevelAccesses levelAccesses)
        {
            if (id != levelAccesses.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _levelAccessRepository.Update(levelAccesses);
                return RedirectToAction("Index", "LevelAccesses");

            }                          
            return View(levelAccesses);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            await _levelAccessRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
