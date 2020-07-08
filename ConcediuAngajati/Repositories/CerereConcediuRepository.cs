using ConcediuAngajati.Models;
using ConcediuAngajati.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Repositories
{
    public class CerereConcediuRepository  : RepositoryBase<CerereConcediu>, ICerereConcediuRepository
    {
        public CerereConcediuRepository(ConcediuAngajatiContext repositoryContext)
           : base(repositoryContext)
    {
    }
}
}
