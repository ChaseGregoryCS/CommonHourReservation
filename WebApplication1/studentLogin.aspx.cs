using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CHR
{
    public partial class studentLogin : Page
    {
        public void AuthenticateStudent(object sender, AuthenticateEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(StudentLogin.UserName.Replace("@", string.Empty));

                var stu = CHR.Master.ReturnStudent(id);

                if (stu != null && stu.Email != null)
                {
                    if (stu.Email == StudentLogin.Password.Replace("@scots.edinboro.edu", string.Empty))
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectFromLoginPage(StudentLogin.UserName.Replace("@", string.Empty), StudentLogin.RememberMeSet);
                    }
                    else
                        StudentLogin.FailureText = "Invalid Email.";
                }
                else
                {
                    StudentLogin.FailureText = "ERROR: You entered an invalid email and/or id number.";
                }
            }
            catch(Exception)
            {
                StudentLogin.FailureText = "ERROR: You entered an invalid email and/or id number.";
            }

        }
      
    }
}