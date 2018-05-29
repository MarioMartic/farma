using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class KategorijaMehanizacije
    {
        public KategorijaMehanizacije()
        {
            Mehanizacija = new HashSet<Mehanizacija>();
        }

        public long Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Mehanizacija> Mehanizacija { get; set; }
    }
}
