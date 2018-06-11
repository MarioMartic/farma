using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SkupinaZivotinjasController : Controller
    {
        private readonly PI_06Context _context;

        public SkupinaZivotinjasController(PI_06Context context)
        {
            _context = context;
        }

        // GET: SkupinaZivotinjas
        public async Task<IActionResult> Index()
        {
            var pI_06Context = _context.SkupinaZivotinja.Include(s => s.Farma).Include(s => s.Vrsta);
            return View(await pI_06Context.ToListAsync());
        }

        // GET: SkupinaZivotinjas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skupinaZivotinja = await _context.SkupinaZivotinja
                .Include(s => s.Farma)
                .Include(s => s.Vrsta)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (skupinaZivotinja == null)
            {
                return NotFound();
            }

            return View(skupinaZivotinja);
        }

        // GET: SkupinaZivotinjas/Create
        public IActionResult Create(long ?id)
        {
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv");

            var farme = _context.Farma.Include(f => f.Vlasnik);
            List<Farma> far = new List<Farma>();
            foreach (Farma f in farme)
            {
                if (f.Id.Equals(id))
                {
                    far.Add(f);
                }
            }
            ViewData["FarmaId"] = new SelectList(far, "Id", "LokalniNaziv");

            return View();
        }

        // POST: SkupinaZivotinjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VrstaId,Kolicina,FarmaId,Trosak")] SkupinaZivotinja skupinaZivotinja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skupinaZivotinja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FarmaId"] = new SelectList(_context.Farma, "Id", "LokalniNaziv", skupinaZivotinja.FarmaId);
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv", skupinaZivotinja.VrstaId);
            return View(skupinaZivotinja);
        }

        // GET: SkupinaZivotinjas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skupinaZivotinja = await _context.SkupinaZivotinja.SingleOrDefaultAsync(m => m.Id == id);
            if (skupinaZivotinja == null)
            {
                return NotFound();
            }
            ViewData["FarmaId"] = new SelectList(_context.Farma, "Id", "LokalniNaziv", skupinaZivotinja.FarmaId);
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv", skupinaZivotinja.VrstaId);
            return View(skupinaZivotinja);
        }

        // POST: SkupinaZivotinjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,VrstaId,Kolicina,FarmaId,Trosak")] SkupinaZivotinja skupinaZivotinja)
        {
            if (id != skupinaZivotinja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skupinaZivotinja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkupinaZivotinjaExists(skupinaZivotinja.Id))
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
            ViewData["FarmaId"] = new SelectList(_context.Farma, "Id", "LokalniNaziv", skupinaZivotinja.FarmaId);
            ViewData["VrstaId"] = new SelectList(_context.Vrsta, "Id", "Naziv", skupinaZivotinja.VrstaId);
            return View(skupinaZivotinja);
        }

        // GET: SkupinaZivotinjas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skupinaZivotinja = await _context.SkupinaZivotinja
                .Include(s => s.Farma)
                .Include(s => s.Vrsta)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (skupinaZivotinja == null)
            {
                return NotFound();
            }

            return View(skupinaZivotinja);
        }

        // POST: SkupinaZivotinjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var skupinaZivotinja = await _context.SkupinaZivotinja.SingleOrDefaultAsync(m => m.Id == id);
            _context.SkupinaZivotinja.Remove(skupinaZivotinja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkupinaZivotinjaExists(long id)
        {
            return _context.SkupinaZivotinja.Any(e => e.Id == id);
        }
    }
}
