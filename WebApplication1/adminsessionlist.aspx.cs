using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;

namespace CHR
{
    public partial class adminsessionlist : Page
    {
        private const string ERROR_SESSIONFULL = "Error: Session is full.";
        private const string ERROR_WEEKPREOCCUPIED = "Error: You have already registered for a session in this week.";
        private const string ERROR_GENERIC = "Error: Unable to reserve the session.";
        public void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated || !Users.isAdmin(Page.User.Identity.Name))
                Response.Redirect("adminLogin.aspx");

            if (!IsPostBack)    // Reloading the repeaters on every postback is inefficient.
                rptSessionsBind();

        }
        public void rptSessionsBind(int week = 0)
        {
            if (week == 1 || week == 0)
            {
                var sessionsFirstWeek = CHR.Master.FetchRecordList(CHR.Table.SESSION, 1);
                rptSessWeek1.DataSource = sessionsFirstWeek;
                rptSessWeek1.DataBind();
            }
            if (week == 2 || week == 0)
            {
                var sessionsSecondWeek = CHR.Master.FetchRecordList(CHR.Table.SESSION, 2);
                rptSessWeek2.DataSource = sessionsSecondWeek;
                rptSessWeek2.DataBind();
            }

            if (week == 3 || week == 0)
            {
                var sessionsThirdWeek = CHR.Master.FetchRecordList(CHR.Table.SESSION, 3);
                rptSessWeek3.DataSource = sessionsThirdWeek;
                rptSessWeek3.DataBind();
            }
        }

        public void btnEditSession_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            HiddenField hidSessId = item.FindControl("hidSessId") as HiddenField;
            var id = Convert.ToInt32(hidSessId.Value);

            Response.Redirect("~/AdminEditSession.aspx?id=" + id.ToString());
        }

        public void btnDeleteSession_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            HiddenField hidSessId = item.FindControl("hidSessId") as HiddenField;
            var id = Convert.ToInt32(hidSessId.Value);
            var week = CHR.Master.ReturnSession(id).Week;

            if (CHR.Master.RemoveRecord(id, Table.SESSION))
                rptSessionsBind(week);

        }

    }
}