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
    
    public partial class CONCILIACION_BALANCE_CLASE
    {
        public int ID_CLASE { get; set; }
        public string ID_CUENTA { get; set; }
        public string CATEGORIA_CUENTA { get; set; }
        public string DESCRIPCION_CLASE { get; set; }
        public Nullable<double> BALANCE { get; set; }
        public Nullable<double> VALOR_AUXILIAR { get; set; }
        public Nullable<double> DIFERENCIA { get; set; }
    }
}
