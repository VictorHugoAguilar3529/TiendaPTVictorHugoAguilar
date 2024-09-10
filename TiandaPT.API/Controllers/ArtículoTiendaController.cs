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
    public class ArtículoTiendaController : ControllerBase
    {
        private readonly IArtículoTiendaService _articuloTiendaService;

        public ArtículoTiendaController(IArtículoTiendaService articuloTiendaService)
        {
            _articuloTiendaService = articuloTiendaService;
        }




        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var rsp = new Response<Artículo>();
            try
            {
                var articuloTienda = await _articuloTiendaService.Obtener(id);
                if (articuloTienda == null)
                {
                    rsp.status = false;
                    rsp.msg = "Cliente no encontrado";
                }
                else
                {
                    rsp.status = true;
                    rsp.value = articuloTienda;
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
            var rsp = new Response<IEnumerable<ArtículoTiendum>>();
            try
            {
                var artículoTienda = await _articuloTiendaService.ObtenerTodos();
                rsp.status = true;
                rsp.value = artículoTienda;
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
        public async Task<IActionResult> Guardar([FromBody] ArtículoTiendum artículoTienda)
        {
            var rsp = new Response<ClienteDTO>();
            try
            {

                rsp.status = true;
                rsp.value = await _articuloTiendaService.Insertar(artículoTienda);
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
        public async Task<IActionResult> Editar([FromBody] ArtículoTiendum artículoTiendum)
        {
            var rsp = new Response<bool>();
            try
            {

                rsp.status = true;
                rsp.value = await _articuloTiendaService.Actualizar(artículoTiendum);
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
                rsp.value = await _articuloTiendaService.Eliminar(id);
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
