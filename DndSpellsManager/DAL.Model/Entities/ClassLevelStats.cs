using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("class_level_stats")]
    public class ClassLevelStats
    {
        [Column("id_class")]
        public int IdClass { get; set; }

        [Column("level")]
        public int Level { get; set; }

        [Column("proficiency_bonus")]
        public int ProficiencyLevel { get; set; }

        [Column("cantrips_known")]
        public int CantripsKnown { get; set; }

        [Column("spells_known")]
        public int SpellsKnown { get; set; }

        [Column("spell_slot_1")]
        public int SpellSlot1 { get; set; }

        [Column("spell_slot_2")]
        public int SpellSlot2 { get; set; }

        [Column("spell_slot_3")]
        public int SpellSlot3 { get; set; }

        [Column("spell_slot_4")]
        public int SpellSlot4 { get; set; }

        [Column("spell_slot_5")]
        public int SpellSlot5 { get; set; }

        [Column("spell_slot_6")]
        public int SpellSlot6 { get; set; }

        [Column("spell_slot_7")]
        public int SpellSlot7 { get; set; }

        [Column("spell_slot_8")]
        public int SpellSlot8 { get; set; }

        [Column("spell_slot_9")]
        public int SpellSlot9 { get; set; }

        [InverseProperty("ClassStats"), ForeignKey("IdClass")]
        public Class Class { get; set; }
    }
}
