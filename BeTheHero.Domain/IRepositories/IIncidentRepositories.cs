using BeTheHero.Domain.DTO;
using BeTheHero.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeTheHero.Domain.IRepositories
{
    public interface IIncidentRepositories
    {
        void Add(Incident incident);
        Task<List<IncidentDTO>> Get(int page, string ongId);
        Task<List<Incident>> GetIncidentsByOng(string ong_Id);
        void Delete(int id);
        Incident Validation(int id);
        List<string> Count();
    }
}
