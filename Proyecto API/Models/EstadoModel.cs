using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_API.Models
{
    public class EstadoModel
    {
        public List<EstadoEnt> consultarEstados()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<EstadoEnt> listaEstados = new List<EstadoEnt>();

                foreach (var estado in conexion.ESTADO.ToList())
                {
                    listaEstados.Add(new EstadoEnt
                    {
                        idEstado = estado.ID_ESTADO,
                        descripcionEstado = estado.DESCRIPCION_ESTADO
                    });
                }

                return listaEstados;
            }
        }

        public EstadoEnt consultarEstadoActivos(int idEstado)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                
                var resultado = (from x in conexion.ESTADO
                                 where x.ID_ESTADO == idEstado select x).FirstOrDefault();  

                EstadoEnt estadoOutput = new EstadoEnt();

                estadoOutput.idEstado = resultado.ID_ESTADO;
                estadoOutput.descripcionEstado = resultado.DESCRIPCION_ESTADO;

                return estadoOutput;

            }

        }
    }

}