using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Models
{
    public class CerereConcediu
    {
        [Key]
        public int CerereId { get; set; }
        public string Descriere { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusCerere StatusCerere { get; set; }

        public Angajat Angajat { get; set; }
    }
}
