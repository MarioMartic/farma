using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace WebApplication2.Controllers
{
    public class MlijekomatsController : Controller
    {
        private readonly PI_06Context _context;

        public MlijekomatsController(PI_06Context context)
        {
            _context = context;
        }

        // GET: Mlijekomats
        public async Task<IActionResult> Index()
        {
            var pI_06Context = _context.Mlijekomat.Include(m => m.Vlasnik);
            return View(await pI_06Context.ToListAsync());
        }

        // GET: Mlijekomats/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mlijekomat = await _context.Mlijekomat
                .Include(m => m.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mlijekomat == null)
            {
                return NotFound();
            }

            return View(mlijekomat);
        }

        // GET: Mlijekomats/Create
        public IActionResult Create()
        {
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id");
            return View();
        }

        // POST: Mlijekomats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VlasnikId,Lat,Lng,LokalniNaziv,VelicinaSpremnika,Trosak")] Mlijekomat mlijekomat)
        {
            if (ModelState.IsValid)
            {
                mlijekomat.VlasnikId = (int)HttpContext.Session.GetInt32("user_id");
                _context.Add(mlijekomat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", mlijekomat.VlasnikId);
            return View(mlijekomat);
        }

        // GET: Mlijekomats/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mlijekomat = await _context.Mlijekomat.SingleOrDefaultAsync(m => m.Id == id);
            if (mlijekomat == null)
            {
                return NotFound();
            }
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", mlijekomat.VlasnikId);
            return View(mlijekomat);
        }

        // POST: Mlijekomats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,VlasnikId,Lat,Lng,LokalniNaziv,VelicinaSpremnika,Trosak")] Mlijekomat mlijekomat)
        {
            if (id != mlijekomat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mlijekomat.VlasnikId = (int)HttpContext.Session.GetInt32("user_id");
                    _context.Update(mlijekomat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MlijekomatExists(mlijekomat.Id))
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
            ViewData["VlasnikId"] = new SelectList(_context.Vlasnik, "Id", "Id", mlijekomat.VlasnikId);
            return View(mlijekomat);
        }

        // GET: Mlijekomats/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mlijekomat = await _context.Mlijekomat
                .Include(m => m.Vlasnik)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mlijekomat == null)
            {
                return NotFound();
            }

            return View(mlijekomat);
        }

        // POST: Mlijekomats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var mlijekomat = await _context.Mlijekomat.SingleOrDefaultAsync(m => m.Id == id);
            _context.Mlijekomat.Remove(mlijekomat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MlijekomatExists(long id)
        {
            return _context.Mlijekomat.Any(e => e.Id == id);
        }
    }
}
