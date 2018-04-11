using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data.MySqlClient;

namespace CHR
{
    public partial class adminLogin : Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated && Users.isAdmin(Page.User.Identity.Name))
                Response.Redirect("adminsessionlist.aspx");

        }
        public void AuthenticateAdmin(object sender, AuthenticateEventArgs e)
        {
            try
                {
                    var adminConn = new MySqlConnection("Server = localhost; Database = commonhourrsvp; Uid = " + AdminLogin.UserName + "; Pwd = " + AdminLogin.Password);

                    try
                    {
                        adminConn.Open();
                        FormsAuthentication.SignOut();
                        FormsAuthentication.SetAuthCookie(AdminLogin.UserName, AdminLogin.RememberMeSet);
                        Response.Redirect("adminsessionlist.aspx");
                        adminConn.Close();
                    }
                    catch (Exception)
                    {
                        AdminLogin.FailureText = "Error: Invalid credentials.";
                    }

                }
                catch (Exception)
                {

                }

            }
        }
}