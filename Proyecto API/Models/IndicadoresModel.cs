using Proyecto_API.Controllers;
using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_API.Models
{
    public class IndicadoresModel
    {
        ActivoController activoController = new ActivoController();


        public List<IndicadoresRiesgoEnt> validacionRiesgoActivosUsuario(int idUsuario)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                var validaciones = (from x in conexion.VALIDACION_RIESGO_ACTIVOS
                                    where x.ID_DUENNO == idUsuario select x).ToList();

                List<IndicadoresRiesgoEnt> indicadores = new List<IndicadoresRiesgoEnt>();

                foreach (var validacion in validaciones)
                {
                    indicadores.Add(new IndicadoresRiesgoEnt
                    {
                        idActivo = validacion.ID_ACTIVO,
                        idDuenno = validacion.ID_DUENNO,
                        descripcionActivo = validacion.DESCRIPCION_ACTIVO,
                        porcentajeValidacion = Convert.ToDouble(validacion.VALIDATION_PERCENTAJE),
                        validacionRiesgo = validacion.VALIDACION_RIESGO,
                        descripcionClase = validacion.DESCRIPCION_CLASE
                    });
                }

                return indicadores; 

            }
        }

        public List<IndicadoresRiesgoEnt> validacionRiesgoCompannia()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                List<IndicadoresRiesgoEnt> indicadores = new List<IndicadoresRiesgoEnt>();

                foreach (var validacion in conexion.VALIDACION_RIESGO_ACTIVOS)
                {
                    indicadores.Add(new IndicadoresRiesgoEnt
                    {
                        idActivo = validacion.ID_ACTIVO,
                        idDuenno = validacion.ID_DUENNO,
                        descripcionActivo = validacion.DESCRIPCION_ACTIVO,
                        porcentajeValidacion = Convert.ToDouble(validacion.VALIDATION_PERCENTAJE),
                        validacionRiesgo = validacion.VALIDACION_RIESGO
                    });
                }

                return indicadores;

            }
        }

        public List<ClaseEnt> resumenClases()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<ClaseEnt> listaClases = new List<ClaseEnt>();

                foreach (var clase in conexion.RESUMEN_ACTIVOS_CLASE.ToList())
                {
                    listaClases.Add(new ClaseEnt
                    {
                        idClase = clase.ID_CLASE,
                        descripcionClase = clase.DESCRIPCION_CLASE,
                        totalActivos = (int)clase.TOTAL_ACTIVOS,
                    });
                }

                return listaClases; 
            }
        }

        public List<ClaseEnt> resumenClasesRiesgo()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                List<ClaseEnt> listaRiesgosClase= new List<ClaseEnt>();

                foreach (var clase in conexion.VALIDACION_RIESGO_CLASE)
                {
                    listaRiesgosClase.Add(new ClaseEnt
                    {
                        idClase = clase.ID_CLASE,
                        descripcionClase = clase.DESCRIPCION_CLASE,
                        categorizacionRiesgo = clase.VALIDACION_RIESGO,
                        totalActivos = (int)clase.TOTAL_ACTIVOS
                    });

                }

                return listaRiesgosClase;
            }
        }

        public IndicadoresEnt optenerIndicadores(int idUsuario)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var indicadoresHeader = conexion.ESTATUS_ACTIVOS(idUsuario).FirstOrDefault();

                IndicadoresEnt indicadoresOutput = new IndicadoresEnt();

                indicadoresOutput.totalActivos = (int)indicadoresHeader.TOTAL_ACTIVOS;
                indicadoresOutput.totalInversion = Convert.ToDouble(indicadoresHeader.TOTAL_INVERSION);
                indicadoresOutput.porcentajeCumplimineto = Convert.ToDouble(indicadoresHeader.PORCENTAJE_CUMPLIMIENTO);
                indicadoresOutput.totalActivosUsuario = (int)indicadoresHeader.TOTAL_ACTIVOS_USUARIO;
                indicadoresOutput.activosUsuario = validacionRiesgoActivosUsuario(idUsuario);
                indicadoresOutput.activosCompannia = validacionRiesgoCompannia();
                indicadoresOutput.resumenClases = resumenClases(); 
                indicadoresOutput.resumenClasesRiesgo = resumenClasesRiesgo();

                return indicadoresOutput;

            }
        }
    }
}