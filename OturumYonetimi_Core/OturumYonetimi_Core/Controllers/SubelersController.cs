using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OturumYonetimi_Core.Data;
using OturumYonetimi_Core.Models;

namespace OturumYonetimi_Core.Controllers
{
    [Authorize]  /* Bu, bu controllerin şifrelendiği anlamına gelir.
                    Controllera kullanıcı adı ve şifre ile giriş yapmayan
                    hiçkimsenin erişemeyecğini anlatır. */
    public class SubelersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubelersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subelers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Subelers.ToListAsync());
        }

        // GET: Subelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subeler = await _context.Subelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subeler == null)
            {
                return NotFound();
            }

            return View(subeler);
        }

        // GET: Subelers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subelers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubeAdi,Adres,CalisanSayisi")] Subeler subeler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subeler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subeler);
        }

        // GET: Subelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subeler = await _context.Subelers.FindAsync(id);
            if (subeler == null)
            {
                return NotFound();
            }
            return View(subeler);
        }

        // POST: Subelers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubeAdi,Adres,CalisanSayisi")] Subeler subeler)
        {
            if (id != subeler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subeler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubelerExists(subeler.Id))
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
            return View(subeler);
        }

        // GET: Subelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subeler = await _context.Subelers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subeler == null)
            {
                return NotFound();
            }

            return View(subeler);
        }

        // POST: Subelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subeler = await _context.Subelers.FindAsync(id);
            if (subeler != null)
            {
                _context.Subelers.Remove(subeler);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubelerExists(int id)
        {
            return _context.Subelers.Any(e => e.Id == id);
        }
    }
}
