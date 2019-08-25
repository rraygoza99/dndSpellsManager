using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("class")]
    public class Class
    {
        public Class()
        {
            SpellsClass = new HashSet<SpellClass>();
            ClassStats = new HashSet<ClassLevelStats>();
        }

        [Column("id_class")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [InverseProperty("Class")]
        public ICollection<SpellClass> SpellsClass { get; set; }

        [InverseProperty("Class")]
        public ICollection<ClassLevelStats> ClassStats { get; set; }
    }
}
