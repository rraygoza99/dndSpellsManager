using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("spell")]
    public class Spell
    {
        public Spell()
        {
            SpellbookSpells = new HashSet<SpellSpellbook>();
            SpellMaterials = new HashSet<SpellMaterial>();
            SpellsClass = new HashSet<SpellClass>();
        }

        [Column("id_spell")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("level")]
        public int Level { get; set; }

        [Column("spell_type")]
        public SpellType SpellType { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("magic_school")]
        public string MagicSchool { get; set; }

        [Column("range")]
        public string Range { get; set; } 

        [Column("components")]
        public string Components { get; set; }

        [Column("duration")]
        public string Duration { get; set; }
        
        [Column("ritual")]
        public bool Ritual { get; set; }

        [Column("concentration")]
        public bool Concentration { get; set; }

        [Column("casting_time")]
        public string CastingTime { get; set; }

        [InverseProperty("Spell")]
        public ICollection<SpellSpellbook> SpellbookSpells { get; set; }

        [InverseProperty("Spell")]
        public ICollection<SpellMaterial> SpellMaterials { get; set; }

        [InverseProperty("Spell")]
        public ICollection<SpellClass> SpellsClass { get; set; }
    }

    public enum SpellType
    {
        Damage = 1,
        Healing = 2,
        Utility = 3,
        Mobility = 4
    }
}
