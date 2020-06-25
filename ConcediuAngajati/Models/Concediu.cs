using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Models
{
    public class Concediu
    {
        [Key]
        public int Id { get; set; }
        public string TipConcediu { get; set; }
        public int NrZile { get; set; }

        public ICollection<AngajatConcediu> AngajatiConcedii { get; set; }

    }
}
