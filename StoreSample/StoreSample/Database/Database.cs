using Microsoft.EntityFrameworkCore;
using StoreSample.Helpers;
using StoreSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StoreSample.Database
{
    public class Database : DbContext
    {
        private string path;

        static Database instance;
        public static Database Instance => instance ?? (instance = new Database(Settings.DatabasePath));

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Pan> Pans { get; set; }
        public DbSet<ItemPan> ItemsPan { get; set; }

        public Database(string path)
        {
            this.path = path;

            Database.EnsureDeleted();
            Database.EnsureCreated();
            Initialize();
        }

        private void Initialize()
        {
            if (Products.Count() == 0)
            {
                Products.AddRange(new List<Product>{
                    new Product
                    {
                        Nom = "T-shirt pour les femmes",
                        Imagem = "imagem1.png",
                        Pr = 109.90,
                    },
                    new Product
                    {
                        Nom = "T-shirt pour les femmes",
                        Imagem = "imagem2.png",
                        Pr = 109.90,
                    },
                    new Product
                    {
                        Nom = "short pour les femmes",
                        Imagem = "imagem3.png",
                        Pr = 139.90,
                    },
                    new Product
                    {
                        Nom = "truc pour les femmes",
                        Imagem = "imagem4.png",
                        Pr = 269.90,
                    },
                    new Product
                    {
                        Nom = "truc pour les femmes",
                        Imagem = "imagem5.png",
                        Pr = 199.90,
                    },
                });

                SaveChanges();
            }
        }

        public Database(DbContextOptions<Database> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(path))
            {
                optionsBuilder.UseSqlite($"Filename={path}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasMany(s => s.Pans).WithOne(s => s.Client).HasForeignKey(s => s.ClientId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Pan>().HasMany(s => s.ItemsPan).WithOne(s => s.Pan).HasForeignKey(s => s.PanId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasMany(s => s.ItemsPan).WithOne(s => s.Product).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
