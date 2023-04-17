using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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

        public int completarValidacion(ValidacionClaseEnt nuevaValidacion)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                VALIDACION validacion = new VALIDACION();

                validacion.ID_TIPO_VALIDACION = nuevaValidacion.idValidacion;
                validacion.ID_ACTIVO = nuevaValidacion.idActivo;
                validacion.VALOR = nuevaValidacion.valor;

                conexion.VALIDACION.Add(validacion);
                return conexion.SaveChanges();

            }
        }

        public int modificarValidacion(ValidacionClaseEnt validacion)
        {

            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                var validacionEditar = (from x in conexion.VALIDACION
                                               where x.ID_TIPO_VALIDACION == validacion.idValidacion && x.ID_ACTIVO == validacion.idActivo select x).FirstOrDefault();

                validacionEditar.VALOR = validacion.valor;

                return conexion.SaveChanges(); 

            }

        }

    }

}