using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPGzando.DataAccess.Interfaces;
using RPGzando.Models;

namespace RPGzando.Controllers
{
    public class TableGamesController : Controller
    {
        private readonly ITableGameRepository _tableGameRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        //private readonly Context _context;

        public TableGamesController(ITableGameRepository tableGameRepository, IHostingEnvironment hostingEnvironment)
        {
            _tableGameRepository = tableGameRepository;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tableGameRepository.CatchAll().ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableGameId,Title,DateCreated,DateInitial,TableDuration,System,DescriptionGame,Theme,QuantityPeople,LinkDiscord,Photo,Presential,Address1,Address2,Latitude,Longitude")] TableGame tableGame, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    using (FileStream fileStream =
                        new FileStream(Path.Combine(linkUpload, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);

                        tableGame.Photo = "~/Images/" + file.FileName;
                    }
                }

                await _tableGameRepository.Insert(tableGame);
                return RedirectToAction(nameof(Index));
            }
            return View(tableGame);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var tableGame = await _tableGameRepository.PickUpById(id);
            if (tableGame == null)
            {
                return NotFound();
            }

            TempData["PhotoTable"] = tableGame.Photo;

            return View(tableGame);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TableGameId,Title,DateCreated,DateInitial,TableDuration,System,DescriptionGame,Theme,QuantityPeople,LinkDiscord,Photo,Presential,Address1,Address2,Latitude,Longitude")] TableGame tableGame, IFormFile file)
        {
            if (id != tableGame.TableGameId)
            {
                return NotFound();
            }

            tableGame.Photo = TempData["PhotoTable"].ToString();
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var linkUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    using (FileStream fileStream =
                        new FileStream(Path.Combine(linkUpload, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);

                        tableGame.Photo = "~/Images/" + file.FileName;
                    }

                }
                else tableGame.Photo = TempData["PhotoTable"].ToString();

                await _tableGameRepository.Update(tableGame);

                return RedirectToAction(nameof(Index));
            }
            return View(tableGame);
        }


        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var tableGame = await _tableGameRepository.PickUpById(id);
            string photoTable = tableGame.Photo;
            photoTable = photoTable.Replace("~", "wwwroot");
            System.IO.File.Delete(photoTable);


            await _tableGameRepository.Delete(id);
            return Json("Excluded Table");
        }
    }
}
