using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<Spellbook> Spellbooks { get; set; }
    }
}
