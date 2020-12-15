using System.Threading.Tasks;
using BeTheHero.Domain.Model;
using BeTheHero.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BeTheHero.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ONGController : ControllerBase
    {
        private readonly IONGServices _ongServices;

        public ONGController(IONGServices services)
        {
            _ongServices = services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //GET: api/ONG
       [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ongServices.Get());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/ONG/5
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] string id)
        {
            var ongName = _ongServices.GetById(id);
            
            if (ongName == null)
            {
                return Ok(StatusCode(400, "No ONG found with this ID"));
            }
            return Ok(ongName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ongs"></param>
        /// <returns></returns>
        // POST: api/ONG
        [HttpPost]
        public IActionResult Post([FromBody] ONG ongs)
        {
            _ongServices.Add(ongs);
            return Ok(ongs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT: api/ONG/5
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
        public void Delete(int id)
        {
        }
    }
}
