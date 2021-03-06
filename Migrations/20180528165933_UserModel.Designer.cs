﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApplication2.Models;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(PI_06Context))]
    [Migration("20180528165933_UserModel")]
    partial class UserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication2.Models.DobivenaHranaPojedinacne", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Datum")
                        .HasColumnName("datum")
                        .HasColumnType("date");

                    b.Property<double>("Kolicina")
                        .HasColumnName("kolicina");

                    b.Property<long>("ZivotinjaId")
                        .HasColumnName("zivotinja_id");

                    b.HasKey("Id");

                    b.HasIndex("ZivotinjaId");

                    b.ToTable("dobivena_hrana_pojedinacne");
                });

            modelBuilder.Entity("WebApplication2.Models.DobivenaHranaSkupne", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Datum")
                        .HasColumnName("datum")
                        .HasColumnType("date");

                    b.Property<double>("Kolicina")
                        .HasColumnName("kolicina");

                    b.Property<long>("ZivotinjaId")
                        .HasColumnName("zivotinja_id");

                    b.HasKey("Id");

                    b.HasIndex("ZivotinjaId");

                    b.ToTable("dobivena_hrana_skupne");
                });

            modelBuilder.Entity("WebApplication2.Models.Farma", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<double>("Lat")
                        .HasColumnName("lat");

                    b.Property<double>("Lng")
                        .HasColumnName("lng");

                    b.Property<string>("LokalniNaziv")
                        .IsRequired()
                        .HasColumnName("lokalni_naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<long>("VlasnikId")
                        .HasColumnName("vlasnik_id");

                    b.HasKey("Id");

                    b.HasIndex("VlasnikId");

                    b.ToTable("farma");
                });

            modelBuilder.Entity("WebApplication2.Models.KategorijaMehanizacije", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnName("naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("kategorija_mehanizacije");
                });

            modelBuilder.Entity("WebApplication2.Models.Klanje", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Datum")
                        .HasColumnName("datum")
                        .HasColumnType("datetime");

                    b.Property<long>("FarmaId")
                        .HasColumnName("farma_id");

                    b.Property<double>("KolicinaMesa")
                        .HasColumnName("kolicina_mesa");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnName("opis")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<long>("VrstaId")
                        .HasColumnName("vrsta_id");

                    b.HasKey("Id");

                    b.HasIndex("FarmaId");

                    b.HasIndex("VrstaId");

                    b.ToTable("klanje");
                });

            modelBuilder.Entity("WebApplication2.Models.KupljenaHrana", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<double>("Cjena")
                        .HasColumnName("cjena");

                    b.Property<DateTime>("DatumKupovine")
                        .HasColumnName("datum_kupovine")
                        .HasColumnType("date");

                    b.Property<long>("IdVrste")
                        .HasColumnName("id_vrste");

                    b.Property<double>("Kolicina")
                        .HasColumnName("kolicina");

                    b.Property<string>("Prodavac")
                        .IsRequired()
                        .HasColumnName("prodavac")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Proizvodjac")
                        .IsRequired()
                        .HasColumnName("proizvodjac")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("IdVrste");

                    b.ToTable("kupljena_hrana");
                });

            modelBuilder.Entity("WebApplication2.Models.Mehanizacija", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DatumKupnje")
                        .HasColumnName("datum_kupnje")
                        .HasColumnType("date");

                    b.Property<long>("KategorijaId")
                        .HasColumnName("kategorija_id");

                    b.Property<double>("NabavnaCijena")
                        .HasColumnName("nabavna_cijena");

                    b.Property<double>("TrenutnaVrijednost")
                        .HasColumnName("trenutna_vrijednost");

                    b.Property<long>("VlasnikId")
                        .HasColumnName("vlasnik_id");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.HasIndex("VlasnikId");

                    b.ToTable("mehanizacija");
                });

            modelBuilder.Entity("WebApplication2.Models.Mlijekomat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<double>("Lat")
                        .HasColumnName("lat");

                    b.Property<double>("Lng")
                        .HasColumnName("lng");

                    b.Property<string>("LokalniNaziv")
                        .IsRequired()
                        .HasColumnName("lokalni_naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<double>("Trosak")
                        .HasColumnName("trosak");

                    b.Property<double>("VelicinaSpremnika")
                        .HasColumnName("velicina_spremnika");

                    b.Property<long>("VlasnikId")
                        .HasColumnName("vlasnik_id");

                    b.HasKey("Id");

                    b.HasIndex("VlasnikId");

                    b.ToTable("mlijekomat");
                });

            modelBuilder.Entity("WebApplication2.Models.PojedinaZivotinja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DatumKupovine")
                        .HasColumnName("datum_kupovine")
                        .HasColumnType("datetime");

                    b.Property<long>("FarmaId")
                        .HasColumnName("farma_id");

                    b.Property<double>("Trosak")
                        .HasColumnName("trosak");

                    b.Property<long>("VrstaId")
                        .HasColumnName("vrsta_id");

                    b.HasKey("Id");

                    b.HasIndex("FarmaId");

                    b.HasIndex("VrstaId");

                    b.ToTable("pojedina_zivotinja");
                });

            modelBuilder.Entity("WebApplication2.Models.Prirast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnName("datum_vrijeme")
                        .HasColumnType("datetime");

                    b.Property<long>("IdZivotinje")
                        .HasColumnName("id_zivotinje");

                    b.Property<double>("Masa")
                        .HasColumnName("masa");

                    b.HasKey("Id");

                    b.HasIndex("IdZivotinje");

                    b.ToTable("prirast");
                });

            modelBuilder.Entity("WebApplication2.Models.Prodaja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Artikal")
                        .IsRequired()
                        .HasColumnName("artikal")
                        .HasColumnType("text");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnName("datum_vrijeme")
                        .HasColumnType("datetime");

                    b.Property<double>("KolicinaProdanogArtikla")
                        .HasColumnName("kolicina_prodanog_artikla");

                    b.Property<string>("KomentarProdaje")
                        .IsRequired()
                        .HasColumnName("komentar_prodaje")
                        .HasColumnType("text");

                    b.Property<long>("KorisnikId")
                        .HasColumnName("korisnik_id");

                    b.Property<string>("ProdajnoMjesto")
                        .IsRequired()
                        .HasColumnName("prodajno_mjesto")
                        .HasColumnType("text");

                    b.Property<double>("Zarada")
                        .HasColumnName("zarada");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.ToTable("prodaja");
                });

            modelBuilder.Entity("WebApplication2.Models.Radnja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<double?>("Dobit")
                        .HasColumnName("dobit");

                    b.Property<DateTime>("KrajRadnje")
                        .HasColumnName("kraj_radnje")
                        .HasColumnType("datetime");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnName("naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<DateTime>("PocetakRadnje")
                        .HasColumnName("pocetak_radnje")
                        .HasColumnType("datetime");

                    b.Property<long>("RavnicaId")
                        .HasColumnName("ravnica_id");

                    b.Property<double?>("Trosak")
                        .HasColumnName("trosak");

                    b.HasKey("Id");

                    b.HasIndex("RavnicaId");

                    b.ToTable("radnja");
                });

            modelBuilder.Entity("WebApplication2.Models.RadZaDrugoga", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnName("datum_vrijeme")
                        .HasColumnType("datetime");

                    b.Property<long>("MehanizacijaId")
                        .HasColumnName("mehanizacija_id");

                    b.Property<double>("TrajanjeRadnje")
                        .HasColumnName("trajanje_radnje");

                    b.Property<double>("Zarada")
                        .HasColumnName("zarada");

                    b.HasKey("Id");

                    b.HasIndex("MehanizacijaId");

                    b.ToTable("rad_za_drugoga");
                });

            modelBuilder.Entity("WebApplication2.Models.Ravnica", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<double>("Duzina")
                        .HasColumnName("duzina");

                    b.Property<string>("KategorizacijaZemlje")
                        .IsRequired()
                        .HasColumnName("kategorizacija_zemlje")
                        .HasColumnType("text");

                    b.Property<double>("Lat")
                        .HasColumnName("lat");

                    b.Property<double>("Lng")
                        .HasColumnName("lng");

                    b.Property<string>("LokalniNaziv")
                        .IsRequired()
                        .HasColumnName("lokalni_naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<double>("Sirina")
                        .HasColumnName("sirina");

                    b.Property<long>("VlasnikId")
                        .HasColumnName("vlasnik_id");

                    b.Property<bool>("Zasadjena")
                        .HasColumnName("zasadjena");

                    b.HasKey("Id");

                    b.HasIndex("VlasnikId");

                    b.ToTable("ravnica");
                });

            modelBuilder.Entity("WebApplication2.Models.Sadnica", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("Kolicina")
                        .HasColumnName("kolicina");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnName("naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<long?>("RadnjaId")
                        .HasColumnName("radnja_id");

                    b.Property<double>("Trosak")
                        .HasColumnName("trosak");

                    b.HasKey("Id");

                    b.HasIndex("RadnjaId");

                    b.ToTable("sadnica");
                });

            modelBuilder.Entity("WebApplication2.Models.SkupinaZivotinja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<long>("FarmaId")
                        .HasColumnName("farma_id");

                    b.Property<long>("Kolicina")
                        .HasColumnName("kolicina");

                    b.Property<double>("Trosak")
                        .HasColumnName("trosak");

                    b.Property<long?>("VrstaId")
                        .HasColumnName("vrsta_id");

                    b.HasKey("Id");

                    b.HasIndex("FarmaId");

                    b.HasIndex("VrstaId");

                    b.ToTable("skupina_zivotinja");
                });

            modelBuilder.Entity("WebApplication2.Models.Trošak", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<double?>("Cijena")
                        .HasColumnName("cijena");

                    b.Property<DateTime>("Datum")
                        .HasColumnName("datum")
                        .HasColumnType("date");

                    b.Property<long>("MehanizacijaId")
                        .HasColumnName("mehanizacija_id");

                    b.Property<string>("OpisTroska")
                        .IsRequired()
                        .HasColumnName("opis_troska")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MehanizacijaId");

                    b.ToTable("trošak");
                });

            modelBuilder.Entity("WebApplication2.Models.UpotrabaFarma", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnName("datum_vrijeme")
                        .HasColumnType("datetime");

                    b.Property<long>("FarmaId")
                        .HasColumnName("farma_id");

                    b.Property<long>("MehanizacijaId")
                        .HasColumnName("mehanizacija_id");

                    b.HasKey("Id");

                    b.HasIndex("FarmaId");

                    b.HasIndex("MehanizacijaId");

                    b.ToTable("upotraba_farma");
                });

            modelBuilder.Entity("WebApplication2.Models.UpotrabaOranica", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("DatumVrijeme")
                        .HasColumnName("datum_vrijeme")
                        .HasColumnType("datetime");

                    b.Property<long>("MehanizacijaId")
                        .HasColumnName("mehanizacija_id");

                    b.Property<long>("OranicaId")
                        .HasColumnName("oranica_id");

                    b.HasKey("Id");

                    b.HasIndex("MehanizacijaId");

                    b.ToTable("upotraba_oranica");
                });

            modelBuilder.Entity("WebApplication2.Models.VeterinarskiPregled", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Datum")
                        .HasColumnName("datum")
                        .HasColumnType("date");

                    b.Property<double>("Trosak")
                        .HasColumnName("trosak");

                    b.Property<long>("ZivotinjaId")
                        .HasColumnName("zivotinja_id");

                    b.HasKey("Id");

                    b.HasIndex("ZivotinjaId");

                    b.ToTable("veterinarski_pregled");
                });

            modelBuilder.Entity("WebApplication2.Models.Vlasnik", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Ime")
                        .HasColumnName("ime")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Naziv")
                        .HasColumnName("naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<string>("Prezime")
                        .HasColumnName("prezime")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool>("Udruga")
                        .HasColumnName("udruga");

                    b.Property<string>("korisnickoIme");

                    b.Property<string>("lozinka");

                    b.HasKey("Id");

                    b.ToTable("vlasnik");
                });

            modelBuilder.Entity("WebApplication2.Models.Vrsta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnName("naziv")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("vrsta");
                });

            modelBuilder.Entity("WebApplication2.Models.ZamjenaSpremnika", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Datum")
                        .HasColumnName("datum")
                        .HasColumnType("date");

                    b.Property<long>("MlijekomatId")
                        .HasColumnName("mlijekomat_id");

                    b.Property<double>("Ostatak")
                        .HasColumnName("ostatak");

                    b.Property<string>("Razlog")
                        .IsRequired()
                        .HasColumnName("razlog")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MlijekomatId");

                    b.ToTable("zamjena_spremnika");
                });

            modelBuilder.Entity("WebApplication2.Models.DobivenaHranaPojedinacne", b =>
                {
                    b.HasOne("WebApplication2.Models.PojedinaZivotinja", "Zivotinja")
                        .WithMany("DobivenaHranaPojedinacne")
                        .HasForeignKey("ZivotinjaId")
                        .HasConstraintName("dobivena_hrana_pojedinacne_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.DobivenaHranaSkupne", b =>
                {
                    b.HasOne("WebApplication2.Models.SkupinaZivotinja", "Zivotinja")
                        .WithMany("DobivenaHranaSkupne")
                        .HasForeignKey("ZivotinjaId")
                        .HasConstraintName("dobivena_hrana_skupne_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Farma", b =>
                {
                    b.HasOne("WebApplication2.Models.Vlasnik", "Vlasnik")
                        .WithMany("Farma")
                        .HasForeignKey("VlasnikId")
                        .HasConstraintName("farma_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Klanje", b =>
                {
                    b.HasOne("WebApplication2.Models.Farma", "Farma")
                        .WithMany("Klanje")
                        .HasForeignKey("FarmaId")
                        .HasConstraintName("klanje_fk0");

                    b.HasOne("WebApplication2.Models.Vrsta", "Vrsta")
                        .WithMany("Klanje")
                        .HasForeignKey("VrstaId")
                        .HasConstraintName("klanje_fk1");
                });

            modelBuilder.Entity("WebApplication2.Models.KupljenaHrana", b =>
                {
                    b.HasOne("WebApplication2.Models.Vrsta", "IdVrsteNavigation")
                        .WithMany("KupljenaHrana")
                        .HasForeignKey("IdVrste")
                        .HasConstraintName("kupljena_hrana_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Mehanizacija", b =>
                {
                    b.HasOne("WebApplication2.Models.KategorijaMehanizacije", "Kategorija")
                        .WithMany("Mehanizacija")
                        .HasForeignKey("KategorijaId")
                        .HasConstraintName("mehanizacija_fk1");

                    b.HasOne("WebApplication2.Models.Vlasnik", "Vlasnik")
                        .WithMany("Mehanizacija")
                        .HasForeignKey("VlasnikId")
                        .HasConstraintName("mehanizacija_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Mlijekomat", b =>
                {
                    b.HasOne("WebApplication2.Models.Vlasnik", "Vlasnik")
                        .WithMany("Mlijekomat")
                        .HasForeignKey("VlasnikId")
                        .HasConstraintName("mlijekomat_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.PojedinaZivotinja", b =>
                {
                    b.HasOne("WebApplication2.Models.Farma", "Farma")
                        .WithMany("PojedinaZivotinja")
                        .HasForeignKey("FarmaId")
                        .HasConstraintName("pojedina_zivotinja_fk1");

                    b.HasOne("WebApplication2.Models.Vrsta", "Vrsta")
                        .WithMany("PojedinaZivotinja")
                        .HasForeignKey("VrstaId")
                        .HasConstraintName("pojedina_zivotinja_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Prirast", b =>
                {
                    b.HasOne("WebApplication2.Models.PojedinaZivotinja", "IdZivotinjeNavigation")
                        .WithMany("Prirast")
                        .HasForeignKey("IdZivotinje")
                        .HasConstraintName("prirast_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Prodaja", b =>
                {
                    b.HasOne("WebApplication2.Models.Vlasnik", "Korisnik")
                        .WithMany("Prodaja")
                        .HasForeignKey("KorisnikId")
                        .HasConstraintName("prodaja_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Radnja", b =>
                {
                    b.HasOne("WebApplication2.Models.Ravnica", "Ravnica")
                        .WithMany("Radnja")
                        .HasForeignKey("RavnicaId")
                        .HasConstraintName("radnja_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.RadZaDrugoga", b =>
                {
                    b.HasOne("WebApplication2.Models.Mehanizacija", "Mehanizacija")
                        .WithMany("RadZaDrugoga")
                        .HasForeignKey("MehanizacijaId")
                        .HasConstraintName("rad_za_drugoga_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Ravnica", b =>
                {
                    b.HasOne("WebApplication2.Models.Vlasnik", "Vlasnik")
                        .WithMany("Ravnica")
                        .HasForeignKey("VlasnikId")
                        .HasConstraintName("ravnica_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Sadnica", b =>
                {
                    b.HasOne("WebApplication2.Models.Radnja", "Radnja")
                        .WithMany("Sadnica")
                        .HasForeignKey("RadnjaId")
                        .HasConstraintName("sadnica_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.SkupinaZivotinja", b =>
                {
                    b.HasOne("WebApplication2.Models.Farma", "Farma")
                        .WithMany("SkupinaZivotinja")
                        .HasForeignKey("FarmaId")
                        .HasConstraintName("skupina_zivotinja_fk1");

                    b.HasOne("WebApplication2.Models.Vrsta", "Vrsta")
                        .WithMany("SkupinaZivotinja")
                        .HasForeignKey("VrstaId")
                        .HasConstraintName("skupina_zivotinja_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.Trošak", b =>
                {
                    b.HasOne("WebApplication2.Models.Mehanizacija", "Mehanizacija")
                        .WithMany("Trošak")
                        .HasForeignKey("MehanizacijaId")
                        .HasConstraintName("trošak_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.UpotrabaFarma", b =>
                {
                    b.HasOne("WebApplication2.Models.Farma", "Farma")
                        .WithMany("UpotrabaFarma")
                        .HasForeignKey("FarmaId")
                        .HasConstraintName("upotraba_farma_fk1");

                    b.HasOne("WebApplication2.Models.Mehanizacija", "Mehanizacija")
                        .WithMany("UpotrabaFarma")
                        .HasForeignKey("MehanizacijaId")
                        .HasConstraintName("upotraba_farma_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.UpotrabaOranica", b =>
                {
                    b.HasOne("WebApplication2.Models.Mehanizacija", "Mehanizacija")
                        .WithMany("UpotrabaOranica")
                        .HasForeignKey("MehanizacijaId")
                        .HasConstraintName("upotraba_oranica_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.VeterinarskiPregled", b =>
                {
                    b.HasOne("WebApplication2.Models.PojedinaZivotinja", "Zivotinja")
                        .WithMany("VeterinarskiPregled")
                        .HasForeignKey("ZivotinjaId")
                        .HasConstraintName("veterinarski_pregled_fk0");
                });

            modelBuilder.Entity("WebApplication2.Models.ZamjenaSpremnika", b =>
                {
                    b.HasOne("WebApplication2.Models.Mlijekomat", "Mlijekomat")
                        .WithMany("ZamjenaSpremnika")
                        .HasForeignKey("MlijekomatId")
                        .HasConstraintName("zamjena_spremnika_fk0");
                });
#pragma warning restore 612, 618
        }
    }
}
