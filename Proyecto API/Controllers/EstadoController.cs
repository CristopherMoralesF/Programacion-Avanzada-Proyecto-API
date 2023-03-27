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
    public class EstadoController : ApiController
    {
        EstadoModel estadoModel = new EstadoModel();

        [Route("api/estadoActivo/consultarEstados")]
        [HttpGet]
        public List<EstadoEnt> consultarEstados()
        {
            return estadoModel.consultarEstados();
        }

        [Route("api/estadoActivo/consultarEstadoActivos")]
        [HttpGet]
        public EstadoEnt consultarEstadoActivos(int idEstado)
        {
            return estadoModel.consultarEstadoActivos(idEstado);
        }
    }
}
