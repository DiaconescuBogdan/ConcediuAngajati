using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConcediuAngajati.Models
{
    public class StatusCerere
    {
        [Key]
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string Descriere { get; set; }

        public ICollection<CerereConcediu> CereriConcediu { get; set; }

    }
}