using ConcediuAngajati.Models;
using ConcediuAngajati.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Repositories
{
    public class ConcediuRepository : RepositoryBase<Concediu>, IConcediuRepository
    {
        public ConcediuRepository(ConcediuAngajatiContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}