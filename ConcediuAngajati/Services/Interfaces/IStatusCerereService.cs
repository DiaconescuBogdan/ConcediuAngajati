using ConcediuAngajati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Services.Interfaces
{
    public interface IStatusCerereService
    {
        public Task<List<StatusCerere>> GetAllStatusCerere();
        public Task<StatusCerere> GetStatusCerereById(int? id);
        public Task<bool> UpdateStatusCerere(int id, StatusCerere StatusCerere);
        public Task<bool> CreateStatusCerere(StatusCerere StatusCerere);
        public Task<bool> DeleteStatusCerere(int id);
        public bool StatusCerereExists(int id);

    }
}
