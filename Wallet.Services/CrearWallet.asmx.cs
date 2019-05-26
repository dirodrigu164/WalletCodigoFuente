using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Wallet.Services
{
    /// <summary>
    /// Descripción breve de CrearWallet
    /// </summary>
    [WebService(Namespace = "http://Wallet.com/Services")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CrearWallet : System.Web.Services.WebService
    {

        [WebMethod]
        public string CreacionWallet(String pWallet)
        {
            return pWallet;
        }

        [WebMethod]
        public Decimal ConsultaSaldoWallet(Decimal pSaldo)
        {
            return pSaldo;
        }

        [WebMethod]
        public String EjecutarTransaccion(String De, String Para, Decimal Saldo)
        {
            return De+"-"+Para +"-"+Saldo;
        }


    }
}
