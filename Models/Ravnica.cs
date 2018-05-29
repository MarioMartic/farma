using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Ravnica
    {
        public Ravnica()
        {
            Radnja = new HashSet<Radnja>();
        }

        public long Id { get; set; }
        public string LokalniNaziv { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Duzina { get; set; }
        public double Sirina { get; set; }
        public string KategorizacijaZemlje { get; set; }
        public bool Zasadjena { get; set; }
        public long VlasnikId { get; set; }

        public Vlasnik Vlasnik { get; set; }
        public ICollection<Radnja> Radnja { get; set; }
    }
}
