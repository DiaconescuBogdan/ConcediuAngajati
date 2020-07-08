using ConcediuAngajati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Services.Interfaces
{
    public interface IAngajatConcediuService
    {
        public Task<List<AngajatConcediu>> GetAllAngajatConcediu();
        public Task<AngajatConcediu> GetAngajatConcediuById(int? id);
        public Task<AngajatConcediu> GetAngajatConcediuByName(string? name);
        public Task<bool> UpdateAngajatConcediu(int id, AngajatConcediu ac);
        public Task<bool> CreateAngajatConcediu(AngajatConcediu ac);
        public Task<bool> DeleteAngajatConcediu(int id);
        public bool AngajatConcediuExists(int id);
    }
}
