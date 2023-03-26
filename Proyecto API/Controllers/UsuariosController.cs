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
        [HttpGet]
        public List<UsuariosEnt> consultarUsuarios()
        {
            return usuariosModel.consultarUsuarios(); 
        }

        [Route("api/validarUsuario")]
        [HttpPost]
        public UsuariosEnt validarUsuario(UsuariosEnt usuarioValidar)
        {
            return usuariosModel.validarUsuario(usuarioValidar);
        }

        [Route("api/crearUsurio")]
        [HttpPost]
        public int crearUsuario(UsuariosEnt usuario)
        {
            return usuariosModel.crearUsuario(usuario);

        }

        [Route("api/buscarCorreo")]
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
        [HttpGet]
        public int activarUsuario(int idUsuario)
        {
            return usuariosModel.activarUsuario(idUsuario);
        }

    }
}
