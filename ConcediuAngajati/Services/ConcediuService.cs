using ConcediuAngajati.Models;
using ConcediuAngajati.Repositories.Interfaces;
using ConcediuAngajati.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcediuAngajati.Services
{
    public class ConcediuService : IConcediuService
    {
        private readonly IConcediuRepository _concediuRepository;

        public ConcediuService(IConcediuRepository concediuRepository)
        {
            this._concediuRepository = concediuRepository;
        }



        public async Task<bool> CreateConcediu(Concediu concediu)
        {
            try
            {
                _concediuRepository.Create(concediu);
                await _concediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public Task<List<Concediu>> GetAllConcediu()
        {
            try
            {
                return _concediuRepository.FindAll().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<Concediu> GetConcediuById(int? id)
        {
            try
            {
                return _concediuRepository.FindByCondition(concediu => concediu.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateConcediu(int id, Concediu concediu)
        {
            try
            {
                await GetConcediuById(id);
                _concediuRepository.Update(concediu);
                await _concediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteConcediu(int id)
        {
            try
            {
                var concediu = await GetConcediuById(id);
                _concediuRepository.Delete(concediu);
                await _concediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool ConcediuExists(int id)
        {
            return _concediuRepository.FindByCondition(e => e.Id == id).Any();
        }
    }
}
