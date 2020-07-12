using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.Simples;
using moneyucab_portalweb_back.Comandos.ComandosService.Login.ConsultasDAO;
using moneyucab_portalweb_back.EntitiesForm;
using moneyucab_portalweb_back.Comandos;
using Excepciones;
using NpgsqlTypes;
using Microsoft.AspNetCore.Authorization;

namespace moneyucab_portalweb_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BilleteraController : ControllerBase
    {
        [HttpPost] // api/Billetera/cuenta
        [Authorize]
        [Route("Cuenta")]
        public async Task<IActionResult> CuentaAsync([FromBody]BilleteraCuenta BilleteraCuenta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Registrar_Cuenta(BilleteraCuenta.idUsuario, BilleteraCuenta.idTipoCuenta, BilleteraCuenta.idBanco, BilleteraCuenta.numero).Ejecutar();
                return Ok(new { key = "RegistoCuenta", message = "Registro exitoso" , result});

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

        [HttpPost] // api/Billetera/tarjeta
        [Authorize]
        [Route("tarjeta")]
        public async Task<IActionResult> TarjetaAsync([FromBody]BilleteraTarjeta billeteraTarjeta) //No estoy claro de si aca se usa [frombody] o [fromform]
        {


            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Registrar_Tarjeta(billeteraTarjeta.idUsuario, billeteraTarjeta.idTipoTarjeta, billeteraTarjeta.idBanco,
                    billeteraTarjeta.numero, new NpgsqlDate(billeteraTarjeta.ano, billeteraTarjeta.mes, billeteraTarjeta.dia), billeteraTarjeta.cvc, billeteraTarjeta.estatus).Ejecutar();
                return Ok(new { key = "RegistoTarjeta", message = "Registro exitoso", result  });
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

        //Comando inválido por los momentos
        [HttpDelete] // api/Billetera/eliminarcuenta
        [Authorize]
        [Route("EliminarCuenta")]
        public async Task<IActionResult> EliminarCuentaAsync([FromQuery]int CuentaId)
        {


            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Eliminar_Cuenta(CuentaId).Ejecutar();
                return Ok(new { key = "EliminacionTarjeta", message = "Eliminacion exitosa", result });

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

        [HttpDelete] // api/Billetera/eliminartarjeta
        [Authorize]
        [Route("EliminarTarjeta")]
        public async Task<IActionResult> EliminarTarjetaAsync([FromQuery]int TarjetaId)
        {


            try
            {
                var result = await FabricaComandos.Fabricar_Cmd_Eliminar_Tarjeta(TarjetaId).Ejecutar();
                return Ok(new { key = "EliminacionTarjeta", message = "Eliminacion exitosa", result });
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