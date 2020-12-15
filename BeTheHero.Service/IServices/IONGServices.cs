using BeTheHero.Domain.DTO;
using BeTheHero.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeTheHero.Service.IServices
{
    public interface IONGServices
    {
        void Add(ONG ongs);
        Task<List<OngDTO>> Get();
        ONG GetById(string Id);
    }
}
