//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_API.ModelDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.ACTIVO = new HashSet<ACTIVO>();
        }
    
        public int ID_USUARIO { get; set; }
        public string NOMBRE { get; set; }
        public string CORREO { get; set; }
        public string CONTRASENNA { get; set; }
        public int ID_ROLE { get; set; }
        public int ESTADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVO> ACTIVO { get; set; }
        public virtual USUARIO_ROLE USUARIO_ROLE { get; set; }
    }
}
