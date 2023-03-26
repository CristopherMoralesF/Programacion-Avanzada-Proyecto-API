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
    
    public partial class CUENTA_CONTABLE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUENTA_CONTABLE()
        {
            this.ASIENTO_LINEA = new HashSet<ASIENTO_LINEA>();
            this.CLASE_CUENTA = new HashSet<CLASE_CUENTA>();
        }
    
        public string ID_CUENTA { get; set; }
        public string DESCRIPCION_CUENTA { get; set; }
        public int ID_CATEGORIA { get; set; }
        public Nullable<double> TOTAL_DEBITOS { get; set; }
        public Nullable<double> TOTAL_CREDITOS { get; set; }
        public Nullable<double> BALANCE { get; set; }
        public string NATURALEZA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASIENTO_LINEA> ASIENTO_LINEA { get; set; }
        public virtual CATEGORIA_CUENTA CATEGORIA_CUENTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASE_CUENTA> CLASE_CUENTA { get; set; }
    }
}