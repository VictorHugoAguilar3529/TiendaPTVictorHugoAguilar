using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiandaPT.API.Utilidad;
using TiandaPTCrud.BLL.Service;
using TiandaPTCrud.DTO;
using TiandaPTCrud.Models;

namespace TiandaPT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaService _tiendaService;

        public TiendaController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }




        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var rsp = new Response<Tiendum>();
            try
            {
                var tienda = await _tiendaService.Obtener(id);
                if (tienda == null)
                {
                    rsp.status = false;
                    rsp.msg = "Cliente no encontrado";
                }
                else
                {
                    rsp.status = true;
                    rsp.value = tienda;
                }
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }





        [HttpGet]
        [Route("ObtenerTodos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var rsp = new Response<IEnumerable<Tiendum>>();
            try
            {
                var tienda = await _tiendaService.ObtenerTodos();
                rsp.status = true;
                rsp.value = tienda;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        // POST api/<ClienteController>
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Tiendum tienda)
        {
            var rsp = new Response<TiendaDTO>();
            try
            {

                rsp.status = true;
                rsp.value = await _tiendaService.Insertar(tienda);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        // PUT api/<ClienteController>/5
        [HttpPost]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Tiendum tienda)
        {
            var rsp = new Response<bool>();
            try
            {

                rsp.status = true;
                rsp.value = await _tiendaService.Actualizar(tienda);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();
            try
            {

                rsp.status = true;
                rsp.value = await _tiendaService.Eliminar(id);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }
    }
}
