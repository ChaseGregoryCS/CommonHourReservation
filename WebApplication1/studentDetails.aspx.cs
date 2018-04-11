using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CHR
{
    public partial class studentDetails : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Users.isAdmin(Page.User.Identity.Name))
                Response.Redirect("adminsessionlist.aspx");

            if (!Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();
            else
            {
                var stud = CHR.Master.ReturnStudent(Convert.ToInt32(Page.User.Identity.Name));

                litStuName.Text = stud.FirstName + " " + stud.LastName;
                litStuId.Text = stud.Id.ToString();
                litStuEmail.Text = stud.Email;

                if (!IsPostBack)
                    rptStudentSessDataBind();
            }
        }

        protected void btnUnReserve_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            HiddenField hidId = item.FindControl("hidSessId") as HiddenField;

            var sessId = Convert.ToInt32(hidId.Value);
            var stu = CHR.Master.ReturnStudent(Convert.ToInt32(Page.User.Identity.Name));

            CHR.Master.RemoveRegistrationRecord(stu.Id, sessId);
            rptStudentSessDataBind();
        }

        protected void btnUnReserveAll_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptStudentSess.Items)
            {
                HiddenField hidId = item.FindControl("hidSessId") as HiddenField;

                var sessId = Convert.ToInt32(hidId.Value);
                var stu = CHR.Master.ReturnStudent(Convert.ToInt32(Page.User.Identity.Name));

                CHR.Master.RemoveRegistrationRecord(stu.Id, sessId);
            }

            rptStudentSessDataBind();
        }

        public void rptStudentSessDataBind()
        {
            var stud = CHR.Master.ReturnStudent(Convert.ToInt32(Page.User.Identity.Name));

            rptStudentSess.DataSource = stud.regSessions;
            rptStudentSess.DataBind();
        }

    }
}