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
    public class ClienteArtículoController : ControllerBase
    {
        private readonly IClienteArtículoService _clienteArticuloService;

        public ClienteArtículoController(IClienteArtículoService clienteArticuloService)
        {
            _clienteArticuloService = clienteArticuloService;
        }




        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var rsp = new Response<ClienteArtículo>();
            try
            {
                var clienteArtículo = await _clienteArticuloService.Obtener(id);
                if (clienteArtículo == null)
                {
                    rsp.status = false;
                    rsp.msg = "Cliente no encontrado";
                }
                else
                {
                    rsp.status = true;
                    rsp.value = clienteArtículo;
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
            var rsp = new Response<IEnumerable<ClienteArtículo>>();
            try
            {
                var clienteArtículos = await _clienteArticuloService.ObtenerTodos();
                rsp.status = true;
                rsp.value = clienteArtículos;
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
        public async Task<IActionResult> Guardar([FromBody] ClienteArtículo clienteArticulo)
        {
            var rsp = new Response<ClienteDTO>();
            try
            {

                rsp.status = true;
                rsp.value = await _clienteArticuloService.Insertar(clienteArticulo);
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
        public async Task<IActionResult> Editar([FromBody] ClienteArtículo clienteArticulo)
        {
            var rsp = new Response<bool>();
            try
            {

                rsp.status = true;
                rsp.value = await _clienteArticuloService.Actualizar(clienteArticulo);
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
                rsp.value = await _clienteArticuloService.Eliminar(id);
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
