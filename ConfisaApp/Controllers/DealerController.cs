using ConfisaApp.Data;
using ConfisaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ConfisaApp.Controllers
{
    [Authorize]
    public class DealerController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DealerController(ApplicationDbContext dbContext) => _dbContext = dbContext;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dealerList = new List<Dealer>();
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (User.IsInRole("Admin"))
                 dealerList = await _dbContext.Dealers.Include("Oficial").ToListAsync();
            else
                dealerList = await _dbContext.Dealers.Include("Oficial").Where(d => d.Email == userEmail).ToListAsync();

            return View(dealerList);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create() 
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (_dbContext.Dealers.SingleOrDefault(d => d.Email == userEmail) is not null || User.IsInRole("Admin"))
                return RedirectToAction(nameof(Index));

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dealer dealer)
        {
            var userEmail = User.FindFirstValue(ClaimTypes.Email);

            if (_dbContext.Dealers.SingleOrDefault(d => d.Email == userEmail) is not null || User.IsInRole("Admin"))
                return RedirectToAction(nameof(Index));

            if (!ModelState.IsValid || dealer is null)
                return View();

            dealer.Email = userEmail;

            await _dbContext.Dealers.AddAsync(dealer);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles ="Admin")] //con rol
        [HttpGet]
        public async Task<IActionResult> Activar(int id)
        {
            var dbDealer = await _dbContext.Dealers.FirstOrDefaultAsync(o => o.Id == id);

            if (dbDealer is null)
                return RedirectToAction(nameof(Index));

            var dealerViewModel = new DealerViewModel
            {
                Dealer = dbDealer,
                Oficiales = new SelectList(_dbContext.Oficiales.ToList(), "Id", "Nombre")
            };

            return View(dealerViewModel);
        }

        [Authorize(Roles = "Admin")] //con rol
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activar(DealerViewModel dealerViewModel)
        {
            var dbDealer = await _dbContext.Dealers.FirstOrDefaultAsync(o => o.Id == dealerViewModel.Dealer.Id);

            if (dbDealer is not null)
            {
                dbDealer.OficialId = dealerViewModel.Dealer.OficialId;
                dbDealer.Activado = true;
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            dealerViewModel.Oficiales = new SelectList(_dbContext.Oficiales.ToList(), "Id", "Nombre");
            return View(dealerViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dbDealer = await _dbContext.Dealers.FirstOrDefaultAsync(o => o.Id == id);

            if (dbDealer is not null)
            {
                _dbContext.Dealers.Remove(dbDealer);
                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
