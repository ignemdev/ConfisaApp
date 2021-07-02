using ConfisaApp.Data;
using ConfisaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfisaApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OficialController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public OficialController(ApplicationDbContext dbContext) => _dbContext = dbContext;

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var oficialesList = await _dbContext.Oficiales.ToListAsync();
            return View(oficialesList);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Oficial oficial)
        {
            if (!ModelState.IsValid || oficial is null)
                return View();

            await _dbContext.Oficiales.AddAsync(oficial);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var dbOficial = await _dbContext.Oficiales.FirstOrDefaultAsync(o => o.Id == id);

            if(dbOficial is null)
                return RedirectToAction(nameof(Index));

            return View(dbOficial);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Oficial oficial)
        {
            var dbOficial = await _dbContext.Oficiales.FirstOrDefaultAsync(o => o.Id == oficial.Id);

            if(ModelState.IsValid && oficial is not null)
            {
                dbOficial.Nombre = oficial.Nombre;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(oficial);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dbOficial = await _dbContext.Oficiales.FirstOrDefaultAsync(o => o.Id == id);
            
            if(dbOficial is not null)
            {
                _dbContext.Oficiales.Remove(dbOficial);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
