using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;
using System.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace WebApplication2.Controllers
{
    public class VlasniksController : Controller
    {
        private readonly PI_06Context _context;

        public VlasniksController(PI_06Context context)
        {
            _context = context;
        }

        // GET: Vlasniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vlasnik.ToListAsync());
        }

        // GET: Vlasniks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlasnik = await _context.Vlasnik
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vlasnik == null)
            {
                return NotFound();
            }

            return View(vlasnik);
        }

        // GET: Vlasniks/Create
        public IActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Vlasnik vlasnik)
        {
            var userLoggedIn = _context.Vlasnik.SingleOrDefault(x => x.korisnickoIme == vlasnik.korisnickoIme && x.lozinka == vlasnik.lozinka);

            if (userLoggedIn != null)
            {
                ViewBag.message = "LoggedIn";
                ViewBag.triedOnce = "yes";

                HttpContext.Session.SetString("username", vlasnik.korisnickoIme);
                HttpContext.Session.SetInt32("user_id", (int)userLoggedIn.Id);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.triedOnce = "yes";
                return View();
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }


        public ActionResult Moje_farme()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                    var farme = _context.Farma;
                    List<Farma> far = new List<Farma>();
                    foreach (Farma f in farme)
                    {
                        if (f.VlasnikId.Equals((int)HttpContext.Session.GetInt32("user_id")))
                        {
                            far.Add(f);
                        }
                    }
                    return View(far.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Vlasniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,korisnickoIme,lozinka,Prezime,Naziv,Udruga")] Vlasnik vlasnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vlasnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vlasnik);
        }

        // GET: Vlasniks/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlasnik = await _context.Vlasnik.SingleOrDefaultAsync(m => m.Id == id);
            if (vlasnik == null)
            {
                return NotFound();
            }
            return View(vlasnik);
        }

        // POST: Vlasniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Ime,korisnickoIme,lozinka,Prezime,Naziv,Udruga")] Vlasnik vlasnik)
        {
            if (id != vlasnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vlasnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VlasnikExists(vlasnik.Id))
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
            return View(vlasnik);
        }

        // GET: Vlasniks/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vlasnik = await _context.Vlasnik
                .SingleOrDefaultAsync(m => m.Id == id);
            if (vlasnik == null)
            {
                return NotFound();
            }

            return View(vlasnik);
        }

        // POST: Vlasniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var vlasnik = await _context.Vlasnik.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vlasnik.Remove(vlasnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VlasnikExists(long id)
        {
            return _context.Vlasnik.Any(e => e.Id == id);
        }
    }
}
