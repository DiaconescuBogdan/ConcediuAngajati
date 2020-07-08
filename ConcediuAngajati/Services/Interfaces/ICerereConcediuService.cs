using ConcediuAngajati.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Services.Interfaces
{
    public interface ICerereConcediuService
    {
        public Task<List<CerereConcediu>> GetAllCerereConcediu();
        public Task<CerereConcediu> GetCerereConcediuById(int? id);
        public Task<bool> UpdateCerereConcediu(int id, CerereConcediu CerereConcediu);
        public Task<bool> CreateCerereConcediu(CerereConcediu CerereConcediu);
        public Task<bool> DeleteCerereConcediu(int id);
        public bool CerereConcediuExists(int id);
    }
}

