﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ASSET_MANAGEMENTEntities : DbContext
    {
        public ASSET_MANAGEMENTEntities()
            : base("name=ASSET_MANAGEMENTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ACTIVO> ACTIVO { get; set; }
        public virtual DbSet<ASIENTO> ASIENTO { get; set; }
        public virtual DbSet<ASIENTO_LINEA> ASIENTO_LINEA { get; set; }
        public virtual DbSet<CATEGORIA_CUENTA> CATEGORIA_CUENTA { get; set; }
        public virtual DbSet<CLASE> CLASE { get; set; }
        public virtual DbSet<CLASE_CUENTA> CLASE_CUENTA { get; set; }
        public virtual DbSet<CUENTA_CONTABLE> CUENTA_CONTABLE { get; set; }
        public virtual DbSet<EDIFICIO> EDIFICIO { get; set; }
        public virtual DbSet<ESTADO> ESTADO { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIPO_VALIDACION> TIPO_VALIDACION { get; set; }
        public virtual DbSet<UBICACION> UBICACION { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }
        public virtual DbSet<USUARIO_ROLE> USUARIO_ROLE { get; set; }
        public virtual DbSet<VALIDACION> VALIDACION { get; set; }
        public virtual DbSet<ACCOUNTS_BALANCE_RESUME> ACCOUNTS_BALANCE_RESUME { get; set; }
        public virtual DbSet<ACCOUNTS_RESUME> ACCOUNTS_RESUME { get; set; }
        public virtual DbSet<AUXILIAR_DEPRECIACION> AUXILIAR_DEPRECIACION { get; set; }
        public virtual DbSet<CLASSES_LIST> CLASSES_LIST { get; set; }
        public virtual DbSet<RESUMEN_ACTIVOS> RESUMEN_ACTIVOS { get; set; }
        public virtual DbSet<RESUMEN_ASIENTO_LINEAS> RESUMEN_ASIENTO_LINEAS { get; set; }
        public virtual DbSet<RESUMEN_ASIENTOS> RESUMEN_ASIENTOS { get; set; }
        public virtual DbSet<VALIDACIONES_RESUMEN> VALIDACIONES_RESUMEN { get; set; }
        public virtual DbSet<RESUMEN_USUARIOS> RESUMEN_USUARIOS { get; set; }
        public virtual DbSet<CONCILIACION_BALANCE_CLASE> CONCILIACION_BALANCE_CLASE { get; set; }
        public virtual DbSet<VALIDACION_RIESGO_ACTIVOS> VALIDACION_RIESGO_ACTIVOS { get; set; }
        public virtual DbSet<RESUMEN_ACTIVOS_CLASE> RESUMEN_ACTIVOS_CLASE { get; set; }
        public virtual DbSet<VALIDACION_RIESGO_CLASE> VALIDACION_RIESGO_CLASE { get; set; }
        public virtual DbSet<RESUMEN_VALIDACIONES_COMPLETAS> RESUMEN_VALIDACIONES_COMPLETAS { get; set; }
    
        public virtual int ACTUALIZAR_INFORMACION_VALIDACION(Nullable<int> iN_ID_ACTIVO, Nullable<int> iN_ID_TIPO_VALIDACION, string iN_VALOR_VALIDACION)
        {
            var iN_ID_ACTIVOParameter = iN_ID_ACTIVO.HasValue ?
                new ObjectParameter("IN_ID_ACTIVO", iN_ID_ACTIVO) :
                new ObjectParameter("IN_ID_ACTIVO", typeof(int));
    
            var iN_ID_TIPO_VALIDACIONParameter = iN_ID_TIPO_VALIDACION.HasValue ?
                new ObjectParameter("IN_ID_TIPO_VALIDACION", iN_ID_TIPO_VALIDACION) :
                new ObjectParameter("IN_ID_TIPO_VALIDACION", typeof(int));
    
            var iN_VALOR_VALIDACIONParameter = iN_VALOR_VALIDACION != null ?
                new ObjectParameter("IN_VALOR_VALIDACION", iN_VALOR_VALIDACION) :
                new ObjectParameter("IN_VALOR_VALIDACION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTUALIZAR_INFORMACION_VALIDACION", iN_ID_ACTIVOParameter, iN_ID_TIPO_VALIDACIONParameter, iN_VALOR_VALIDACIONParameter);
        }
    
        public virtual ObjectResult<CORRER_DEPRECIACION_Result> CORRER_DEPRECIACION(Nullable<int> iN_ID_CLASE, string iN_JE_DESCRIPCION)
        {
            var iN_ID_CLASEParameter = iN_ID_CLASE.HasValue ?
                new ObjectParameter("IN_ID_CLASE", iN_ID_CLASE) :
                new ObjectParameter("IN_ID_CLASE", typeof(int));
    
            var iN_JE_DESCRIPCIONParameter = iN_JE_DESCRIPCION != null ?
                new ObjectParameter("IN_JE_DESCRIPCION", iN_JE_DESCRIPCION) :
                new ObjectParameter("IN_JE_DESCRIPCION", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CORRER_DEPRECIACION_Result>("CORRER_DEPRECIACION", iN_ID_CLASEParameter, iN_JE_DESCRIPCIONParameter);
        }
    
        public virtual ObjectResult<ESTATUS_ACTIVOS_Result> ESTATUS_ACTIVOS(Nullable<int> iN_ID_USUARIO)
        {
            var iN_ID_USUARIOParameter = iN_ID_USUARIO.HasValue ?
                new ObjectParameter("IN_ID_USUARIO", iN_ID_USUARIO) :
                new ObjectParameter("IN_ID_USUARIO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ESTATUS_ACTIVOS_Result>("ESTATUS_ACTIVOS", iN_ID_USUARIOParameter);
        }
    
        public virtual ObjectResult<RESUMEN_ASIENTO_LINEAS_BODY_Result> RESUMEN_ASIENTO_LINEAS_BODY(Nullable<int> iN_ASIENTO_ID)
        {
            var iN_ASIENTO_IDParameter = iN_ASIENTO_ID.HasValue ?
                new ObjectParameter("IN_ASIENTO_ID", iN_ASIENTO_ID) :
                new ObjectParameter("IN_ASIENTO_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RESUMEN_ASIENTO_LINEAS_BODY_Result>("RESUMEN_ASIENTO_LINEAS_BODY", iN_ASIENTO_IDParameter);
        }
    
        public virtual ObjectResult<VALIDAR_USUARIO_Result> VALIDAR_USUARIO(string iN_EMAIL, string iN_CONTRASENNA)
        {
            var iN_EMAILParameter = iN_EMAIL != null ?
                new ObjectParameter("IN_EMAIL", iN_EMAIL) :
                new ObjectParameter("IN_EMAIL", typeof(string));
    
            var iN_CONTRASENNAParameter = iN_CONTRASENNA != null ?
                new ObjectParameter("IN_CONTRASENNA", iN_CONTRASENNA) :
                new ObjectParameter("IN_CONTRASENNA", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VALIDAR_USUARIO_Result>("VALIDAR_USUARIO", iN_EMAILParameter, iN_CONTRASENNAParameter);
        }
    
        public virtual int ACTIVAR_USUARIO(Nullable<int> iD_USUARIO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ACTIVAR_USUARIO", iD_USUARIOParameter);
        }
    
        public virtual int DESACTIVAR_USUARIO(Nullable<int> iD_USUARIO)
        {
            var iD_USUARIOParameter = iD_USUARIO.HasValue ?
                new ObjectParameter("ID_USUARIO", iD_USUARIO) :
                new ObjectParameter("ID_USUARIO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DESACTIVAR_USUARIO", iD_USUARIOParameter);
        }
    
        public virtual int CREAR_CLASE(string iN_CLASS_DESCRIPTION, string iN_ASSET_ACCOUNT, string iN_DEP_ACUM_ACCOUNT, string iN_EXPENSE_ACCOUNT, Nullable<int> iN_USEFULL_LIFE)
        {
            var iN_CLASS_DESCRIPTIONParameter = iN_CLASS_DESCRIPTION != null ?
                new ObjectParameter("IN_CLASS_DESCRIPTION", iN_CLASS_DESCRIPTION) :
                new ObjectParameter("IN_CLASS_DESCRIPTION", typeof(string));
    
            var iN_ASSET_ACCOUNTParameter = iN_ASSET_ACCOUNT != null ?
                new ObjectParameter("IN_ASSET_ACCOUNT", iN_ASSET_ACCOUNT) :
                new ObjectParameter("IN_ASSET_ACCOUNT", typeof(string));
    
            var iN_DEP_ACUM_ACCOUNTParameter = iN_DEP_ACUM_ACCOUNT != null ?
                new ObjectParameter("IN_DEP_ACUM_ACCOUNT", iN_DEP_ACUM_ACCOUNT) :
                new ObjectParameter("IN_DEP_ACUM_ACCOUNT", typeof(string));
    
            var iN_EXPENSE_ACCOUNTParameter = iN_EXPENSE_ACCOUNT != null ?
                new ObjectParameter("IN_EXPENSE_ACCOUNT", iN_EXPENSE_ACCOUNT) :
                new ObjectParameter("IN_EXPENSE_ACCOUNT", typeof(string));
    
            var iN_USEFULL_LIFEParameter = iN_USEFULL_LIFE.HasValue ?
                new ObjectParameter("IN_USEFULL_LIFE", iN_USEFULL_LIFE) :
                new ObjectParameter("IN_USEFULL_LIFE", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CREAR_CLASE", iN_CLASS_DESCRIPTIONParameter, iN_ASSET_ACCOUNTParameter, iN_DEP_ACUM_ACCOUNTParameter, iN_EXPENSE_ACCOUNTParameter, iN_USEFULL_LIFEParameter);
        }
    }
}
