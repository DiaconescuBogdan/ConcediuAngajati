using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Models
{
    public class Functie
    {
        [Key]
        public int FunctieId { get; set; }
        public string TipFunctie { get; set; }
        public string Descriere { get; set; }

        public ICollection<AngajatFunctie> AngajatiFunctii { get; set; }

    }
}
