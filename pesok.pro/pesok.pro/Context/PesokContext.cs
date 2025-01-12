using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using pesok.pro.Models;

namespace pesok.pro.Context
{
    public partial class PesokContext : DbContext
    {
        public PesokContext()
        {
        }

        public PesokContext(DbContextOptions<PesokContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Catalog> Catalogs { get; set; } = null!;
        public virtual DbSet<MenuEntry> MenuEntries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=217.199.219.233;Database=NPK40_DB;user id=sa;password=1009973kzta!Q@;TrustServerCertificate=True;Encrypt=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Html).HasColumnName("HTML");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Keywords)
                    .HasMaxLength(250)
                    .HasColumnName("KEYWORDS");

                entity.Property(e => e.Minitext)
                    .HasMaxLength(500)
                    .HasColumnName("MINITEXT");

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");

                entity.Property(e => e.Image_Src)
                  .HasMaxLength(150)
                  .HasColumnName("IMAGE_SRC");
            });

            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Html).HasColumnName("HTML");

                entity.Property(e => e.Image)
                    .HasColumnType("image")
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Keywords)
                    .HasMaxLength(250)
                    .HasColumnName("KEYWORDS");

                entity.Property(e => e.Minitext)
                    .HasMaxLength(250)
                    .HasColumnName("MINITEXT");

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");
            });

            modelBuilder.Entity<MenuEntry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MENU_ENTRIES");

                entity.Property(e => e.Header)
                    .HasMaxLength(250)
                    .HasColumnName("HEADER");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Indx).HasColumnName("INDX");

                entity.Property(e => e.Priority).HasColumnName("PRIORITY");

                entity.Property(e => e.Razdel)
                    .HasMaxLength(250)
                    .HasColumnName("RAZDEL");

                entity.Property(e => e.Section)
                    .HasMaxLength(50)
                    .HasColumnName("SECTION");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .HasColumnName("URL");

                entity.Property(e => e.Visible).HasColumnName("VISIBLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
