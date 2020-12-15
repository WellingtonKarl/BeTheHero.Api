using BeTheHero.Domain.DTO;
using BeTheHero.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeTheHero.Domain.IRepositories
{
    public interface IONGRepositories
    {
        void Add(ONG ongs);
        Task<List<OngDTO>> Get();
        ONG GetById(string id);
        void Delete(int id);
        void Update(ONG ongs);
    }
}
