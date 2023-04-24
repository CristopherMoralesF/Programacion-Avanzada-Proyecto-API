using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Proyecto_API.Models
{
    public class CuentaContableModel
    {

        public List<CuentaContableEnt> consultarCuentas()
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                List<CuentaContableEnt> cuentasContables = new List<CuentaContableEnt>();
                
                foreach(var cuentaContable in conexion.CUENTA_CONTABLE.ToList())
                {

                    CategoriaCuentaEnt nuevaCategoria = new CategoriaCuentaEnt();
                    nuevaCategoria.idCategoria = cuentaContable.ID_CATEGORIA;

                    cuentasContables.Add(new CuentaContableEnt
                    {

                        idCuenta = cuentaContable.ID_CUENTA,
                        descripcionCuenta = cuentaContable.DESCRIPCION_CUENTA,
                        categoriaCuenta = nuevaCategoria,
                        totalDebitos = Convert.ToDouble(cuentaContable.TOTAL_DEBITOS),
                        totalCreditos = Convert.ToDouble(cuentaContable.TOTAL_CREDITOS),
                        balance = Convert.ToDouble(cuentaContable.BALANCE), 
                        naturaleza = cuentaContable.NATURALEZA
                    });

                }

                return cuentasContables;

            }
        }

        public int crearCuenta (CuentaContableEnt nuevaCuenta)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {

                CUENTA_CONTABLE cuenta = new CUENTA_CONTABLE();

                cuenta.ID_CUENTA = nuevaCuenta.idCuenta;
                cuenta.DESCRIPCION_CUENTA = nuevaCuenta.descripcionCuenta;
                cuenta.ID_CATEGORIA = nuevaCuenta.categoriaCuenta.idCategoria;
                cuenta.NATURALEZA = nuevaCuenta.naturaleza;
                cuenta.BALANCE = 0;
                cuenta.TOTAL_DEBITOS = 0;
                cuenta.TOTAL_CREDITOS = 0; 

                conexion.CUENTA_CONTABLE.Add(cuenta);
                return conexion.SaveChanges(); 

            }
        }

        public CuentaContableEnt buscarCuenta(string idCuenta)
        {
            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var resultado = (from x in conexion.CUENTA_CONTABLE
                                 where x.ID_CUENTA == idCuenta select x).FirstOrDefault();  

                CuentaContableEnt resultadoCuenta = new CuentaContableEnt();

                if(resultado != null)
                {
                    resultadoCuenta.idCuenta = resultado.ID_CUENTA;
                    resultadoCuenta.descripcionCuenta = resultado.DESCRIPCION_CUENTA;
                    resultadoCuenta.categoriaCuenta = new CategoriaCuentaEnt {idCategoria = resultado.ID_CATEGORIA};
                    resultadoCuenta.totalDebitos = Convert.ToDouble(resultado.TOTAL_DEBITOS);
                    resultadoCuenta.totalCreditos = Convert.ToDouble(resultado.TOTAL_CREDITOS);
                    resultadoCuenta.balance = Convert.ToDouble(resultado.BALANCE);
                    resultadoCuenta.naturaleza = resultado.NATURALEZA;

                    return resultadoCuenta;

                }

                return null; 

            }
        }

        public Boolean validarCuentaContableClase(string idCuenta) {

            using (var conexion = new ASSET_MANAGEMENTEntities())
            {
                var resultado = (from x in conexion.CLASE_CUENTA where x.ID_CUENTA == idCuenta select x).ToList();


                if(resultado.Count > 0)
                {
                    return false;
                } else
                {
                    return true; 
                }
            }
        
        }

    }
}