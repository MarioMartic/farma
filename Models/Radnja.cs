using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Radnja
    {
        public Radnja()
        {
            Sadnica = new HashSet<Sadnica>();
        }

        public long Id { get; set; }
        public string Naziv { get; set; }
        public double? Trosak { get; set; }
        public double? Dobit { get; set; }
        public DateTime PocetakRadnje { get; set; }
        public DateTime KrajRadnje { get; set; }
        public long RavnicaId { get; set; }

        public Ravnica Ravnica { get; set; }
        public ICollection<Sadnica> Sadnica { get; set; }
    }
}
