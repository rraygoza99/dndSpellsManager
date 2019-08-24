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
        }

        [Column("id_class")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [InverseProperty("Class")]
        public ICollection<SpellClass> SpellsClass { get; set; }
    }
}
