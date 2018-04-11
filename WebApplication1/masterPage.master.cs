using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CHR
{
    public partial class masterPage : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                try
                {
                    var stu = CHR.Master.ReturnStudent(Convert.ToInt32(Page.User.Identity.Name));

                    btnLogout.Visible = true;
                    lblWelcome.Text = "Welcome, " + stu.FirstName;
                }
                catch(Exception) // If we're authenticated and stu is null, the user is an administrator.
                {
                    lblWelcome.Text = "Welcome, " + Page.User.Identity.Name;
                    btnLogout.Visible = true;
                }
            }
            else
            {
                lblWelcome.Text = "Welcome, Guest";
                btnLogout.Visible = false;
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            lblWelcome.Text = "Welcome, Guest";
            btnLogout.Visible = false;
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}