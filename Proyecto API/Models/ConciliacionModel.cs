using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_API.Models
{
    public class ConciliacionModel
    {

        public List<ConciliacionEnt> consultarConciliacion()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<ConciliacionEnt> conciliacion = new List<ConciliacionEnt>();

                foreach (var resultado in conexion.CONCILIACION_BALANCE_CLASE.ToList())
                {
                    conciliacion.Add(new ConciliacionEnt
                    {
                        idClase = resultado.ID_CLASE,
                        idCuenta = resultado.ID_CUENTA,
                        categoriaCuenta = resultado.CATEGORIA_CUENTA,
                        descripcionClase = resultado.DESCRIPCION_CLASE,
                        balance = Convert.ToDouble(resultado.BALANCE),
                        valorAuxiliar = Convert.ToDouble(resultado.VALOR_AUXILIAR),
                        diferencia = Convert.ToDouble(resultado.DIFERENCIA)

                    }) ;
                }

                return conciliacion;

            }
        }

    }
}