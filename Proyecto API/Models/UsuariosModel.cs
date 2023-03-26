using Proyecto_API.ModelDB;
using Proyecto_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Proyecto_API.Models
{
    public class UsuariosModel
    {
        public List<UsuariosEnt> consultarUsuarios()
        {

            using(var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<UsuariosEnt> listaUsuarios = new List<UsuariosEnt>();

                foreach (var usuario in conexion.RESUMEN_USUARIOS.ToList())
                {
                    listaUsuarios.Add(new UsuariosEnt
                    {
                        idUsuario = usuario.ID_USUARIO,
                        nombre = usuario.NOMBRE,
                        correo = usuario.CORREO,
                        role = usuario.NOMBRE_ROLE,
                        estado = usuario.ESTADO
                    }) ;
                }

                return listaUsuarios;

            }
            
        }

        public UsuariosEnt validarUsuario(UsuariosEnt usuario)
        {
            using(var conexion = new ASSET_MANAGEMENTEntities())
            {
                var resultado = (from x in conexion.USUARIO
                                where x.CORREO == usuario.correo &&
                                x.CONTRASENNA == usuario.contraseña
                                && x.ESTADO == 1 select x).FirstOrDefault();

                UsuariosEnt nuevoUsuario = new UsuariosEnt();

                if(resultado != null)
                {
                    nuevoUsuario.nombre = resultado.NOMBRE; 
                    nuevoUsuario.correo = resultado.CORREO;
                    nuevoUsuario.estado = resultado.ESTADO;
                    nuevoUsuario.idRole = resultado.ID_ROLE; 

                    return nuevoUsuario; 
                }

                return null; 

            }
        }

        public int crearUsuario(UsuariosEnt usuario)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                Random rnd = new Random();
                USUARIO nuevoUsuario = new USUARIO();

                nuevoUsuario.CORREO = usuario.correo;
                nuevoUsuario.NOMBRE = usuario.nombre;
                nuevoUsuario.ID_ROLE = Int32.Parse(usuario.role);
                nuevoUsuario.CONTRASENNA = usuario.correo.Substring(0, 3) + rnd.Next(1, 500).ToString();
                nuevoUsuario.ESTADO = 1;

                conexion.USUARIO.Add(nuevoUsuario);
                return conexion.SaveChanges();
            }
        }

        public int activarUsuario(int usuarioID)
        {
            using(var conexion = new ASSET_MANAGEMENTEntities())
            {
                conexion.ACTIVAR_USUARIO(usuarioID);
                return conexion.SaveChanges(); 
            }
        }

        public int desactivarUsuario(int usuarioID)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                conexion.DESACTIVAR_USUARIO(usuarioID);
                return conexion.SaveChanges(); 
            }
        }



        public string buscarCorreo(string CorreoElectronico)
        {
            using(var conexion = new ASSET_MANAGEMENTEntities())
            {
                
                var resultado = (from x in conexion.USUARIO
                                 where x.CORREO== CorreoElectronico
                                 select x).FirstOrDefault();

                if(resultado == null)
                {
                    return string.Empty;
                } else
                {
                    return "El correo selecionado ya existe";
                }
            }
        }

    }
}