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
    public class IndicadoresController : ApiController
    {

        IndicadoresModel indicadoresModel = new IndicadoresModel();

        [Route("api/indicadores/optenerIndicadores")]
        [HttpGet]
        public IndicadoresEnt optenerIndicadores(int idUsuario)
        {
            return indicadoresModel.optenerIndicadores(idUsuario);
        }
    }
}
