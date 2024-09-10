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
    public class ArtículoController : ControllerBase
    {
        private readonly IArtículoService _articuloService;

        public ArtículoController(IArtículoService articuloService)
        {
            _articuloService = articuloService;
        }




        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var rsp = new Response<Artículo>();
            try
            {
                var articulo = await _articuloService.Obtener(id);
                if (articulo == null)
                {
                    rsp.status = false;
                    rsp.msg = "Cliente no encontrado";
                }
                else
                {
                    rsp.status = true;
                    rsp.value = articulo;
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
            var rsp = new Response<IEnumerable<Artículo>>();
            try
            {
                var artículo = await _articuloService.ObtenerTodos();
                rsp.status = true;
                rsp.value = artículo;
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
        public async Task<IActionResult> Guardar([FromBody] Artículo articulo)
        {
            var rsp = new Response<ClienteDTO>();
            try
            {

                rsp.status = true;
                rsp.value = await _articuloService.Insertar(articulo);
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
        public async Task<IActionResult> Editar([FromBody] Artículo artículo)
        {
            var rsp = new Response<bool>();
            try
            {

                rsp.status = true;
                rsp.value = await _articuloService.Actualizar(artículo);
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
                rsp.value = await _articuloService.Eliminar(id);
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
