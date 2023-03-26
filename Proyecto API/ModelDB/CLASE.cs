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
    
    public partial class CLASE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CLASE()
        {
            this.ACTIVO = new HashSet<ACTIVO>();
            this.ASIENTO = new HashSet<ASIENTO>();
            this.CLASE_CUENTA = new HashSet<CLASE_CUENTA>();
            this.TIPO_VALIDACION = new HashSet<TIPO_VALIDACION>();
        }
    
        public int ID_CLASE { get; set; }
        public string DESCRIPCION_CLASE { get; set; }
        public Nullable<int> VIDA_UTIL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ACTIVO> ACTIVO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIENTO> ASIENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASE_CUENTA> CLASE_CUENTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIPO_VALIDACION> TIPO_VALIDACION { get; set; }
    }
}