using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_API.Models
{
    public class UbicacionModel
    {
        public List<UbicacionEnt> consultarUbicaciones()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<UbicacionEnt> ubicaciones = new List<UbicacionEnt>();

                foreach (var ubicacion in conexion.UBICACION.ToList())
                {

                    ubicaciones.Add(new UbicacionEnt
                    {
                        idUbicacíon = ubicacion.ID_UBICACION,
                        idEdificio = ubicacion.ID_EDIFICIO,
                        descripcionSeccion = ubicacion.DESCRIPCION_SECCION
                    });

                }

                return ubicaciones;
            }

        }

        public UbicacionEnt consultarUbicacionActivo(int idUbicacion)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var resultado = (from x in conexion.UBICACION where x.ID_UBICACION == idUbicacion select x).FirstOrDefault();

                UbicacionEnt ubicacionOutput = new UbicacionEnt
                {
                    idUbicacíon = resultado.ID_UBICACION,
                    idEdificio = resultado.ID_EDIFICIO,
                    descripcionSeccion = resultado.DESCRIPCION_SECCION
                };

                return ubicacionOutput;
            }
        }
    }
}