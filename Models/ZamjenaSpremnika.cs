using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class ZamjenaSpremnika
    {
        public long Id { get; set; }
        public DateTime Datum { get; set; }
        public string Razlog { get; set; }
        public double Ostatak { get; set; }
        public long MlijekomatId { get; set; }

        public Mlijekomat Mlijekomat { get; set; }
    }
}
