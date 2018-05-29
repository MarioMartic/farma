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
    public class FarmasController : Controller
    {
        private readonly PI_06Context _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
       

        public FarmasController(IHttpContextAccessor httpContextAccessor, PI_06Context context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Farmas
        public async Task<IActionResult> Index()
        {
            var pI_06Context = _context.Farma.Include(f => f.Vlasnik);
            return View(await pI_06Context.ToListAsync());
        }

        // GET: Farmas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farma = await _context.Farma
                .Include(f => f.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (farma == null)
            {
                return NotFound();
            }

            return View(farma);
        }

        // GET: Farmas/Create
        public IActionResult Create()
        {
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id");
            return View();
        }

        // POST: Farmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LokalniNaziv,Lat,Lng")] Farma farma)
        {
            if (ModelState.IsValid)
            {
                farma.VlasnikId = (int)HttpContext.Session.GetInt32("user_id");
                _context.Add(farma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", farma.VlasnikId);
            return View(farma);
        }

        // GET: Farmas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farma = await _context.Farma.SingleOrDefaultAsync(m => m.Id == id);
            if (farma == null)
            {
                return NotFound();
            }
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", farma.VlasnikId);
            return View(farma);
        }

        // POST: Farmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,LokalniNaziv,Lat,Lng,VlasnikId")] Farma farma)
        {
            if (id != farma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaExists(farma.Id))
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
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", farma.VlasnikId);
            return View(farma);
        }

        // GET: Farmas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var farma = await _context.Farma
                .Include(f => f.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (farma == null)
            {
                return NotFound();
            }

            return View(farma);
        }

        // POST: Farmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var farma = await _context.Farma.SingleOrDefaultAsync(m => m.Id == id);
            _context.Farma.Remove(farma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaExists(long id)
        {
            return _context.Farma.Any(e => e.Id == id);
        }
    }
}
