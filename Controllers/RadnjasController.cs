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
    public class RadnjasController : Controller
    {
        private readonly PI_06Context _context;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public RadnjasController(IHttpContextAccessor httpContextAccessor, PI_06Context context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Radnjas
        public async Task<IActionResult> Index(string sortOrder)
        {


            var pI_06Context = _context.Radnja.Include(r => r.Ravnica);
            return View(await pI_06Context.ToListAsync());
        }

        // GET: Radnjas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var radnja = await _context.Radnja
                .Include(r => r.Ravnica)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (radnja == null)
            {
                return NotFound();
            }

            return View(radnja);
        }

        // GET: Radnjas/Create
        public IActionResult Create()
        {
            if (_session.GetString("username") != null)
            {

                ViewData["RavnicaId"] = new SelectList(_context.Ravnica.Where(d => d.VlasnikId.Equals((int)_session.GetInt32("user_id"))).Where(d => d.Zasadjena == false), "Id", "LokalniNaziv");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: Radnjas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Trosak,Dobit,PocetakRadnje,KrajRadnje,RavnicaId")] Radnja radnja)
        {

            if (ModelState.IsValid)
            {
                _context.Add(radnja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RavnicaId"] = new SelectList(_context.Ravnica, "Id", "LokalniNaziv", radnja.RavnicaId);
            return View(radnja);
        }


        // GET: Radnjas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (_session.GetString("username") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var radnja = await _context.Radnja.SingleOrDefaultAsync(m => m.Id == id);
                if (radnja == null)
                {
                    return NotFound();
                }
                ViewData["RavnicaId"] = new SelectList(_context.Ravnica.Where(d => d.VlasnikId.Equals((int)_session.GetInt32("user_id"))).Where(d => d.Zasadjena == false), "Id", "LokalniNaziv", radnja.RavnicaId);
                return View(radnja);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: Radnjas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Naziv,Trosak,Dobit,PocetakRadnje,KrajRadnje,RavnicaId")] Radnja radnja)
        {




            if (id != radnja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(radnja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RadnjaExists(radnja.Id))
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
            ViewData["RavnicaId"] = new SelectList(_context.Ravnica, "Id", "LokalniNaziv", radnja.RavnicaId);
            return View(radnja);


        }

        // GET: Radnjas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (_session.GetString("username") != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var radnja = await _context.Radnja
                    .Include(r => r.Ravnica)
                    .SingleOrDefaultAsync(m => m.Id == id);
                if (radnja == null)
                {
                    return NotFound();
                }

                return View(radnja);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: Radnjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var radnja = await _context.Radnja.SingleOrDefaultAsync(m => m.Id == id);
            _context.Radnja.Remove(radnja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RadnjaExists(long id)
        {
            return _context.Radnja.Any(e => e.Id == id);
        }

        public ActionResult Moje_radnje(string sortOrder)
        {
            if (_session.GetString("username") != null)
            {

                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                var radnja = from r in _context.Radnja
                             select r;
                //var radnje = _context.Radnja;
                List<Radnja> rad = new List<Radnja>();

                switch (sortOrder)
                {
                    case "name_desc":
                        radnja = radnja.OrderByDescending(r => r.Naziv);
                        break;
                    default:
                        radnja = radnja.OrderBy(r => r.Naziv);
                        break;
                }
                foreach (Radnja f in radnja)
                {
                    var rav = _context.Ravnica.SingleOrDefault(m => m.Id == f.RavnicaId);
                    if (rav.VlasnikId.Equals((int)_session.GetInt32("user_id")))
                    {
                        rad.Add(f);
                    }
                }

                return View(rad.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
