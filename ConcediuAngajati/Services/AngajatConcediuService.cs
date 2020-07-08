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
    public class AngajatConcediuService : IAngajatConcediuService
    {
        private readonly IAngajatConcediuRepository _angajatConcediuConcediuRepository;

        public AngajatConcediuService(IAngajatConcediuRepository cerereConcediuRepository)
        {
            this._angajatConcediuConcediuRepository = cerereConcediuRepository;
        }



        public async Task<bool> CreateAngajatConcediu(AngajatConcediu cerereConcediu)
        {
            try
            {
                _angajatConcediuConcediuRepository.Create(cerereConcediu);
                await _angajatConcediuConcediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public Task<List<AngajatConcediu>> GetAllAngajatConcediu()
        {
            try
            {
                return _angajatConcediuConcediuRepository.FindAll().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<AngajatConcediu> GetAngajatConcediuById(int? id)
        {
            try
            {
                return _angajatConcediuConcediuRepository.FindByCondition(concediu => concediu.AngajatConcediuId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateAngajatConcediu(int id, AngajatConcediu cerereConcediu)
        {
            try
            {
                await GetAngajatConcediuById(id);
                _angajatConcediuConcediuRepository.Update(cerereConcediu);
                await _angajatConcediuConcediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteAngajatConcediu(int id)
        {
            try
            {
                var concediu = await GetAngajatConcediuById(id);
                _angajatConcediuConcediuRepository.Delete(concediu);
                await _angajatConcediuConcediuRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool AngajatConcediuExists(int id)
        {
            return _angajatConcediuConcediuRepository.FindByCondition(e => e.AngajatConcediuId == id).Any();
        }

        public Task<AngajatConcediu> GetAngajatConcediuByName(string name)
        {
            try
            {
                return _angajatConcediuConcediuRepository.FindByCondition(concediu => concediu.Angajat.Nume == name).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}

