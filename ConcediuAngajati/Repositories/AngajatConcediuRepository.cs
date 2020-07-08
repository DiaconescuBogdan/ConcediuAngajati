using ConcediuAngajati.Models;
using ConcediuAngajati.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Repositories
{
    public class AngajatConcediuRepository : RepositoryBase<AngajatConcediu>, IAngajatConcediuRepository
    {
        public AngajatConcediuRepository(ConcediuAngajatiContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
