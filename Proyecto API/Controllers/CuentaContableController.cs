using Proyecto_API.Entities;
using Proyecto_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto_API.Controllers
{
    [Authorize]
    public class CuentaContableController : ApiController
    {
        
        CuentaContableModel cuentaContableModel = new CuentaContableModel();

        [Route("api/cuentas/optenerCuentas")]
        [HttpGet]
        public List<CuentaContableEnt> consultarCuentas()
        {
            return cuentaContableModel.consultarCuentas();
        }

        [Route("api/cuentas/crearCuenta")]
        [HttpPost]
        public int crearCuenta(CuentaContableEnt nuevaCuenta)
        {
            return cuentaContableModel.crearCuenta(nuevaCuenta);
        }

        [Route("api/cuentas/buscarCuenta")]
        [HttpGet]
        public CuentaContableEnt buscarCuenta(string idCuenta)
        {
            return cuentaContableModel.buscarCuenta(idCuenta);
        }

        [Route("api/cuentas/validarCuentaContableClase")]
        [HttpGet]
        public Boolean validarCuentaContableClase(string idCuenta)
        {
            return cuentaContableModel.validarCuentaContableClase(idCuenta); 
        }

    }
}
