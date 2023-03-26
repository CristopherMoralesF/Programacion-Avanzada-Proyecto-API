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
    public class ConciliacionController : ApiController
    {

        ConciliacionModel conciliacionModel = new ConciliacionModel();

        [Route("api/consultarConciliacion")]
        [HttpGet]
        public List<ConciliacionEnt> consultarConciliacion()
        {
            return conciliacionModel.consultarConciliacion();
        }

    }
}
