using BeTheHero.Domain.DTO;
using BeTheHero.Domain.IRepositories;
using BeTheHero.Domain.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BeTheHero.Repository.Repositories
{
    public class ONGRepositories : IONGRepositories
    {
        private readonly SqlConnection _sqlConnection;

        public ONGRepositories(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public void Add(ONG ongs)
        {
            var sql = "Insert into ongs (Id, Name, Email, Whatsapp, City, UF ) values(@Id, @Name, @Email, @Whatsapp, @City, @UF)";
            _sqlConnection.Query<ONG>(sql , new { ongs.Id, ongs.Name, ongs.Email, ongs.Whatsapp, ongs.City, ongs.UF });
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OngDTO>> Get()
        {
            var sql = "Select * from ongs";
            var result = await _sqlConnection.QueryAsync<OngDTO>(sql);
            return result.ToList();
        }

        public ONG GetById(string id)
        {
            var sql = "Select Name from ongs where Id = @id";
            var result = _sqlConnection.Query<ONG>(sql, new { id });
            if (result.Count() == 0)
                return null;
            else
                return result.First();
        }

        public void Update(ONG ongs)
        {
            throw new NotImplementedException();
        }
    }
}
