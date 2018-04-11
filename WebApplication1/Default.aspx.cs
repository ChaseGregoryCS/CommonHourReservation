using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace CHR
{
    public partial class studenthomepage : Page
    {
        private const string ERROR_SESSIONFULL = "Error: Session is full.";
        private const string ERROR_WEEKPREOCCUPIED = "Error: You have already registered for a session in this week.";
        private const string ERROR_GENERIC = "Error: Unable to reserve the session.";
        private const string CONFIRM_REG_SUCCESS = "Succesfully registered for: ";
        public void Page_Load(object sender, EventArgs e)
        {
            if (Users.isAdmin(Page.User.Identity.Name))
                Response.Redirect("adminsessionlist.aspx");

            if (!this.Page.User.Identity.IsAuthenticated)
                FormsAuthentication.RedirectToLoginPage();

            if (!IsPostBack)    // Reloading the repeaters on every postback is inefficient.
                rptSessionsBind();

        }

        public void OnSessionRepeater_DataBind(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hidSessId = e.Item.FindControl("hidSessId") as HiddenField;
                HiddenField hidLocId = e.Item.FindControl("hidLocId") as HiddenField;

                int sessId = Convert.ToInt32(hidSessId.Value);
                int locId = Convert.ToInt32(hidLocId.Value);

                Label IsOpen = (Label)e.Item.FindControl("lblIsOpen");
                Label NumSeatsOpen = (Label)e.Item.FindControl("lblNumSeatsOpen");
                Label Capacity = (Label)e.Item.FindControl("lblCapacity");
                Literal inst = (Literal)e.Item.FindControl("litInst");
                Literal email = (Literal)e.Item.FindControl("litLoc");

                var fetchSession = CHR.Master.ReturnSession(sessId);
                var fetchInstrutor = CHR.Master.ReturnInstructor(fetchSession.InstId);
                var fetchLocation = CHR.Master.ReturnLocation(locId);

                IsOpen.Text = CHR.Master.GetNumSeatsOpen(sessId, locId) > 0
                                ? "open"
                                : "closed";

                NumSeatsOpen.Text = CHR.Master.GetNumSeatsOpen(sessId, locId).ToString();
                Capacity.Text = fetchLocation.Capacity.ToString();

                inst.Text = (fetchInstrutor.FirstName + " " + fetchInstrutor.LastName);
                email.Text = fetchInstrutor.Email + "@edinboro.edu";
            }

        }
        
        public bool IsOpen(string sessId, string locId)
        {

            int sessID = Convert.ToInt32(sessId);
            int locID = Convert.ToInt32(locId);

            return (CHR.Master.GetNumSeatsOpen(sessID, locID) != 0);
        }

        public void btnReserve_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            HiddenField hidSessId = item.FindControl("hidSessId") as HiddenField;
            HiddenField hidLocId = item.FindControl("hidLocId") as HiddenField;
            HiddenField hidWeek = item.FindControl("hidWeek") as HiddenField;
            HiddenField hidName = item.FindControl("hidName") as HiddenField;
            Literal litMsg = item.FindControl("litMsg") as Literal;

            var sessId = Convert.ToInt32(hidSessId.Value);
            var locId = Convert.ToInt32(hidLocId.Value);
            var week = Convert.ToInt32(hidWeek.Value);
            var stu = CHR.Master.ReturnStudent(Convert.ToInt32(Page.User.Identity.Name));

            if (stu.CheckWeek(week))
                litMsg.Text = ERROR_WEEKPREOCCUPIED;

            else if (CHR.Master.GetNumSeatsOpen(sessId, locId) == 0)
                litMsg.Text = ERROR_SESSIONFULL;

            else
            {
                CHR.Master.AddRegistrationRecord(stu.Id, sessId, locId);
                rptSessionsBind(week);
                //litMsg.Text = CONFIRM_REG_SUCCESS + hidName.ToString();
            }

            
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

    }
}