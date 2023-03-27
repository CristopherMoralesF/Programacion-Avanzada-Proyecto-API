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

        [Route("api/consultarClase")]
        [HttpGet]
        public ClaseEnt consultarClase(int idClase)
        {
            return clasesModel.consultarClase(idClase);
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

        [Route("api/consultarValidacionesClase")]
        [HttpGet]
        public List<ClaseEnt> consultarValidacionesClase()
        {
            return clasesModel.consultarValidacionesClase(); 
        }

        [Route("api/crearValidacionClase")]
        [HttpPost]
        public int crearValidacionClase(ClaseEnt nuevaValidacion)
        {
            return clasesModel.crearValidacionClase(nuevaValidacion);
        }
    }
}