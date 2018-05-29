using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Mlijekomat
    {
        public Mlijekomat()
        {
            ZamjenaSpremnika = new HashSet<ZamjenaSpremnika>();
        }

        public long Id { get; set; }
        public long VlasnikId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string LokalniNaziv { get; set; }
        public double VelicinaSpremnika { get; set; }
        public double Trosak { get; set; }

        public Vlasnik Vlasnik { get; set; }
        public ICollection<ZamjenaSpremnika> ZamjenaSpremnika { get; set; }
    }
}
