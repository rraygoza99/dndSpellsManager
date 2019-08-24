using DAL.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DAL.Data
{
    public class DndSpellContext : DbContext
    {
        public virtual DbSet<Spell> Spells { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Spellbook> Spellbooks { get; set; }
        public virtual DbSet<SpellMaterial> SpellMaterials { get; set; }
        public virtual DbSet<SpellSpellbook> SpellSpellbooks { get; set; }
        public virtual DbSet<SpellClass> SpellClasses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Class> Classes { get; set; }

        public DndSpellContext(DbContextOptions<DndSpellContext> options) : base(options)
        {

        }
        public DndSpellContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SpellMaterial>()
                .HasKey(k => new { k.IdMaterial, k.IdSpell });
            modelBuilder.Entity<SpellSpellbook>()
                .HasKey(k => new { k.IdSpell, k.IdSpellbook });
            modelBuilder.Entity<SpellClass>()
                .HasKey(k => new { k.IdClass, k.IdSpell });
        }
        public class DndContextFactory
        {
            public DndSpellContext CreateDndContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<DndSpellContext>();
                var connectionString = "Server=localhost;Initial Catalog=dndSpell;Persist Security Info=False;User ID=dnd;Password=dnd2019;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
                builder.UseSqlServer(connectionString,
                    b => { b.MigrationsAssembly("SL.API"); b.EnableRetryOnFailure(); });
                return new DndSpellContext(builder.Options);
            }
        }
    }
}
