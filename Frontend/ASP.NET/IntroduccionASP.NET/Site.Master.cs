using System;
using System.Web.UI;

namespace IntroduccionASP.NET
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Mostrar nombre del usuario si está autenticado
            if (Session["Username"] != null)
            {
                lblUsername.Text = $"Bienvenido, {Session["Username"]}";
            }
            else
            {
                // Si no hay sesión, redirigir al login
                Response.Redirect("Login.aspx");
            }
        }
    }
}