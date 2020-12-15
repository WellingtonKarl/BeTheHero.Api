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
    public class IncidentRepositories : IIncidentRepositories
    {
        private readonly SqlConnection _sqlConnection;

        public IncidentRepositories(SqlConnection connection)
        {
            _sqlConnection = connection;
        }

        public void Add(Incident incident)
        {
            var sql = "Insert into incidents (Title, Description, Value, Ongs_Id) values(@Title, @Description, @Valor, @Ongs_Id)";
            _sqlConnection.Query<Incident>(sql, new { incident.Title, incident.Description, incident.Valor, incident.Ongs_Id });
        }

        public List<string> Count()
        {
            var sql = "select count(*) from incidents";
            var result = _sqlConnection.Query<string>(sql).ToList();
            return result;
        }

        public void Delete(int id)
        {
            var sql = "Delete from incidents where IdIncident = @id";
            _sqlConnection.Query<Incident>(sql , new { id });
        }

        public async Task<List<IncidentDTO>> Get(int page, string ongId)
        {
            var qtdPorPagina = 5;
            var sql = $"select IdIncident, Title, Description, Value, Ongs_Id, Name, Email, Whatsapp, City, UF from incidents  i full outer join ongs o on i.Ongs_Id = o.Id where i.Ongs_Id = '{ongId}' order by o.Id offset({page} - 1) * {qtdPorPagina} rows fetch next {qtdPorPagina} rows only";
            var result = await _sqlConnection.QueryAsync<IncidentDTO>(sql);

            if (result.Count() != 0)
            {
                List<IncidentDTO> index = result.ToList();
                if (index[0].IdIncident == 0)
                    return null;
            }
            return result.ToList();
        }

        public async Task<List<Incident>> GetIncidentsByOng(string ong_Id)
        {
            var sql = "select * from incidents where Ongs_Id = @ong_Id";
            var result = await _sqlConnection.QueryAsync<Incident>(sql, new { ong_Id });
            return result.ToList();
        }

        public Incident Validation(int id)
        {
            var sql = "Select Ongs_Id from incidents where IdIncident = @id";
            var result = _sqlConnection.Query<Incident>(sql, new { id });
            if (result.Count() == 1)
                return result.First();
            else
                return null;
        }
    }
}
