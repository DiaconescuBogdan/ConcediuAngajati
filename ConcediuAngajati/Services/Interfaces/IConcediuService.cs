using ConcediuAngajati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Services.Interfaces
{
    public interface IConcediuService
    {
        public Task<List<Concediu>> GetAllConcediu();
        public Task<Concediu> GetConcediuById(int? id);
        public Task<bool> UpdateConcediu(int id, Concediu Concediu);
        public Task<bool> CreateConcediu(Concediu Concediu);
        public Task<bool> DeleteConcediu(int id);
        public bool ConcediuExists(int id);
    }
}
