using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Sadnica
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public double Trosak { get; set; }
        public int Kolicina { get; set; }
        public long? RadnjaId { get; set; }

        public Radnja Radnja { get; set; }
    }
}
