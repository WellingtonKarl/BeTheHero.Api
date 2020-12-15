using System;
using System.Threading.Tasks;
using BeTheHero.Domain.Model;
using BeTheHero.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeTheHero.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentServices _incidentServices;

        public IncidentController(IIncidentServices services)
        {
            _incidentServices = services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: api/Incident
        [HttpGet]
        public async Task<IActionResult> Get([FromHeader] string ongId, int page = 1)
        {
            var pages = _incidentServices.TotalPages();
            Response.Headers.Add("X-Total-Count", pages[0]);
            var pagges = await _incidentServices.Get(page, ongId);
            if (pagges != null)
                return Ok(pagges);
            else
                return Ok(StatusCode(401, "Dados não autorizados"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ong_Id"></param>
        /// <returns></returns>
        // GET: api/Incident/5
        [HttpGet("{ong_Id}")]
        public async Task<IActionResult> GetIncidentbyOng(string ong_Id)
        {
            return Ok(await _incidentServices.GetIncidentsByOng(ong_Id));
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="incidents"></param>
        /// <param name="ongId"></param>
        /// <returns></returns>
        // POST: api/Incident
        [HttpPost]
        public IActionResult Post([FromBody]Incident incidents, [FromHeader] string ongId)
        {
            var incident = new Incident()
            {
                Title = incidents.Title,
                Description = incidents.Description,
                Valor = incidents.Valor,
                Ongs_Id = ongId,
            };
            _incidentServices.Add(incident);
            return Ok(incidents);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/Incident/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromHeader] string ongId, int id)
        {
            var ong_Id = new Incident() { Ongs_Id = ongId };
            var ong = _incidentServices.Validate(id);
            if(ong != null && ong.Ongs_Id == ong_Id.Ongs_Id)
            {
                _incidentServices.Delete(id);
                return Ok(StatusCodes.Status204NoContent);
            }
            else
            {
                return Ok(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
