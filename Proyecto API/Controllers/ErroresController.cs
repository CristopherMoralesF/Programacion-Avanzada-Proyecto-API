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
    public class ErroresController : ApiController
    {
        ErroresModel erroresModel = new ErroresModel();

        [Route("api/error/optenerErrores")]
        [HttpGet]
        [Authorize]
        public List<ErrorEnt> consultarErrores()
        {
            return erroresModel.consultarErrores();
        }

        [Route("api/error/reportarError")]
        [HttpPost]
        [Authorize]
        public int consultarErrores(ErrorEnt error)
        {
            return erroresModel.reportarError(error);
        }
    }
}
