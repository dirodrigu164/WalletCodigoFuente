using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.BO
{
    /// <summary>
    /// objeto de tipo trasnsaccion que contiene los parametros IdTransaccion,
    /// De, Para y cantidad
    /// </summary>
    public class TransaccionBO
    {
        private int intIdTransaccion;
        private string strDe;
        private decimal decCantidad;
        private string strPara;

        public int IdTransaccion { get => intIdTransaccion; set => intIdTransaccion = value; }
        public string De { get => strDe; set => strDe = value; }
        public decimal Cantidad { get => decCantidad; set => decCantidad = value; }
        public string Para { get => strPara; set => strPara = value; }
    }
}
