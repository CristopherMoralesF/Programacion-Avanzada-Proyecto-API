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
    
    public partial class ASIENTO_LINEA
    {
        public int ID_ASIENTO_LINEA { get; set; }
        public int ID_ASIENTO { get; set; }
        public string ID_CUENTA_CONTABLE { get; set; }
        public string DESCRIPCION_LINEA { get; set; }
        public double DEBITO { get; set; }
        public double CREDITO { get; set; }
    
        public virtual ASIENTO ASIENTO { get; set; }
        public virtual CUENTA_CONTABLE CUENTA_CONTABLE { get; set; }
    }
}
