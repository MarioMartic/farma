using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class UpotrabaOranica
    {
        public long Id { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public long MehanizacijaId { get; set; }
        public long OranicaId { get; set; }

        public Mehanizacija Mehanizacija { get; set; }
    }
}
