using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Models
{
    public class Angajat
    {
        [Key]
        public int AngajatId { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public DateTime DataNastere { get; set; }


        public ICollection<AngajatConcediu> AngajatiConcedii { get; set; }
        public ICollection<CerereConcediu> CereriConcediu { get; set; }
    }
}
