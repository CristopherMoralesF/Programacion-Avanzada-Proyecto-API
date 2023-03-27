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
    public class UbicacionController : ApiController
    {
        UbicacionModel ubicacionModel = new UbicacionModel();

        [Route("api/ubicacionActivo/consultarUbicaciones")]
        [HttpGet]
        public  List<UbicacionEnt> consultarUbicaciones()
        {
            return ubicacionModel.consultarUbicaciones();
        }

        [Route("api/ubicacionActivo/consultarUbicacionActivo")]
        [HttpGet]
        public UbicacionEnt consultarUbicacionActivo(int idUbicacion)
        {
            return ubicacionModel.consultarUbicacionActivo(idUbicacion);
        }

    }
}
