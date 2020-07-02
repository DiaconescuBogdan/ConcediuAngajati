using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Models
{
    public class ConcediuAngajatiContext : IdentityDbContext<IdentityUser>
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
        public DbSet<CerereConcediu> CereriConcediu { get; set; }
        public DbSet<StatusCerere> StatusCereri { get; set; }

    }
}
