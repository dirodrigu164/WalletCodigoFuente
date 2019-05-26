using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wallet.Negocio;

namespace Wallet.Web
{
    public partial class Contact : Page
    {

        /// <summary>
        /// Inicialización de las propiedades 
        /// </summary>
        

        protected void Page_Load(object sender, EventArgs e)
        {

           
            if (!IsPostBack)
            {
                divTransaccion.Style.Add("display", "none");
                divBotones.Style.Add("display", "none");
                divVolver.Style.Add("display", "none");
                divSaldo.Style.Add("display", "none");
                ClientScript.RegisterStartupScript(this.GetType(), "Nombre", "<script> Ocultar(); </script>");
                if (Request.QueryString["Consulta"] == "0")
                    Response.Write("<script>alert('Registrado');</script>");
                if (Request.QueryString["Consulta"] == "1")
                    Response.Write("<script>alert('Transacción completada');</script>");
                else if (Request.QueryString["Consulta"] == "2")
                {
                    txtSaldo.Text = Session["CargueInicial"].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "Buscar", "<script> Buscar(); </script>");
                }
                else if (Request.QueryString["Consulta"] == "3")
                {
                    txtDe.Text = Session["LlavePublicaEncriptada"].ToString();
                    ClientScript.RegisterStartupScript(this.GetType(), "Transa", "<script> Transa(); </script>");
                }else if (Request.QueryString["Consulta"] == "4")
                    ClientScript.RegisterStartupScript(this.GetType(), "Ocultar", "<script> Ocultar(); </script>");
                
            }
        }

        /// <summary>
        /// Método que envía como parámetros get la llave publica,de,para y BTC, 
        /// además envía como parámetro consulta 1 si la transacción ha sido exitosa 
        /// </summary>

        protected void btnEnviar_Click(object sender, EventArgs e)
        {

            Transacciones objTransacciones = new Transacciones();
            decimal Saldo = objTransacciones.CalculosTrasanccion(Session["NombreWallet"].ToString(), txtPara.Text, Convert.ToDecimal(txtBtc.Text));
            if (Convert.ToDecimal(Session["CargueInicial"]) > Convert.ToDecimal(txtBtc.Text))
            {
                Session["CargueInicial"] = Convert.ToDecimal(Session["CargueInicial"]) - Saldo;
                if (Convert.ToDecimal(Session["CargueInicial"]) < 0)
                    Response.Write("<script>alert('Saldo insuficiente para realizar la transacción ');</script>");
                else
                {
                   
                    Response.Redirect("Contact.aspx?Llave=" + Session["LlavePublicaEncriptada"].ToString() + "&De=NULL&Para=" + Session["LlavePublicaEncriptada"].ToString() + "&BTC=50"+"&Consulta=1");
                }
                
            }else
                Response.Write("<script>alert('Error en transacción');</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "Transa", "<script> Transa(); </script>");
        }
        /// <summary>
        /// Método que consulta el saldo de la wallet y envía como parámetro get consulta=2
        /// </summary>

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
           
            Response.Redirect("Contact.aspx?Consulta=2");
        }
        /// <summary>
        /// Método que abre la transacción a otras wallet y envía por get consulta =3
        /// </summary>

        protected void btnTransaccion_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Contact.aspx?Consulta=3");
        }
        /// <summary>
        /// Método que devuelve a la menú inicial
        /// </summary>
        protected void btnVolver_Click(object sender, EventArgs e)
        {   
            Response.Redirect("Contact.aspx?Consulta=4");
        }
    }
}