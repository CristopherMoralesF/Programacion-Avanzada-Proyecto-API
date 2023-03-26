using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;

namespace Proyecto_API.Entities
{
    public class AsientoEnt
    {
        public int idAsiento {get;set;}
        public DateTime fecha { get;set;}
        public string descripcion { get;set;}

    }
}