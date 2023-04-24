using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Proyecto_API.Models
{
    public class ClasesModel
    {

        public List<ClaseEnt> obtenerListaClases()
        {

            using(var conexion = new ASSET_MANAGEMENTEntities())
            {

                //Create the variable to populate all classes information. 
                List<ClaseEnt> clases = new List<ClaseEnt>();    

                //Recover the classes from the database and include each line in the output variable. 
                foreach(var clase in conexion.CLASSES_LIST.ToList())
                {
                    clases.Add(new ClaseEnt
                    {
                        idClase = clase.ID_CLASE,
                        descripcionClase = clase.DESCRIPCION_CLASE,
                        vidaUtil = (int)clase.VIDA_UTIL,
                        cuentaActivo = new CuentaContableEnt {idCuenta = clase.CUENTA_ACTIVO },
                        cuentaGasto = new CuentaContableEnt { idCuenta = clase.CUENTA_GASTO },
                        cuentaDepAcumulada = new CuentaContableEnt { idCuenta = clase.CUENTA_DEP_ACUMULADA}
                    });
                }

                return clases;

            }

        }

        public int crearClase (ClaseEnt nuevaClase)
        {
            using(var conexion = new ASSET_MANAGEMENTEntities())
            {

                conexion.CREAR_CLASE(
                    nuevaClase.descripcionClase, 
                    nuevaClase.cuentaActivo.idCuenta, 
                    nuevaClase.cuentaDepAcumulada.idCuenta, 
                    nuevaClase.cuentaGasto.idCuenta, 
                    nuevaClase.vidaUtil
                );
               
                return conexion.SaveChanges();

            }
        }

        public List<ValidacionClaseEnt> consultarValidacionesClase(int idClase)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                var validacionesClase = (from x in conexion.TIPO_VALIDACION
                                         where x.ID_CLASE == idClase select x).ToList();

                List<ValidacionClaseEnt> listaValidaciones = new List<ValidacionClaseEnt>();


                foreach (var validacion in validacionesClase)
                {

                    listaValidaciones.Add(new ValidacionClaseEnt
                    {
                        idValidacion = validacion.ID_TIPO_VALIDACION,
                        descripcionValidacion = validacion.DESCRIPCION_VALIDACION
                    });
                }


                return listaValidaciones;

            }
        }

        public ClaseEnt consultarClase(int idClase)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var clase = (from x in conexion.CLASE
                             where x.ID_CLASE == idClase select x).FirstOrDefault();

                ClaseEnt claseOutput = new ClaseEnt();

                claseOutput.idClase = clase.ID_CLASE;
                claseOutput.descripcionClase = clase.DESCRIPCION_CLASE;
                claseOutput.vidaUtil = (int)clase.VIDA_UTIL; 
                claseOutput.listaValidaciones = consultarValidacionesClase(clase.ID_CLASE);

                return claseOutput;
            }
        }
        
        public List<AuxiliarEnt> ejecutarDepreciacionClase(ClaseEnt clase)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                
                //Run depreciation
                conexion.CORRER_DEPRECIACION(clase.idClase, clase.asientoDepreciacion.descripcion);

                //Get the assets subledger with the new depreciation. 
                var resultados = (from x in conexion.AUXILIAR_DEPRECIACION
                                  where x.ID_CLASE == clase.idClase select x).ToList();

                //Create the object to return the result
                List<AuxiliarEnt> nuevoAuxiliar = new List<AuxiliarEnt>();

                foreach (var linea in resultados)
                {
                    nuevoAuxiliar.Add(new AuxiliarEnt
                    {
                        descripcionActivo = linea.DESCRIPCION_ACTIVO,
                        valorAdquisicion = linea.VALOR_ADQUISICION,
                        fechaAdquisicion = (DateTime)linea.FECHA_ADQUISICION, 
                        periodosDepreciados = (int)linea.PERIODOS_DEPRECIADOS, 
                        descripcionClase = linea.DESCRIPCION_CLASE,
                        vidaUtil = (int)linea.VIDA_UTIL, 
                        idClase = linea.ID_CLASE,
                        depreciacionMensual = Convert.ToDouble(linea.DEPRECIACION_MENSUAL),
                        depreciacionAcumulada = Convert.ToDouble(linea.DEPRECIACION_ACUMULADA)
                    });
                }

                return nuevoAuxiliar; 

            }
        }

        public List<ClaseEnt> consultarValidacionesClase()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                List<ClaseEnt> validaciones = new List<ClaseEnt>(); 

                foreach (var validacion in conexion.VALIDACIONES_RESUMEN.ToList())
                {

                    validaciones.Add(new ClaseEnt
                    {
                        idClase= validacion.ID_CLASE,
                        descripcionClase = validacion.DESCRIPCION_CLASE,
                        validacionClase = new ValidacionClaseEnt
                        {
                            idValidacion = validacion.ID_TIPO_VALIDACION,
                            descripcionValidacion = validacion.DESCRIPCION_VALIDACION
                        }

                    });

                }

                return validaciones;

            }

        }
        
        public int crearValidacionClase(ClaseEnt clase)
        {

            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                TIPO_VALIDACION VALIDACION = new TIPO_VALIDACION();

                VALIDACION.ID_CLASE = clase.idClase;
                VALIDACION.DESCRIPCION_VALIDACION = clase.validacionClase.descripcionValidacion;

                conexion.TIPO_VALIDACION.Add(VALIDACION);

                return conexion.SaveChanges();

            }

        }
        
    }
}