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
    public class AsientoController : ApiController
    {
        AsientoModel asientoModel = new AsientoModel();

        [Route("api/asientos/consultarAsientos")]
        [HttpGet]
        public List<AsientoEnt> consultarAsientos()
        {
            return asientoModel.consultarAsientos(); 
        }

        [Route("api/asientos/consultarAsiento")]
        [HttpGet]
        public AsientoEnt consultarAsiento(int idAsiento)
        {
            return asientoModel.consultarAsiento(idAsiento);
        }

    }
}
