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
    public class ActivoController : ApiController
    {
        ActivoModel activoModel = new ActivoModel();

        [Route("api/activo/consultarActivo")]
        [HttpGet]
        public ActivoEnt consultarActivo(int idActivo)
        {
            return activoModel.consultarActivo(idActivo);
        }

        [Route("api/activo/consultarActivos")]
        [HttpGet]
        public List<ActivoEnt> consultarActivos()
        {
            return activoModel.consultarActivos();
        }

        [Route("api/activo/consultarAuxiliarActivos")]
        [HttpGet]
        public List<AuxiliarEnt> consultarAuxiliarActivos()
        {
            return activoModel.consultarAuxiliarActivos(); 
        }

        [Route("api/activo/consultarActivosUsuario")]
        [HttpGet]
        public List<ActivoEnt> consultarActivosUsuario(int idUsuario) 
        {
            return activoModel.consultarActivosUsuario(idUsuario);
        }

        [Route("api/activo/crearActivo")]
        [HttpPost]
        public int crearActivo(ActivoEnt nuevoActivo)
        {
            return activoModel.crearActivo(nuevoActivo);
        }    

    }
}
