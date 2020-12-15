using BeTheHero.Domain.DTO;
using BeTheHero.Domain.IRepositories;
using BeTheHero.Domain.Model;
using BeTheHero.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeTheHero.Service.Services
{
    public class IncidentServices : IIncidentServices
    {
        private readonly IIncidentRepositories _incidentRepositories;

        public IncidentServices(IIncidentRepositories repositories)
        {
            _incidentRepositories = repositories;
        }

        public void Add(Incident incident)
        {
            _incidentRepositories.Add(incident);
        }

        public void Delete(int id)
        {
            _incidentRepositories.Delete(id);
        }

        public Task<List<IncidentDTO>> Get(int page, string ongId)
        {
            return _incidentRepositories.Get(page, ongId);
        }

        public async Task<List<Incident>> GetIncidentsByOng(string ong_Id)
        {
            return await _incidentRepositories.GetIncidentsByOng(ong_Id);
        }

        public List<string> TotalPages()
        {
            return _incidentRepositories.Count();
        }

        public Incident Validate(int id)
        {
            return _incidentRepositories.Validation(id);
        }
    }
}
