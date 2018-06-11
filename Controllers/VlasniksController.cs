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
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            var vlasnik = from v in _context.Vlasnik
                          select v;
            switch (sortOrder)
            {
                case "name_desc":
                    vlasnik = vlasnik.OrderByDescending(v => v.korisnickoIme);
                    break;
                default:
                    vlasnik = vlasnik.OrderBy(v => v.korisnickoIme);
                    break;
            }
            return View(vlasnik.ToList());
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

        // POST: Vlasniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id,Ime,korisnickoIme,lozinka,Prezime,Naziv,Udruga")] Vlasnik vlasnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vlasnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            return View("Index","Home");
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
                    var farme = _context.Farma.Include(f => f.Vlasnik);
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

        public ActionResult moji_mljekomati()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                var mljekomat = _context.Mlijekomat.Include(m => m.Vlasnik);
                List<Mlijekomat> lista_mljek = new List<Mlijekomat>();
                foreach (Mlijekomat ml in mljekomat)
                {
                    if (ml.VlasnikId.Equals((int)HttpContext.Session.GetInt32("user_id")))
                    {
                        lista_mljek.Add(ml);
                    }
                }
                return View(lista_mljek.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Moje_ravnice()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                var ravnica = _context.Ravnica.Include(r => r.Vlasnik);
                List<Ravnica> lista_rav = new List<Ravnica>();
                foreach (Ravnica r in ravnica)
                {
                    if (r.VlasnikId.Equals((int)HttpContext.Session.GetInt32("user_id")))
                    {
                        lista_rav.Add(r);
                    }
                }
                return View(lista_rav.ToList());
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult moje_mehanizacije()
        {
            if (HttpContext.Session.GetString("username") != null)
            {
                var mehanizacija = _context.Mehanizacija.Include(m => m.Kategorija).Include(m => m.Vlasnik);
                List<Mehanizacija> lista_meh = new List<Mehanizacija>();
                foreach (Mehanizacija meh in mehanizacija)
                {
                    if (meh.VlasnikId.Equals((int)HttpContext.Session.GetInt32("user_id")))
                    {
                        lista_meh.Add(meh);
                    }
                }
                return View(lista_meh.ToList());
            }
            return RedirectToAction("Index", "Home");
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
                HttpContext.Session.SetString("username", vlasnik.korisnickoIme);
                return RedirectToAction("Index", "Home");
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
            //brisemo korisnika
            var vlasnik = await _context.Vlasnik.SingleOrDefaultAsync(m => m.Id == id);
            _context.Vlasnik.Remove(vlasnik);

            //brisanje sve njegove farme
            var farme = _context.Farma;
            foreach (Farma f in farme)
            {
                if (f.VlasnikId==vlasnik.Id)
                {
                    _context.Farma.Remove(f);
                }
            }

            //brisanje sve njegove mljekomate
            var mlijeko = _context.Mlijekomat;
            foreach (Mlijekomat m in mlijeko)
            {
                if (m.VlasnikId == vlasnik.Id)
                {
                    _context.Mlijekomat.Remove(m);
                }
            }

            var meha = _context.Mehanizacija;
            foreach (Mehanizacija m in meha)
            {
                if (m.VlasnikId == vlasnik.Id)
                {
                    _context.Mehanizacija.Remove(m);
                }
            }

            //brisemo sve njegove ravnice
            var ravnice = _context.Ravnica;
            foreach (Ravnica r in ravnice)
            {
                if (r.VlasnikId == vlasnik.Id)
                {
                    _context.Ravnica.Remove(r);
                }
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Login));
        }

        private bool VlasnikExists(long id)
        {
            return _context.Vlasnik.Any(e => e.Id == id);
        }
    }
}
