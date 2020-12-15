using BeTheHero.Domain.DTO;
using BeTheHero.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeTheHero.Service.IServices
{
    public interface IIncidentServices
    {
        void Add(Incident incident);
        Task<List<IncidentDTO>> Get(int page, string ongId);
        void Delete(int id);
        Incident Validate(int id);
        Task<List<Incident>> GetIncidentsByOng(string ong_Id);
        List<string> TotalPages();

    }
}
