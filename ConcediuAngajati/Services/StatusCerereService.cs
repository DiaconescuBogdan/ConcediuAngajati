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
    public class StatusCerereService : IStatusCerereService
    {
        private readonly IStatusCerereRepository _statusCerereRepository;

        public StatusCerereService(IStatusCerereRepository statusCerereRepository)
        {
            this._statusCerereRepository = statusCerereRepository;
        }



        public async Task<bool> CreateStatusCerere(StatusCerere statusCerere)
        {
            try
            {
                _statusCerereRepository.Create(statusCerere);
                await _statusCerereRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


        public Task<List<StatusCerere>> GetAllStatusCerere()
        {
            try
            {
                return _statusCerereRepository.FindAll().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<StatusCerere> GetStatusCerereById(int? id)
        {
            try
            {
                return _statusCerereRepository.FindByCondition(concediu => concediu.StatusId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateStatusCerere(int id, StatusCerere cerereConcediu)
        {
            try
            {
                await GetStatusCerereById(id);
                _statusCerereRepository.Update(cerereConcediu);
                await _statusCerereRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteStatusCerere(int id)
        {
            try
            {
                var concediu = await GetStatusCerereById(id);
                _statusCerereRepository.Delete(concediu);
                await _statusCerereRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool StatusCerereExists(int id)
        {
            return _statusCerereRepository.FindByCondition(e => e.StatusId == id).Any();
        }

    }
}

