using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.BO;
using Wallet.Datos;

namespace Wallet.Negocio
{
    public class Transacciones
    {
        //public bool InsertarTransaccion(TransaccionBO objTransaccionBO)
        //{
        //    SqlConnection Conexion = null;
        //    SqlTransaction Transaccion = null;
        //    using (Conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["Cadena"].ConnectionString))
        //    {
        //        try
        //        {
        //            Conexion.Open();
        //            Transaccion = Conexion.BeginTransaction();
        //            BasTransaccion objBasTransaccion = new BasTransaccion(Conexion,Transaccion);
        //            if (!objBasTransaccion.Insertar(objTransaccionBO))
        //                new Exception("No se pudo inserta la trasaccion");

        //            Transaccion.Commit();
        //            return true;

        //        }
        //        catch (Exception )
        //        {
        //            Transaccion.Rollback();

        //            return false;
        //        }
        //    }


        //}

        /// <summary>
        /// Método que realiza los cálculos para descontar de la wallet 
        /// y que recibe por parámetros “De” de tipo string, “Para” de tipo string y “Saldo” de tipo decimal
        /// </summary>
        /// <param name="De"> tipo string y corresponde a la persona que lo envia</param>
        /// <param name="Para"> tipo string y corresponde a la persona que se le enviara</param>
        /// <param name="Saldo"> tipo Decimal y corresponde al valor que se enviara</param>
        /// <returns> Retorna el valor en decimal</returns>
        public decimal CalculosTrasanccion(String De, String Para, Decimal Saldo)
        {
            Decimal resultado = Decimal.MinValue;
            if (De == Para)
                resultado = 0;
            else
                resultado = Saldo;


            return resultado;
        }
    }
}
