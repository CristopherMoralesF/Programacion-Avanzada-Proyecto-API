using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
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

    }
}