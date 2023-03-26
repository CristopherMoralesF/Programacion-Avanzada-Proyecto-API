using Proyecto_API.Entities;
using Proyecto_API.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
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

                conexion.CUENTA_CONTABLE.Add(cuenta);
                return conexion.SaveChanges(); 

            }
        }

    }
}