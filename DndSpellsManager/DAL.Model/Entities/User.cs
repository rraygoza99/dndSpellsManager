using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Model.Entities
{
    [Table("user")]
    public class User
    {
        [Column("id_user")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [InverseProperty("User")]
        public ICollection<Spellbook> Spellbooks { get; set; }
    }
}
