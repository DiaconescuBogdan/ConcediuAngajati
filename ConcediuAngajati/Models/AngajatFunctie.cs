using System.ComponentModel.DataAnnotations;

namespace ConcediuAngajati.Models
{
    public class AngajatFunctie
    {
        [Key]
        public int AngajatFunctieId { get; set; }
        public int AngajatId { get; set; }
        public Angajat Angajat { get; set; }
        public int FunctieId { get; set; }
        public Functie Functie { get; set; }
    }
}