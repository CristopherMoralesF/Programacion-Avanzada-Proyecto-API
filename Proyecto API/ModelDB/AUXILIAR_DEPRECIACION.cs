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
    
    public partial class AUXILIAR_DEPRECIACION
    {
        public string DESCRIPCION_ACTIVO { get; set; }
        public double VALOR_ADQUISICION { get; set; }
        public Nullable<System.DateTime> FECHA_ADQUISICION { get; set; }
        public Nullable<int> PERIODOS_DEPRECIADOS { get; set; }
        public string DESCRIPCION_CLASE { get; set; }
        public Nullable<int> VIDA_UTIL { get; set; }
        public int ID_CLASE { get; set; }
        public Nullable<double> DEPRECIACION_MENSUAL { get; set; }
        public Nullable<double> DEPRECIACION_ACUMULADA { get; set; }
        public int ID_ACTIVO { get; set; }
    }
}
