using Proyecto_API.ModelDB;
using Proyecto_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Sem1_ProyectoAPI.App_Start;
using System.Net.Mail;
using System.Configuration;

namespace Proyecto_API.Models
{
    public class UsuariosModel
    {
        TokenGenerator generator = new TokenGenerator();

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

        public UsuariosEnt consultarUsuario(int idUsuario)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var usuario = (from x in conexion.RESUMEN_USUARIOS
                               where x.ID_USUARIO== idUsuario select x).FirstOrDefault();

                UsuariosEnt usuarioOutput = new UsuariosEnt
                {
                    idUsuario = usuario.ID_USUARIO,
                    nombre = usuario.NOMBRE,
                    correo = usuario.CORREO,
                    role = usuario.NOMBRE_ROLE,
                    idRole = usuario.ID_ROLE,
                    estado = usuario.ESTADO

                };

                return usuarioOutput;
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
                    nuevoUsuario.idUsuario = resultado.ID_USUARIO;
                    nuevoUsuario.estadoContrasenna = resultado.ESTADO_CONTRASENNA; 
                    nuevoUsuario.Token = generator.GenerateTokenJwt(resultado.CORREO);

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

        public int restaurarContraseña(UsuariosEnt usuario)
        {

            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                Random rnd = new Random();
                USUARIO usuarioModificar = (from x in conexion.USUARIO where 
                                            x.CORREO == usuario.correo select x).FirstOrDefault();

                if (usuarioModificar == null)
                {
                    return 0;
                } else
                {
                    usuarioModificar.ESTADO_CONTRASENNA = 0; 
                    usuarioModificar.CONTRASENNA = usuario.correo.Substring(0, 3) + rnd.Next(1, 500).ToString();
                    
                    return conexion.SaveChanges(); 
                }

            }

        }

        public int cambiarContraseña(UsuariosEnt usuario)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                USUARIO usuarioModificar = (from x in conexion.USUARIO
                                            where x.CORREO == usuario.correo select x).FirstOrDefault();


                usuarioModificar.CONTRASENNA = usuario.contraseña;
                usuarioModificar.ESTADO_CONTRASENNA = 1;

                return conexion.SaveChanges();  

            }
        }

        public string RestablecerContraseñaEmail(USUARIO entidad)
        {

            string correoAutentificacion = ConfigurationManager.AppSettings["correoEmails"];
            string contrasennaAutentificacion = ConfigurationManager.AppSettings["contrasennaEmails"];

            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress(entidad.CORREO, entidad.CORREO));
            msg.From = new MailAddress("cmorales40146@ufide.ac.cr", "Mi Sistema");
            msg.Subject = "Recuperación de Contraseña";
            msg.Body = "Nuestro sistema registro una solicitud de cambio de contraseña, al ingresar, procesa a cambiar su contraseña: " + entidad.CONTRASENNA;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(correoAutentificacion, contrasennaAutentificacion);
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Send(msg);

            return "exito";
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

        public int actualizarUsuario(UsuariosEnt usuarioActualizar)
        {

            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                USUARIO usuarioDB = (from x in conexion.USUARIO
                                     where x.ID_USUARIO == usuarioActualizar.idUsuario select x).FirstOrDefault();


                usuarioDB.NOMBRE = usuarioActualizar.nombre;
                usuarioDB.ID_ROLE = (int)usuarioActualizar.idRole;

                return conexion.SaveChanges(); 

            }

        }

    }
}