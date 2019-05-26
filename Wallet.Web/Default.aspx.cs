using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Wallet.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        /// <summary>
        /// Método con el que se crea el registro de la Wallet y se envía por get la llave publica,de,para y BTC. 
        /// La llave publica se encuentra encriptada en SHA 256 que corresponde a las concatenación de las 12 palabras 
        /// </summary>
       
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Session["NombreWallet"] = txtNombreWallet.Text;
            Session["LlavePublica"] = txtPa1.Text + txtPa2.Text + txtPa3.Text + txtPa4.Text + txtPa5.Text + txtPa6.Text + txtPa7.Text + txtPa8.Text + txtPa9.Text + txtPa10.Text + txtPa11.Text + txtPa12.Text;
            Session["LlavePrivada"] = "diego.art2@hotmail.com";
            Session["LlavePublicaEncriptada"] = null;
            Session["LlavePrivadaEncriptada"] = null;
            Session["LlaveTotalEncriptada"] = null;
            Session["CargueInicial"] = 50;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Session["LlavePublica"].ToString()));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Session["LlavePublicaEncriptada"] = builder.ToString();
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Session["LlavePrivada"].ToString()));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Session["LlavePrivadaEncriptada"] = builder.ToString();
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(Session["LlavePublica"].ToString() + Session["LlavePrivada"].ToString()));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Session["LlaveTotalEncriptada"] = builder.ToString();
            }

            Response.Redirect("Contact.aspx?Llave="+ Session["LlavePublicaEncriptada"].ToString()+ "&De=NULL&Para=" + Session["LlavePublicaEncriptada"].ToString()+ "&BTC=50&Consulta=0");
        }
    }
}