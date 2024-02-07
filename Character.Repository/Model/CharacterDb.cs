using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Character.Repository.Model
{
    public class CharacterDb
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Star { get; set; }
        public string Class { get; set; }
        public string Subclass { get; set; }
        public int Elite { get; set; }
        public int Level { get; set; }
        public string Trait { get; set; }
    }
}
