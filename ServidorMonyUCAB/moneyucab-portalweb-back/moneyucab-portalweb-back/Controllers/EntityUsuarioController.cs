using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Excepciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Utilidades;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]  //api/datosusuario
    [ApiController]
    public class EntityUsuarioController : ControllerBase
    {
        private readonly EntityDatosUsuario _comandoDatosUsuario;

        public EntityUsuarioController(EntityDatosUsuario ComandoDatosUsuario)
        {
            _comandoDatosUsuario = ComandoDatosUsuario;
        }

        [HttpGet] // api/EntityUsuario/consultar
        [Route("Consultar")]
        public IActionResult Consultar()
        {
            try
            {
                var resultado = _comandoDatosUsuario.Consultar();
                return Ok(resultado);
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpPost] //api/EntityUsuario/insertar
        [Route("Insertar")]
        public IActionResult Agregar([FromBody] DatosUsuario DatosUsuario)
        {
            try {
                var resultado = _comandoDatosUsuario.Insertar(DatosUsuario);
                return Ok(new { key = "InsertionSuccess", message = "¡Inserción exitosa!", resultado});
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }

        }

        [HttpPut] //api/EntityUsuario/editar
        [Route("Editar")]
        public IActionResult Editar([FromBody] DatosUsuario DatosUsuario)
        {
            try
            {
                var resultado = _comandoDatosUsuario.Editar(DatosUsuario);
                return Ok(new { key = "ModificationSuccess", message = "¡Modificación exitosa!", resultado});
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }

        [HttpDelete]  // api/DatosUsuario/eliminar/5
        [Route("eliminar/{IdUsuario}")]
        public IActionResult Eliminar(int IdUsuario) //NoticiaID igual qeu ene el route
        {
            try{
                var resultado = _comandoDatosUsuario.Eliminar(IdUsuario);
                return Ok(new { key = "EliminationSuccess", message = "¡Eliminación exitosa!", resultado });
            }
            catch (MoneyUcabException ex)
            {
                return BadRequest(ex.Response());
            }
            catch (Exception ex)
            {
                return BadRequest(MoneyUcabException.ResponseErrorDesconocido(ex));
            }
        }
    }
}