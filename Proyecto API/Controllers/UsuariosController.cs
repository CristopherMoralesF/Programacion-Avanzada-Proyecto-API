using Proyecto_API.Entities;
using Proyecto_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto_API.Controllers
{
    public class UsuariosController : ApiController
    {
        UsuariosModel usuariosModel = new UsuariosModel();

        [Route("api/optenerUsuarios")]
        [Authorize]
        [HttpGet]
        public List<UsuariosEnt> consultarUsuarios()
        {
            return usuariosModel.consultarUsuarios(); 
        }

        [Route("api/consultarUsuario")]
        [Authorize]
        [HttpGet]
        public UsuariosEnt consultarUsuario(int idUsuario)
        {
            return usuariosModel.consultarUsuario(idUsuario);
        }

        [Route("api/validarUsuario")]
        [AllowAnonymous]
        [HttpPost]
        public UsuariosEnt validarUsuario(UsuariosEnt usuarioValidar)
        {
            return usuariosModel.validarUsuario(usuarioValidar);
        }

        [Route("api/crearUsurio")]
        [AllowAnonymous]
        [HttpPost]
        public int crearUsuario(UsuariosEnt usuario)
        {
            return usuariosModel.crearUsuario(usuario);

        }

        [Route("api/buscarCorreo")]
        [AllowAnonymous]
        [HttpGet]
        public string buscarCorreo(string correoElectronico)
        {
            return usuariosModel.buscarCorreo(correoElectronico);
        }

        [Route("api/desactivarUsuario")]
        [HttpGet]
        public int desactivarUsuario(int idUsuairo)
        {
            return usuariosModel.desactivarUsuario(idUsuairo);
        }

        [Route("api/activarUsuario")]
        [Authorize]
        [HttpGet]
        public int activarUsuario(int idUsuario)
        {
            return usuariosModel.activarUsuario(idUsuario);
        }

        [Route("api/actualizarUsuario")]
        [Authorize]
        [HttpPost]
        public int actualizarUsuario(UsuariosEnt usuarioActualizar)
        {
            return usuariosModel.actualizarUsuario(usuarioActualizar); 
        }

        [Route("api/restaurarContrasenna")]
        [AllowAnonymous]
        [HttpPut]
        public int restaurarContraseña(UsuariosEnt usuarioActualizar)
        {
            return usuariosModel.restaurarContraseña(usuarioActualizar);
        }

        [Route("api/cambiarContrasenna")]
        [AllowAnonymous]
        [HttpPut]
        public int cambiarContraseña(UsuariosEnt usuarioActualizar)
        {
            return usuariosModel.cambiarContraseña(usuarioActualizar); 
        }

    }
}
