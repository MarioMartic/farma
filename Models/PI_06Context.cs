using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WebApplication2.Models
{
    public partial class PI_06Context : DbContext
    {
        public virtual DbSet<DobivenaHranaPojedinacne> DobivenaHranaPojedinacne { get; set; }
        public virtual DbSet<DobivenaHranaSkupne> DobivenaHranaSkupne { get; set; }
        public virtual DbSet<Farma> Farma { get; set; }
        public virtual DbSet<KategorijaMehanizacije> KategorijaMehanizacije { get; set; }
        public virtual DbSet<Klanje> Klanje { get; set; }
        public virtual DbSet<KupljenaHrana> KupljenaHrana { get; set; }
        public virtual DbSet<Mehanizacija> Mehanizacija { get; set; }
        public virtual DbSet<Mlijekomat> Mlijekomat { get; set; }
        public virtual DbSet<PojedinaZivotinja> PojedinaZivotinja { get; set; }
        public virtual DbSet<Prirast> Prirast { get; set; }
        public virtual DbSet<Prodaja> Prodaja { get; set; }
        public virtual DbSet<Radnja> Radnja { get; set; }
        public virtual DbSet<RadZaDrugoga> RadZaDrugoga { get; set; }
        public virtual DbSet<Ravnica> Ravnica { get; set; }
        public virtual DbSet<Sadnica> Sadnica { get; set; }
        public virtual DbSet<SkupinaZivotinja> SkupinaZivotinja { get; set; }
        public virtual DbSet<Trošak> Trošak { get; set; }
        public virtual DbSet<UpotrabaFarma> UpotrabaFarma { get; set; }
        public virtual DbSet<UpotrabaOranica> UpotrabaOranica { get; set; }
        public virtual DbSet<VeterinarskiPregled> VeterinarskiPregled { get; set; }
        public virtual DbSet<Vlasnik> Vlasnik { get; set; }
        public virtual DbSet<Vrsta> Vrsta { get; set; }
        public virtual DbSet<ZamjenaSpremnika> ZamjenaSpremnika { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                      .AddUserSecrets("Farma")
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json")
                      .Build();
            string connString = config["ConnectionStrings:FarmaDatabase"];
            optionsBuilder.UseSqlServer(connString);
        }

        public PI_06Context(DbContextOptions<PI_06Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DobivenaHranaPojedinacne>(entity =>
            {
                entity.ToTable("dobivena_hrana_pojedinacne");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.ZivotinjaId).HasColumnName("zivotinja_id");

                entity.HasOne(d => d.Zivotinja)
                    .WithMany(p => p.DobivenaHranaPojedinacne)
                    .HasForeignKey(d => d.ZivotinjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dobivena_hrana_pojedinacne_fk0");
            });

            modelBuilder.Entity<DobivenaHranaSkupne>(entity =>
            {
                entity.ToTable("dobivena_hrana_skupne");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.ZivotinjaId).HasColumnName("zivotinja_id");

                entity.HasOne(d => d.Zivotinja)
                    .WithMany(p => p.DobivenaHranaSkupne)
                    .HasForeignKey(d => d.ZivotinjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dobivena_hrana_skupne_fk0");
            });

            modelBuilder.Entity<Farma>(entity =>
            {
                entity.ToTable("farma");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.LokalniNaziv)
                    .IsRequired()
                    .HasColumnName("lokalni_naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VlasnikId).HasColumnName("vlasnik_id");

                entity.HasOne(d => d.Vlasnik)
                    .WithMany(p => p.Farma)
                    .HasForeignKey(d => d.VlasnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("farma_fk0");
            });

            modelBuilder.Entity<KategorijaMehanizacije>(entity =>
            {
                entity.ToTable("kategorija_mehanizacije");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Klanje>(entity =>
            {
                entity.ToTable("klanje");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("datetime");

                entity.Property(e => e.FarmaId).HasColumnName("farma_id");

                entity.Property(e => e.KolicinaMesa).HasColumnName("kolicina_mesa");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VrstaId).HasColumnName("vrsta_id");

                entity.HasOne(d => d.Farma)
                    .WithMany(p => p.Klanje)
                    .HasForeignKey(d => d.FarmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("klanje_fk0");

                entity.HasOne(d => d.Vrsta)
                    .WithMany(p => p.Klanje)
                    .HasForeignKey(d => d.VrstaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("klanje_fk1");
            });

            modelBuilder.Entity<KupljenaHrana>(entity =>
            {
                entity.ToTable("kupljena_hrana");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cjena).HasColumnName("cjena");

                entity.Property(e => e.DatumKupovine)
                    .HasColumnName("datum_kupovine")
                    .HasColumnType("date");

                entity.Property(e => e.IdVrste).HasColumnName("id_vrste");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.Prodavac)
                    .IsRequired()
                    .HasColumnName("prodavac")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Proizvodjac)
                    .IsRequired()
                    .HasColumnName("proizvodjac")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdVrsteNavigation)
                    .WithMany(p => p.KupljenaHrana)
                    .HasForeignKey(d => d.IdVrste)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kupljena_hrana_fk0");
            });

            modelBuilder.Entity<Mehanizacija>(entity =>
            {
                entity.ToTable("mehanizacija");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumKupnje)
                    .HasColumnName("datum_kupnje")
                    .HasColumnType("date");

                entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");

                entity.Property(e => e.NabavnaCijena).HasColumnName("nabavna_cijena");

                entity.Property(e => e.TrenutnaVrijednost).HasColumnName("trenutna_vrijednost");

                entity.Property(e => e.VlasnikId).HasColumnName("vlasnik_id");

                entity.HasOne(d => d.Kategorija)
                    .WithMany(p => p.Mehanizacija)
                    .HasForeignKey(d => d.KategorijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mehanizacija_fk1");

                entity.HasOne(d => d.Vlasnik)
                    .WithMany(p => p.Mehanizacija)
                    .HasForeignKey(d => d.VlasnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mehanizacija_fk0");
            });

            modelBuilder.Entity<Mlijekomat>(entity =>
            {
                entity.ToTable("mlijekomat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.LokalniNaziv)
                    .IsRequired()
                    .HasColumnName("lokalni_naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Trosak).HasColumnName("trosak");

                entity.Property(e => e.VelicinaSpremnika).HasColumnName("velicina_spremnika");

                entity.Property(e => e.VlasnikId).HasColumnName("vlasnik_id");

                entity.HasOne(d => d.Vlasnik)
                    .WithMany(p => p.Mlijekomat)
                    .HasForeignKey(d => d.VlasnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mlijekomat_fk0");
            });

            modelBuilder.Entity<PojedinaZivotinja>(entity =>
            {
                entity.ToTable("pojedina_zivotinja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumKupovine)
                    .HasColumnName("datum_kupovine")
                    .HasColumnType("datetime");

                entity.Property(e => e.FarmaId).HasColumnName("farma_id");

                entity.Property(e => e.Trosak).HasColumnName("trosak");

                entity.Property(e => e.VrstaId).HasColumnName("vrsta_id");

                entity.HasOne(d => d.Farma)
                    .WithMany(p => p.PojedinaZivotinja)
                    .HasForeignKey(d => d.FarmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pojedina_zivotinja_fk1");

                entity.HasOne(d => d.Vrsta)
                    .WithMany(p => p.PojedinaZivotinja)
                    .HasForeignKey(d => d.VrstaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pojedina_zivotinja_fk0");
            });

            modelBuilder.Entity<Prirast>(entity =>
            {
                entity.ToTable("prirast");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumVrijeme)
                    .HasColumnName("datum_vrijeme")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdZivotinje).HasColumnName("id_zivotinje");

                entity.Property(e => e.Masa).HasColumnName("masa");

                entity.HasOne(d => d.IdZivotinjeNavigation)
                    .WithMany(p => p.Prirast)
                    .HasForeignKey(d => d.IdZivotinje)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prirast_fk0");
            });

            modelBuilder.Entity<Prodaja>(entity =>
            {
                entity.ToTable("prodaja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Artikal)
                    .IsRequired()
                    .HasColumnName("artikal")
                    .HasColumnType("text");

                entity.Property(e => e.DatumVrijeme)
                    .HasColumnName("datum_vrijeme")
                    .HasColumnType("datetime");

                entity.Property(e => e.KolicinaProdanogArtikla).HasColumnName("kolicina_prodanog_artikla");

                entity.Property(e => e.KomentarProdaje)
                    .IsRequired()
                    .HasColumnName("komentar_prodaje")
                    .HasColumnType("text");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.ProdajnoMjesto)
                    .IsRequired()
                    .HasColumnName("prodajno_mjesto")
                    .HasColumnType("text");

                entity.Property(e => e.Zarada).HasColumnName("zarada");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Prodaja)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prodaja_fk0");
            });

            modelBuilder.Entity<Radnja>(entity =>
            {
                entity.ToTable("radnja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dobit).HasColumnName("dobit");

                entity.Property(e => e.KrajRadnje)
                    .HasColumnName("kraj_radnje")
                    .HasColumnType("datetime");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PocetakRadnje)
                    .HasColumnName("pocetak_radnje")
                    .HasColumnType("datetime");

                entity.Property(e => e.RavnicaId).HasColumnName("ravnica_id");

                entity.Property(e => e.Trosak).HasColumnName("trosak");

                entity.HasOne(d => d.Ravnica)
                    .WithMany(p => p.Radnja)
                    .HasForeignKey(d => d.RavnicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("radnja_fk0");
            });

            modelBuilder.Entity<RadZaDrugoga>(entity =>
            {
                entity.ToTable("rad_za_drugoga");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumVrijeme)
                    .HasColumnName("datum_vrijeme")
                    .HasColumnType("datetime");

                entity.Property(e => e.MehanizacijaId).HasColumnName("mehanizacija_id");

                entity.Property(e => e.TrajanjeRadnje).HasColumnName("trajanje_radnje");

                entity.Property(e => e.Zarada).HasColumnName("zarada");

                entity.HasOne(d => d.Mehanizacija)
                    .WithMany(p => p.RadZaDrugoga)
                    .HasForeignKey(d => d.MehanizacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rad_za_drugoga_fk0");
            });

            modelBuilder.Entity<Ravnica>(entity =>
            {
                entity.ToTable("ravnica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Duzina).HasColumnName("duzina");

                entity.Property(e => e.KategorizacijaZemlje)
                    .IsRequired()
                    .HasColumnName("kategorizacija_zemlje")
                    .HasColumnType("text");

                entity.Property(e => e.Lat).HasColumnName("lat");

                entity.Property(e => e.Lng).HasColumnName("lng");

                entity.Property(e => e.LokalniNaziv)
                    .IsRequired()
                    .HasColumnName("lokalni_naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sirina).HasColumnName("sirina");

                entity.Property(e => e.VlasnikId).HasColumnName("vlasnik_id");

                entity.Property(e => e.Zasadjena).HasColumnName("zasadjena");

                entity.HasOne(d => d.Vlasnik)
                    .WithMany(p => p.Ravnica)
                    .HasForeignKey(d => d.VlasnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ravnica_fk0");
            });

            modelBuilder.Entity<Sadnica>(entity =>
            {
                entity.ToTable("sadnica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RadnjaId).HasColumnName("radnja_id");

                entity.Property(e => e.Trosak).HasColumnName("trosak");

                entity.HasOne(d => d.Radnja)
                    .WithMany(p => p.Sadnica)
                    .HasForeignKey(d => d.RadnjaId)
                    .HasConstraintName("sadnica_fk0");
            });

            modelBuilder.Entity<SkupinaZivotinja>(entity =>
            {
                entity.ToTable("skupina_zivotinja");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FarmaId).HasColumnName("farma_id");

                entity.Property(e => e.Kolicina).HasColumnName("kolicina");

                entity.Property(e => e.Trosak).HasColumnName("trosak");

                entity.Property(e => e.VrstaId).HasColumnName("vrsta_id");

                entity.HasOne(d => d.Farma)
                    .WithMany(p => p.SkupinaZivotinja)
                    .HasForeignKey(d => d.FarmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("skupina_zivotinja_fk1");

                entity.HasOne(d => d.Vrsta)
                    .WithMany(p => p.SkupinaZivotinja)
                    .HasForeignKey(d => d.VrstaId)
                    .HasConstraintName("skupina_zivotinja_fk0");
            });

            modelBuilder.Entity<Trošak>(entity =>
            {
                entity.ToTable("trošak");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cijena).HasColumnName("cijena");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.MehanizacijaId).HasColumnName("mehanizacija_id");

                entity.Property(e => e.OpisTroska)
                    .IsRequired()
                    .HasColumnName("opis_troska")
                    .HasColumnType("text");

                entity.HasOne(d => d.Mehanizacija)
                    .WithMany(p => p.Trošak)
                    .HasForeignKey(d => d.MehanizacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("trošak_fk0");
            });

            modelBuilder.Entity<UpotrabaFarma>(entity =>
            {
                entity.ToTable("upotraba_farma");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumVrijeme)
                    .HasColumnName("datum_vrijeme")
                    .HasColumnType("datetime");

                entity.Property(e => e.FarmaId).HasColumnName("farma_id");

                entity.Property(e => e.MehanizacijaId).HasColumnName("mehanizacija_id");

                entity.HasOne(d => d.Farma)
                    .WithMany(p => p.UpotrabaFarma)
                    .HasForeignKey(d => d.FarmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("upotraba_farma_fk1");

                entity.HasOne(d => d.Mehanizacija)
                    .WithMany(p => p.UpotrabaFarma)
                    .HasForeignKey(d => d.MehanizacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("upotraba_farma_fk0");
            });

            modelBuilder.Entity<UpotrabaOranica>(entity =>
            {
                entity.ToTable("upotraba_oranica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DatumVrijeme)
                    .HasColumnName("datum_vrijeme")
                    .HasColumnType("datetime");

                entity.Property(e => e.MehanizacijaId).HasColumnName("mehanizacija_id");

                entity.Property(e => e.OranicaId).HasColumnName("oranica_id");

                entity.HasOne(d => d.Mehanizacija)
                    .WithMany(p => p.UpotrabaOranica)
                    .HasForeignKey(d => d.MehanizacijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("upotraba_oranica_fk0");
            });

            modelBuilder.Entity<VeterinarskiPregled>(entity =>
            {
                entity.ToTable("veterinarski_pregled");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.Trosak).HasColumnName("trosak");

                entity.Property(e => e.ZivotinjaId).HasColumnName("zivotinja_id");

                entity.HasOne(d => d.Zivotinja)
                    .WithMany(p => p.VeterinarskiPregled)
                    .HasForeignKey(d => d.ZivotinjaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("veterinarski_pregled_fk0");
            });

            modelBuilder.Entity<Vlasnik>(entity =>
            {
                entity.ToTable("vlasnik");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Udruga).HasColumnName("udruga");
            });

            modelBuilder.Entity<Vrsta>(entity =>
            {
                entity.ToTable("vrsta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ZamjenaSpremnika>(entity =>
            {
                entity.ToTable("zamjena_spremnika");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.MlijekomatId).HasColumnName("mlijekomat_id");

                entity.Property(e => e.Ostatak).HasColumnName("ostatak");

                entity.Property(e => e.Razlog)
                    .IsRequired()
                    .HasColumnName("razlog")
                    .HasColumnType("text");

                entity.HasOne(d => d.Mlijekomat)
                    .WithMany(p => p.ZamjenaSpremnika)
                    .HasForeignKey(d => d.MlijekomatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zamjena_spremnika_fk0");
            });
        }
    }
}
