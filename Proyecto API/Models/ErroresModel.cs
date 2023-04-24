using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_API.Models
{
    public class ErroresModel
    {

        public List<ErrorEnt> consultarErrores()
        {

            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<ErrorEnt> listaErrores = new List<ErrorEnt>();

                foreach (var error in conexion.BITACORA_ERRORES.ToList())
                {

                    listaErrores.Add(new ErrorEnt
                    {
                        idError = error.ID_ERROR,
                        pantalla = error.PANTALLA,
                        error = error.ERROR,
                        fecha = (DateTime)error.FECHA
                    });

                }

                return listaErrores; 
            }
        }

        public int reportarError(ErrorEnt error)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                BITACORA_ERRORES errorDB = new BITACORA_ERRORES
                {
                    PANTALLA = error.pantalla,
                    ERROR = error.error, 
                    FECHA = DateTime.Now,
                };

                conexion.BITACORA_ERRORES.Add(errorDB);
                return conexion.SaveChanges(); 

            }

        }

    }
}