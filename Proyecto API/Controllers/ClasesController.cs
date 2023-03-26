using Proyecto_API.Entities;
using Proyecto_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Proyecto_API.Controllers
{
    public class ClasesController : ApiController
    {
        ClasesModel clasesModel = new ClasesModel();

        [Route("api/ejecutarDepreciacionClase")]
        [HttpPost]
        public List<AuxiliarEnt> ejecutarDepreciacionClase(ClaseEnt clase)
        {
            return clasesModel.ejecutarDepreciacionClase(clase);
        }

        [Route("api/obtenerListaClases")]
        [HttpGet]
        public List<ClaseEnt> obtenerListaClases()
        {
            return clasesModel.obtenerListaClases(); 
        }

        [Route("api/crearClase")]
        [HttpPost]
        public int crearClase(ClaseEnt nuevaClase)
        {
            return clasesModel.crearClase(nuevaClase); 
        }
    }
}