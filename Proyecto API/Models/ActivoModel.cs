using Proyecto_API.Controllers;
using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace Proyecto_API.Models
{
    public class ActivoModel
    {
        ClasesController clasesController = new ClasesController();
        UbicacionController ubicacionController = new UbicacionController();
        UsuariosController usuariosController = new UsuariosController();
        EstadoController estadoController = new EstadoController(); 

        public ActivoEnt consultarActivo(int idActivo)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var activo = (from x in conexion.ACTIVO where 
                              x.ID_ACTIVO.Equals(idActivo) select x).FirstOrDefault();

                ActivoEnt activoOutput = new ActivoEnt();

                activoOutput.idActivo = activo.ID_ACTIVO;
                activoOutput.claseActivo = clasesController.consultarClase(activo.ID_CLASE);
                activoOutput.ubicacionActivo = ubicacionController.consultarUbicacionActivo(activo.ID_UBICACION);
                activoOutput.duennoActivo = usuariosController.consultarUsuario(activo.ID_DUENNO);
                activoOutput.estadoActivo = estadoController.consultarEstadoActivos(activo.ID_ESTADO);
                activoOutput.descripcionActivo = activo.DESCRIPCION_ACTIVO;
                activoOutput.valorAdquisicion = Convert.ToDouble(activo.VALOR_ADQUISICION);
                activoOutput.fechaAdquiscion = (DateTime)activo.FECHA_ADQUISICION;
                activoOutput.periodosDepreciados = (int)activo.PERIODOS_DEPRECIADOS; 

                return activoOutput;
            }
        }

        public List<ActivoEnt> consultarActivos()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<ActivoEnt> listaActivos = new List<ActivoEnt>();

                foreach (var activo in conexion.ACTIVO)
                {
                    listaActivos.Add(new ActivoEnt
                    {
                        idActivo = activo.ID_ACTIVO,
                        claseActivo = clasesController.consultarClase(activo.ID_CLASE),
                        ubicacionActivo = ubicacionController.consultarUbicacionActivo(activo.ID_UBICACION),
                        duennoActivo = usuariosController.consultarUsuario(activo.ID_DUENNO),
                        estadoActivo = estadoController.consultarEstadoActivos(activo.ID_ESTADO),
                        descripcionActivo = activo.DESCRIPCION_ACTIVO,
                        valorAdquisicion = Convert.ToDouble(activo.VALOR_ADQUISICION),
                        fechaAdquiscion = (DateTime)activo.FECHA_ADQUISICION,
                        periodosDepreciados = (int)activo.PERIODOS_DEPRECIADOS
                    });
                }


                return listaActivos; 
            }
        }

        public int crearActivo(ActivoEnt activo)
        {

            using(var conexion = new ASSET_MANAGEMENTEntities())
            {
                conexion.ACTIVO.Add(new ACTIVO
                {
                    ID_ACTIVO = activo.idActivo,
                    ID_CLASE = activo.claseActivo.idClase,
                    ID_UBICACION = activo.ubicacionActivo.idUbicacíon,
                    ID_DUENNO = activo.duennoActivo.idUsuario,
                    ID_ESTADO = activo.estadoActivo.idEstado,
                    DESCRIPCION_ACTIVO = activo.descripcionActivo,
                    VALOR_ADQUISICION = activo.valorAdquisicion,
                    FECHA_ADQUISICION = activo.fechaAdquiscion,
                    PERIODOS_DEPRECIADOS = activo.periodosDepreciados
                });

                return conexion.SaveChanges(); 
            }

        }

    }
}