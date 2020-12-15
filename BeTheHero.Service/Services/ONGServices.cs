using BeTheHero.Domain.DTO;
using BeTheHero.Domain.IRepositories;
using BeTheHero.Domain.Model;
using BeTheHero.Service.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeTheHero.Service.Services
{
    public class ONGServices : IONGServices
    {
        private readonly IONGRepositories _ongRepositories;

        public ONGServices(IONGRepositories repositories)
        {
            _ongRepositories = repositories;
        }
        public void Add(ONG ongs)
        { 
            _ongRepositories.Add(ongs);
        }

        public async Task<List<OngDTO>> Get()
        {
            return await _ongRepositories.Get();
        }

        public ONG GetById(string id)
        {
            return _ongRepositories.GetById(id);
        }
    }
}
