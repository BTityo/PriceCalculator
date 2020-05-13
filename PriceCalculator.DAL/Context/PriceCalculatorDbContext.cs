using Microsoft.EntityFrameworkCore;
using PriceCalculator.DAL.Models;
using PriceCalculator.DAL.Repository;
using System;
using System.IO;

namespace PriceCalculator.DAL.Context
{
    public class PriceCalculatorDbContext : DbContext
    {
        private string databasePath;

        public DbSet<BaseCalculation> BaseCalculations { get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Piece> Pieces { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Thickness> Thicknesses { get; set; }

        public PriceCalculatorDbContext(string databasePath)
        {
            this.databasePath = databasePath;

            if (!File.Exists(databasePath))
            {
                Database.EnsureCreated();

                // Create default Pieces
                for (int i = 1; i < 7; i++)
                {
                    this.Pieces.Add(new Piece { Id = i, Name = i.ToString() + " db", Value = (byte)i });
                }
                // Create default Thicknesses
                this.Thicknesses.Add(new Thickness { Id = 1, Name = "2 cm", Value = 2 });
                this.Thicknesses.Add(new Thickness { Id = 2, Name = "3 cm", Value = 3 });
                this.Thicknesses.Add(new Thickness { Id = 3, Name = "5 cm", Value = 5 });
                this.Thicknesses.Add(new Thickness { Id = 4, Name = "8 cm", Value = 8 });
                this.Thicknesses.Add(new Thickness { Id = 5, Name = "9 cm", Value = 9 });
                this.Thicknesses.Add(new Thickness { Id = 6, Name = "10 cm", Value = 10 });
                // Create default Users
                this.Settings.Add(new Setting { Id = 1, UserName = Environment.UserDomainName + "/" + Environment.UserName, Platform = OsInfo.GetOsInfo(true), IsStartWithWindows = false });
                // Create default Materials
                this.Materials.Add(new Material { Id = 1, Name = "Afrika Red", TwoCM = 33000, ThreeCM = 43000, FiveCM = 63000, EightCM = 93000, NineCM = 0, TenCM = 113000 });
                this.Materials.Add(new Material { Id = 2, Name = "Baltic Brown", TwoCM = 25000, ThreeCM = 32000, FiveCM = 47000, EightCM = 0, NineCM = 0, TenCM = 83000 });
                this.Materials.Add(new Material { Id = 3, Name = "Baltic Green", TwoCM = 36000, ThreeCM = 47000, FiveCM = 69000, EightCM = 0, NineCM = 0, TenCM = 119000 });
                this.Materials.Add(new Material { Id = 4, Name = "Black Pearl", TwoCM = 33000, ThreeCM = 41000, FiveCM = 65000, EightCM = 92000, NineCM = 103000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 5, Name = "Brasilian Gold", TwoCM = 33000, ThreeCM = 43000, FiveCM = 63000, EightCM = 93000, NineCM = 103000, TenCM = 113000 });
                this.Materials.Add(new Material { Id = 6, Name = "Brown Antique", TwoCM = 41000, ThreeCM = 51000, FiveCM = 72000, EightCM = 112000, NineCM = 122000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 7, Name = "Brown Star KT", TwoCM = 13000, ThreeCM = 17000, FiveCM = 27000, EightCM = 40000, NineCM = 45000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 8, Name = "Brown Star NT", TwoCM = 16500, ThreeCM = 22000, FiveCM = 35000, EightCM = 0, NineCM = 61000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 9, Name = "Galaxy Brown KT", TwoCM = 13000, ThreeCM = 17000, FiveCM = 27000, EightCM = 40000, NineCM = 45000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 10, Name = "Galaxy Brown NT", TwoCM = 16500, ThreeCM = 22000, FiveCM = 35000, EightCM = 0, NineCM = 61000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 11, Name = "Carrara CD", TwoCM = 18000, ThreeCM = 26000, FiveCM = 44000, EightCM = 70000, NineCM = 0, TenCM = 83000 });
                this.Materials.Add(new Material { Id = 12, Name = "Cat's Eye", TwoCM = 39000, ThreeCM = 47000, FiveCM = 65000, EightCM = 89000, NineCM = 98000, TenCM = 109000 });
                this.Materials.Add(new Material { Id = 13, Name = "Cielo del Oro", TwoCM = 31000, ThreeCM = 43000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 14, Name = "Coromandel", TwoCM = 27500, ThreeCM = 34000, FiveCM = 46000, EightCM = 74000, NineCM = 84000, TenCM = 91000 });
                this.Materials.Add(new Material { Id = 15, Name = "Coromandel Virgin", TwoCM = 30000, ThreeCM = 37000, FiveCM = 51000, EightCM = 81000, NineCM = 92000, TenCM = 99000 });
                this.Materials.Add(new Material { Id = 16, Name = "Crema Astoria", TwoCM = 30000, ThreeCM = 38000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 17, Name = "Finn Aurora", TwoCM = 48000, ThreeCM = 64000, FiveCM = 95000, EightCM = 144000, NineCM = 0, TenCM = 173000 });
                this.Materials.Add(new Material { Id = 18, Name = "Giallo Atlantide", TwoCM = 17000, ThreeCM = 23000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 19, Name = "Giallo Veneziano", TwoCM = 36000, ThreeCM = 49000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 20, Name = "Grey Beauty (110cm)", TwoCM = 15000, ThreeCM = 22000, FiveCM = 36000, EightCM = 55000, NineCM = 62000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 21, Name = "Himalaya Blue", TwoCM = 26000, ThreeCM = 32000, FiveCM = 46000, EightCM = 66000, NineCM = 81000, TenCM = 93000 });
                this.Materials.Add(new Material { Id = 22, Name = "Himalaya Blue extra", TwoCM = 29000, ThreeCM = 34000, FiveCM = 50000, EightCM = 73000, NineCM = 87000, TenCM = 99000 });
                this.Materials.Add(new Material { Id = 23, Name = "Impala Dark", TwoCM = 25000, ThreeCM = 32000, FiveCM = 48000, EightCM = 72000, NineCM = 80000, TenCM = 91000 });
                this.Materials.Add(new Material { Id = 24, Name = "Imperial Red", TwoCM = 37000, ThreeCM = 44000, FiveCM = 59000, EightCM = 83000, NineCM = 90000, TenCM = 95000 });
                this.Materials.Add(new Material { Id = 25, Name = "Indiai Aurora", TwoCM = 39000, ThreeCM = 46000, FiveCM = 61000, EightCM = 85000, NineCM = 92000, TenCM = 96000 });
                this.Materials.Add(new Material { Id = 26, Name = "Indiai Impala", TwoCM = 26000, ThreeCM = 32000, FiveCM = 45000, EightCM = 63000, NineCM = 70000, TenCM = 80000 });
                this.Materials.Add(new Material { Id = 27, Name = "Ivory Shivakashi", TwoCM = 31000, ThreeCM = 39000, FiveCM = 51000, EightCM = 76000, NineCM = 89000, TenCM = 115000 });
                this.Materials.Add(new Material { Id = 28, Name = "Jet Black", TwoCM = 39000, ThreeCM = 52000, FiveCM = 68000, EightCM = 97000, NineCM = 109000, TenCM = 119000 });
                this.Materials.Add(new Material { Id = 29, Name = "Juparana Colombo", TwoCM = 31000, ThreeCM = 39000, FiveCM = 49000, EightCM = 70000, NineCM = 78000, TenCM = 85000 });
                this.Materials.Add(new Material { Id = 30, Name = "Kashmir Gold", TwoCM = 29000, ThreeCM = 37000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 31, Name = "Kashmir White", TwoCM = 30000, ThreeCM = 38000, FiveCM = 60000, EightCM = 89000, NineCM = 0, TenCM = 108000 });
                this.Materials.Add(new Material { Id = 32, Name = "Kobra KT", TwoCM = 20000, ThreeCM = 26000, FiveCM = 41000, EightCM = 58000, NineCM = 63000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 33, Name = "Kobra NT", TwoCM = 20000, ThreeCM = 26000, FiveCM = 46000, EightCM = 0, NineCM = 75000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 34, Name = "Labrador Blue Extra", TwoCM = 43000, ThreeCM = 57000, FiveCM = 84000, EightCM = 124000, NineCM = 0, TenCM = 149000 });
                this.Materials.Add(new Material { Id = 35, Name = "Labrador Vert", TwoCM = 45000, ThreeCM = 61000, FiveCM = 92000, EightCM = 141000, NineCM = 0, TenCM = 168000 });
                this.Materials.Add(new Material { Id = 36, Name = "Maple Red KT", TwoCM = 17000, ThreeCM = 22000, FiveCM = 33000, EightCM = 48000, NineCM = 54000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 37, Name = "Mountain Pink KT", TwoCM = 13500, ThreeCM = 17500, FiveCM = 27500, EightCM = 41000, NineCM = 46000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 38, Name = "Mountain Pink NT", TwoCM = 16500, ThreeCM = 22000, FiveCM = 35000, EightCM = 0, NineCM = 61000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 39, Name = "Mountain White KT", TwoCM = 13500, ThreeCM = 17500, FiveCM = 27500, EightCM = 41000, NineCM = 46000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 40, Name = "Multicolor Red", TwoCM = 25500, ThreeCM = 30000, FiveCM = 41000, EightCM = 61000, NineCM = 71000, TenCM = 81000 });
                this.Materials.Add(new Material { Id = 41, Name = "Nero Angola", TwoCM = 35000, ThreeCM = 46000, FiveCM = 67000, EightCM = 99000, NineCM = 0, TenCM = 119000 });
                this.Materials.Add(new Material { Id = 42, Name = "Nero Marquina", TwoCM = 30000, ThreeCM = 40000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 43, Name = "Olive Green", TwoCM = 34000, ThreeCM = 44000, FiveCM = 64000, EightCM = 96000, NineCM = 101000, TenCM = 110000 });
                this.Materials.Add(new Material { Id = 44, Name = "Paradiso", TwoCM = 25500, ThreeCM = 32000, FiveCM = 44000, EightCM = 69000, NineCM = 79000, TenCM = 88000 });
                this.Materials.Add(new Material { Id = 45, Name = "Picasso", TwoCM = 52000, ThreeCM = 58000, FiveCM = 83000, EightCM = 123000, NineCM = 133000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 46, Name = "River White", TwoCM = 26000, ThreeCM = 33000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 47, Name = "Rosa Beta", TwoCM = 16500, ThreeCM = 22000, FiveCM = 35000, EightCM = 0, NineCM = 61000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 48, Name = "Rosa Porrino", TwoCM = 16500, ThreeCM = 22000, FiveCM = 35000, EightCM = 0, NineCM = 61000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 49, Name = "Silver Matrix", TwoCM = 41000, ThreeCM = 51000, FiveCM = 72000, EightCM = 112000, NineCM = 122000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 50, Name = "Silver Paradiso", TwoCM = 32000, ThreeCM = 41000, FiveCM = 65000, EightCM = 92000, NineCM = 103000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 51, Name = "Star Galaxy", TwoCM = 38000, ThreeCM = 50000, FiveCM = 66000, EightCM = 95000, NineCM = 107000, TenCM = 117000 });
                this.Materials.Add(new Material { Id = 52, Name = "Steel Grey", TwoCM = 29000, ThreeCM = 33000, FiveCM = 44000, EightCM = 62000, NineCM = 67000, TenCM = 72000 });
                this.Materials.Add(new Material { Id = 53, Name = "Talila Grey KT", TwoCM = 13500, ThreeCM = 17500, FiveCM = 27500, EightCM = 41000, NineCM = 46000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 54, Name = "Talila Grey NT", TwoCM = 16500, ThreeCM = 22000, FiveCM = 35000, EightCM = 0, NineCM = 61000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 55, Name = "Tan Brown", TwoCM = 30000, ThreeCM = 38000, FiveCM = 51000, EightCM = 67000, NineCM = 77000, TenCM = 95000 });
                this.Materials.Add(new Material { Id = 56, Name = "Tarn", TwoCM = 16500, ThreeCM = 22000, FiveCM = 35000, EightCM = 0, NineCM = 61000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 57, Name = "Vanga Red", TwoCM = 45000, ThreeCM = 52000, FiveCM = 77000, EightCM = 112000, NineCM = 125000, TenCM = 135000 });
                this.Materials.Add(new Material { Id = 58, Name = "Verde Bahia", TwoCM = 37000, ThreeCM = 48000, FiveCM = 71000, EightCM = 0, NineCM = 116000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 59, Name = "Verde Marina", TwoCM = 28500, ThreeCM = 34500, FiveCM = 45000, EightCM = 64000, NineCM = 70000, TenCM = 76000 });
                this.Materials.Add(new Material { Id = 60, Name = "Verde San Francisco", TwoCM = 39000, ThreeCM = 52000, FiveCM = 77000, EightCM = 112000, NineCM = 125000, TenCM = 137000 });
                this.Materials.Add(new Material { Id = 61, Name = "Verde Star", TwoCM = 27000, ThreeCM = 33000, FiveCM = 45000, EightCM = 64000, NineCM = 80000, TenCM = 98000 });
                this.Materials.Add(new Material { Id = 62, Name = "Verde Ubatuba", TwoCM = 28000, ThreeCM = 36000, FiveCM = 53000, EightCM = 77000, NineCM = 84000, TenCM = 91000 });
                this.Materials.Add(new Material { Id = 63, Name = "Viscont White", TwoCM = 27000, ThreeCM = 33500, FiveCM = 45000, EightCM = 74000, NineCM = 82000, TenCM = 91000 });
                this.Materials.Add(new Material { Id = 64, Name = "Volga Blue", TwoCM = 45000, ThreeCM = 53000, FiveCM = 77000, EightCM = 117000, NineCM = 127000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 65, Name = "Yellow Rock KT", TwoCM = 17000, ThreeCM = 22000, FiveCM = 33000, EightCM = 48000, NineCM = 54000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 66, Name = "Yellow Rock NT", TwoCM = 22000, ThreeCM = 27000, FiveCM = 48000, EightCM = 0, NineCM = 78000, TenCM = 0 });
                this.Materials.Add(new Material { Id = 67, Name = "Breccia Sarda", TwoCM = 17500, ThreeCM = 26000, FiveCM = 37000, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 68, Name = "Jura fényezett/antikolt", TwoCM = 19500, ThreeCM = 26000, FiveCM = 41000, EightCM = 0, NineCM = 89000, TenCM = 98000 });
                this.Materials.Add(new Material { Id = 69, Name = "Travertin tömített, fény.", TwoCM = 18000, ThreeCM = 24000, FiveCM = 43000, EightCM = 0, NineCM = 0, TenCM = 64000 });
                this.Materials.Add(new Material { Id = 70, Name = "Travertin Noche tömített, fény.", TwoCM = 19500, ThreeCM = 26000, FiveCM = 0, EightCM = 0, NineCM = 0, TenCM = 0 });
                this.Materials.Add(new Material { Id = 71, Name = "Vratza mészkő", TwoCM = 13000, ThreeCM = 17000, FiveCM = 24000, EightCM = 40000, NineCM = 0, TenCM = 50000 });

                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseCalculation>()
                .Property(p => p.InsertDate)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken()
                .HasDefaultValueSql("DATETIME('NOW','LOCALTIME')");
            modelBuilder.Entity<Calculation>()
                .Property(p => p.InsertDate)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken()
                .HasDefaultValueSql("DATETIME('NOW','LOCALTIME')");

            modelBuilder.Entity<Material>()
                .Property(p => p.InsertDate)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken()
                .HasDefaultValueSql("DATETIME('NOW','LOCALTIME')");

            modelBuilder.Entity<Piece>()
                .Property(p => p.InsertDate)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken()
                .HasDefaultValueSql("DATETIME('NOW','LOCALTIME')");

            modelBuilder.Entity<Setting>()
                .Property(p => p.InsertDate)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken()
                .HasDefaultValueSql("DATETIME('NOW','LOCALTIME')");

            modelBuilder.Entity<Thickness>()
                .Property(p => p.InsertDate)
                .ValueGeneratedOnAddOrUpdate()
                .IsConcurrencyToken()
                .HasDefaultValueSql("DATETIME('NOW','LOCALTIME')");
        }
    }
}
