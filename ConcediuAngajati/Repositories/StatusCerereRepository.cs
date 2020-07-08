using ConcediuAngajati.Models;
using ConcediuAngajati.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Repositories
{
    public class StatusCerereRepository : RepositoryBase<StatusCerere>, IStatusCerereRepository
    {
        public StatusCerereRepository(ConcediuAngajatiContext repositoryContext)
           : base(repositoryContext)
    {
    }
}
}
