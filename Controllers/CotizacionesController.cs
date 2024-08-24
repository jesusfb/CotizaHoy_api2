using CotizaHoyAPI.Services.Clientes;
using CotizaHoyAPI.Services.Cotizaciones;
using DotNet8WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNet8WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class CotizacionesController : ControllerBase
    {
        // GET: api/<ProductosController>
        private readonly ICotizacionesService _Service;

        public CotizacionesController(ICotizacionesService heroService)
        {
            _Service = heroService;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _Service.GetAll();
            return Ok(data);
        }

             [HttpGet("GetById")]
            [ProducesResponseType(typeof(ActionResult<Cotizaciones>), StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<ActionResult<Cotizaciones>> Get(int id)
            {
                 var doctor =  _Service.GetByID(id);
                //var doctor = await _doctorRepo.Get(doctorID);
                try
                {
                    if (doctor != null)
                        return Ok(doctor);
                    return NotFound();
                }
                catch (Exception ex)
                {
                    return BadRequest("Not able to get doctor detail based on ID");
                }
            }
        
        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
