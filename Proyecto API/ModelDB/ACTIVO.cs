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
    
    public partial class ACTIVO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACTIVO()
        {
            this.VALIDACION = new HashSet<VALIDACION>();
        }
    
        public int ID_ACTIVO { get; set; }
        public int ID_CLASE { get; set; }
        public int ID_UBICACION { get; set; }
        public int ID_DUENNO { get; set; }
        public int ID_ESTADO { get; set; }
        public string DESCRIPCION_ACTIVO { get; set; }
        public double VALOR_ADQUISICION { get; set; }
        public Nullable<System.DateTime> FECHA_ADQUISICION { get; set; }
        public Nullable<int> PERIODOS_DEPRECIADOS { get; set; }
    
        public virtual CLASE CLASE { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual ESTADO ESTADO { get; set; }
        public virtual UBICACION UBICACION { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VALIDACION> VALIDACION { get; set; }
    }
}