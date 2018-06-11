using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MehanizacijasController : Controller
    {
        private readonly PI_06Context _context;

        public MehanizacijasController(PI_06Context context)
        {
            _context = context;
        }

        // GET: Mehanizacijas
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var meha = from f in _context.Mehanizacija.Include(f => f.Vlasnik).Include(f => f.Kategorija)
                       select f;
            switch (sortOrder)
            {
                case "name_desc":
                    meha = meha.OrderByDescending(f => f.Kategorija.Naziv);
                    break;
                default:
                    meha = meha.OrderBy(f => f.Kategorija.Naziv);
                    break;
            }
            return View(meha.ToList());
        }

        // GET: Mehanizacijas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mehanizacija = await _context.Mehanizacija
                .Include(m => m.Kategorija)
                .Include(m => m.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mehanizacija == null)
            {
                return NotFound();
            }

            return View(mehanizacija);
        }

        // GET: Mehanizacijas/Create
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_context.KategorijaMehanizacije, "Id", "Naziv");
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id");
            return View();
        }

        // POST: Mehanizacijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NabavnaCijena,DatumKupnje,VlasnikId,KategorijaId,TrenutnaVrijednost")] Mehanizacija mehanizacija)
        {
            if (ModelState.IsValid)
            {
                mehanizacija.VlasnikId = (int)HttpContext.Session.GetInt32("user_id");
                _context.Add(mehanizacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaId"] = new SelectList(_context.KategorijaMehanizacije, "Id", "Naziv", mehanizacija.KategorijaId);
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", mehanizacija.VlasnikId);
            return View(mehanizacija);
        }

        // GET: Mehanizacijas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mehanizacija = await _context.Mehanizacija.SingleOrDefaultAsync(m => m.Id == id);
            if (mehanizacija == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_context.KategorijaMehanizacije, "Id", "Naziv", mehanizacija.KategorijaId);
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", mehanizacija.VlasnikId);
            return View(mehanizacija);
        }

        // POST: Mehanizacijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NabavnaCijena,DatumKupnje,VlasnikId,KategorijaId,TrenutnaVrijednost")] Mehanizacija mehanizacija)
        {
            if (id != mehanizacija.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mehanizacija.VlasnikId = (int)HttpContext.Session.GetInt32("user_id");
                    _context.Update(mehanizacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MehanizacijaExists(mehanizacija.Id))
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
            ViewData["KategorijaId"] = new SelectList(_context.KategorijaMehanizacije, "Id", "Naziv", mehanizacija.KategorijaId);
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", mehanizacija.VlasnikId);
            return View(mehanizacija);
        }

        // GET: Mehanizacijas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mehanizacija = await _context.Mehanizacija
                .Include(m => m.Kategorija)
                .Include(m => m.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mehanizacija == null)
            {
                return NotFound();
            }

            return View(mehanizacija);
        }

        // POST: Mehanizacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mehanizacija = await _context.Mehanizacija.SingleOrDefaultAsync(m => m.Id == id);
            _context.Mehanizacija.Remove(mehanizacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MehanizacijaExists(long id)
        {
            return _context.Mehanizacija.Any(e => e.Id == id);
        }
    }
}
