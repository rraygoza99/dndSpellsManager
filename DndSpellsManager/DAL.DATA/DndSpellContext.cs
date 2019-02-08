using DAL.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Data
{
    public class DndSpellContext : DbContext
    {
        public virtual DbSet<Spell> Spells { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Spellbook> Spellbooks { get; set; }
        public virtual DbSet<SpellMaterial> SpellMaterials { get; set; }
        public virtual DbSet<SpellSpellbook> SpellSpellbooks { get; set; }

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
        }
    }
}
