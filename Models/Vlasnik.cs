using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Vlasnik
    {
        public Vlasnik()
        {
            Farma = new HashSet<Farma>();
            Mehanizacija = new HashSet<Mehanizacija>();
            Mlijekomat = new HashSet<Mlijekomat>();
            Prodaja = new HashSet<Prodaja>();
            Ravnica = new HashSet<Ravnica>();
        }

        public long Id { get; set; }
        public string Ime { get; set; }
        public string korisnickoIme { get; set; }
        public string lozinka { get; set; }
        public string Prezime { get; set; }
        public string Naziv { get; set; }
        public bool Udruga { get; set; }

        public ICollection<Farma> Farma { get; set; }
        public ICollection<Mehanizacija> Mehanizacija { get; set; }
        public ICollection<Mlijekomat> Mlijekomat { get; set; }
        public ICollection<Prodaja> Prodaja { get; set; }
        public ICollection<Ravnica> Ravnica { get; set; }
    }
}
