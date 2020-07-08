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
    public class CerereConcediuService : ICerereConcediuService
    {
        private readonly ICerereConcediuRepository _cerereConcediuRepository;

        public CerereConcediuService(ICerereConcediuRepository cerereConcediuRepository)
        {
            this._cerereConcediuRepository = cerereConcediuRepository;
        }



        public async Task<bool> CreateCerereConcediu(CerereConcediu cerereConcediu)
        {
            try
            {
                _cerereConcediuRepository.Create(cerereConcediu);
                await _cerereConcediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public Task<List<CerereConcediu>> GetAllCerereConcediu()
        {
            try
            {
                return _cerereConcediuRepository.FindAll().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<CerereConcediu> GetCerereConcediuById(int? id)
        {
            try
            {
                return _cerereConcediuRepository.FindByCondition(concediu => concediu.CerereId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateCerereConcediu(int id, CerereConcediu cerereConcediu)
        {
            try
            {
                await GetCerereConcediuById(id);
                _cerereConcediuRepository.Update(cerereConcediu);
                await _cerereConcediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteCerereConcediu(int id)
        {
            try
            {
                var concediu = await GetCerereConcediuById(id);
                _cerereConcediuRepository.Delete(concediu);
                await _cerereConcediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool CerereConcediuExists(int id)
        {
            return _cerereConcediuRepository.FindByCondition(e => e.CerereId == id).Any();
        }

    }
}
