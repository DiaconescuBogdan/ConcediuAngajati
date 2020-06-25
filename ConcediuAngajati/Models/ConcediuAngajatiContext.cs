using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Models
{
    public class ConcediuAngajatiContext : DbContext
    {
        public ConcediuAngajatiContext()
        {
        }

        public ConcediuAngajatiContext(DbContextOptions<ConcediuAngajatiContext> options)
           : base(options)
        { }

        public DbSet<Angajat> Angajati { get; set; }
        public DbSet<Concediu> Concedii { get; set; }
        public DbSet<AngajatConcediu> AngajatiConcedii { get; set; }
        public DbSet<Functie> Functii { get; set; }
        public DbSet<AngajatFunctie> AngajatiFunctii { get; set; }
        public DbSet<CerereConcediu> CereriConcediu { get; set; }

    }
}
