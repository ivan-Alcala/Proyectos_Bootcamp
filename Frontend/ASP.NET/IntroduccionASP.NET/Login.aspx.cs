using System;
using System.Web.UI;

namespace IntroduccionASP.NET
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = "ivan";
            string password = "123";

            if (txtUsername.Text == username && txtPassword.Text == password)
            {
                // Guardar nombre del usuario en sesión
                Session["Username"] = username;

                // Mostrar popup y redirigir después de aceptar
                string script = @"
                    if (confirm('Inicio de sesión exitoso. Bienvenido, " + username + @"!')) {
                        window.location.href = 'Default.aspx';
                    }";

                ScriptManager.RegisterStartupScript(this, GetType(), "PopupRedirect", script, true);

            }
            else
            {
                lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}