using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Prodaja
    {
        public long Id { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public double Zarada { get; set; }
        public string ProdajnoMjesto { get; set; }
        public string KomentarProdaje { get; set; }
        public string Artikal { get; set; }
        public double KolicinaProdanogArtikla { get; set; }
        public long KorisnikId { get; set; }

        public Vlasnik Korisnik { get; set; }
    }
}
