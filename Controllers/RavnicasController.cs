using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace WebApplication2.Controllers
{
    public class RavnicasController : Controller
    {
        private readonly PI_06Context _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public RavnicasController(IHttpContextAccessor httpContextAccessor, PI_06Context context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Ravnicas
        public async Task<IActionResult> Index()
        {
            var pI_06Context = _context.Ravnica.Include(r => r.Vlasnik);
            return View(await pI_06Context.ToListAsync());
        }

        // GET: Ravnicas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ravnica = await _context.Ravnica
                .Include(r => r.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ravnica == null)
            {
                return NotFound();
            }

            return View(ravnica);
        }

        // GET: Ravnicas/Create
        public IActionResult Create()
        {
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id");
            return View();
        }

        // POST: Ravnicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LokalniNaziv,Lat,Lng,Duzina,Sirina,KategorizacijaZemlje,Zasadjena,VlasnikId")] Ravnica ravnica)
        {
            if (ModelState.IsValid)
            {
                ravnica.VlasnikId = (int)HttpContext.Session.GetInt32("user_id");
                _context.Add(ravnica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", ravnica.VlasnikId);
            return View(ravnica);
        }

        // GET: Ravnicas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ravnica = await _context.Ravnica.SingleOrDefaultAsync(m => m.Id == id);
            if (ravnica == null)
            {
                return NotFound();
            }
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", ravnica.VlasnikId);
            return View(ravnica);
        }

        // POST: Ravnicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,LokalniNaziv,Lat,Lng,Duzina,Sirina,KategorizacijaZemlje,Zasadjena,VlasnikId")] Ravnica ravnica)
        {
            if (id != ravnica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ravnica.VlasnikId = (int)HttpContext.Session.GetInt32("user_id");
                    _context.Update(ravnica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RavnicaExists(ravnica.Id))
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
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", ravnica.VlasnikId);
            return View(ravnica);
        }

        // GET: Ravnicas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ravnica = await _context.Ravnica
                .Include(r => r.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ravnica == null)
            {
                return NotFound();
            }

            return View(ravnica);
        }

        // POST: Ravnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ravnica = await _context.Ravnica.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ravnica.Remove(ravnica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RavnicaExists(long id)
        {
            return _context.Ravnica.Any(e => e.Id == id);
        }
    }
}
