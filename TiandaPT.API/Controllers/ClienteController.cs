using Microsoft.AspNetCore.Mvc;
using TiandaPT.API.Utilidad;
using TiandaPTCrud.BLL.Service;
using TiandaPTCrud.DTO;
using TiandaPTCrud.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiandaPT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }




        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var rsp = new Response<Cliente>();
            try
            {
                var cliente = await _clienteService.Obtener(id);
                if (cliente == null)
                {
                    rsp.status = false;
                    rsp.msg = "Cliente no encontrado";
                }
                else
                {
                    rsp.status = true;
                    rsp.value = cliente;
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
            var rsp = new Response<IEnumerable<Cliente>>();
            try
            {
                var clientes = await _clienteService.ObtenerTodos();
                rsp.status = true;
                rsp.value = clientes;
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
        public async Task<IActionResult> Guardar([FromBody] Cliente cliente)
        {
            var rsp = new Response<ClienteDTO>();
            try
            {
                
                rsp.status = true;
                rsp.value = await _clienteService.Insertar(cliente);
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
        public async Task<IActionResult> Editar([FromBody] Cliente cliente)
        {
            var rsp = new Response<bool>();
            try
            {

                rsp.status = true;
                rsp.value = await _clienteService.Actualizar(cliente);
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
                rsp.value = await _clienteService.Eliminar(id);
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
