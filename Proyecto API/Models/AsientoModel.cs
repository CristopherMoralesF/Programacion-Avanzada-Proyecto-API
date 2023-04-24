using Microsoft.Ajax.Utilities;
using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_API.Models
{
    public class AsientoModel
    {

        ClasesModel clasesModel = new ClasesModel(); 

        public List<AsientoEnt> consultarAsientos()
        {
            using(var conexion = new ASSET_MANAGEMENTEntities())
            {

                List<AsientoEnt> asientos = new List<AsientoEnt>();

                foreach (var asiento in conexion.ASIENTO.ToList())
                {
                    List<AsientoLineasEnt> lineasAsiento = new List<AsientoLineasEnt>();

                    var asientoCuerpo = (from x in conexion.ASIENTO_LINEA
                                      where x.ID_ASIENTO == asiento.ID_ASIENTO select x).ToList();  

                    foreach (var linea in asientoCuerpo)
                    {

                        lineasAsiento.Add(new AsientoLineasEnt
                        {
                            idAsientoLinea = linea.ID_ASIENTO_LINEA,
                            idCuentaContable = linea.ID_CUENTA_CONTABLE,
                            descripcionLinea = linea.DESCRIPCION_LINEA,
                            debito = linea.DEBITO,
                            credito = linea.CREDITO
                        });

                    }

                    if (asiento.ID_CLASE == null)
                    {
                        asientos.Add(new AsientoEnt
                        {
                            idAsiento = asiento.ID_ASIENTO,
                            clase = new ClaseEnt { idClase = 0, descripcionClase = "No Activos" },
                            fecha = asiento.FECHA,
                            descripcion = asiento.DESCRIPCION,
                            cuerpoAsiento = lineasAsiento
                        });

                    }
                    else
                    {

                        asientos.Add(new AsientoEnt
                        {
                            idAsiento = asiento.ID_ASIENTO,
                            clase = clasesModel.consultarClase((int)asiento.ID_CLASE),
                            fecha = asiento.FECHA,
                            descripcion = asiento.DESCRIPCION,
                            cuerpoAsiento = lineasAsiento
                        }) ;

                    }



                }

                return asientos;

            }
        }
    
        public AsientoEnt consultarAsiento(int idAsiento)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var asiento = (from x in conexion.ASIENTO where x.ID_ASIENTO == idAsiento select x).FirstOrDefault();
                var asientoLineas = (from y in conexion.ASIENTO_LINEA where y.ID_ASIENTO == idAsiento select y).ToList();

                AsientoEnt asientoOutput = new AsientoEnt();
                List<AsientoLineasEnt> asientoBody = new List<AsientoLineasEnt>(); 

                foreach (var linea in asientoLineas)
                {

                    asientoBody.Add(new AsientoLineasEnt
                    {
                        idAsientoLinea = linea.ID_ASIENTO_LINEA,
                        idCuentaContable = linea.ID_CUENTA_CONTABLE,
                        descripcionLinea = linea.DESCRIPCION_LINEA,
                        debito = Convert.ToDouble(linea.DEBITO),
                        credito = Convert.ToDouble(linea.CREDITO),

                    });

                }

                if (asiento.ID_CLASE == null)
                {
                    asientoOutput.clase = new ClaseEnt { idClase = 0 };
                } else
                {
                    asientoOutput.clase = new ClaseEnt { idClase = (int)asiento.ID_CLASE };
                }
                
                
                asientoOutput.idAsiento = asiento.ID_ASIENTO;
                asientoOutput.fecha = asiento.FECHA;
                asientoOutput.descripcion = asiento.DESCRIPCION;
                asientoOutput.cuerpoAsiento = asientoBody;

                return asientoOutput;

            }
        }
    }
}