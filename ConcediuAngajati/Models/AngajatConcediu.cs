using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Models
{
    public class AngajatConcediu
    {
        [Key]
        public int AngajatConcediuId { get; set; }
        public int AngajatId { get; set; }
        public Angajat Angajat { get; set; }
        public int ConcediuId { get; set; }
        public Concediu Concediu { get; set; }

        public int ZileConcediuDisponibile { get; set; }
        public int ZileConcediuUtilizate { get; set; }
    }
}
