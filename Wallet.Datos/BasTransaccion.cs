using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.BO;

namespace Wallet.Datos
{
    public class BasTransaccion
    {
        SqlConnection Conexion = null;
        SqlTransaction Transaccion = null;

        private TransaccionBO objTransaccionesBO = new TransaccionBO();
        public TransaccionBO TransaccionesBO { get => objTransaccionesBO; set => objTransaccionesBO = value; }

        public BasTransaccion() { }
        public BasTransaccion(SqlConnection pConexion, SqlTransaction pTransaccion)
        {
            Conexion = pConexion;
            Transaccion = pTransaccion;
        }

        public bool Insertar(TransaccionBO objTransaccionBO)
        {
            bool resultado = false;
            SqlCommand cmd = new SqlCommand("");
            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@De";
            p1.Value = objTransaccionBO.De;
            p1.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@Para";
            p2.Value = objTransaccionBO.Para;
            p2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(p2);

            p2 = new SqlParameter();
            p2.ParameterName = "@Cantidad";
            p2.Value = objTransaccionBO.Cantidad;
            p2.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(p2);

            int resul = cmd.ExecuteNonQuery();
            if (resul > 0)
            {
                resultado = true;
            }

            return resultado;
        }

        public TransaccionBO Consultar(TransaccionBO objTransaccionBO)
        {

            SqlCommand cmd = new SqlCommand("");
            cmd.Connection = Conexion;
            cmd.Transaction = Transaccion;
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "@De";
            cmd.Parameters.Add(p1);
            using (IDataReader dt = cmd.ExecuteReader())
            {
                while (dt.Read())
                {
                    objTransaccionBO.De = dt["De"].ToString();
                    objTransaccionBO.Cantidad = Convert.ToDecimal(dt["Cantidad"].ToString());
                }
            }

            return objTransaccionBO;
        }

    }
}
