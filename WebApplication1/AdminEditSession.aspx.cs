using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using System.Data;

namespace CHR
{
    public partial class AdminEditSession : Page
    {
        private const string ERROR_ONUPDATE = "Error: Could not update session. Does another session with this name exist?";
        public void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated || !Users.isAdmin(Page.User.Identity.Name))
                Response.Redirect("adminLogin.aspx");

            if (!IsPostBack)
            {
                var instructorList = CHR.Master.FetchRecordList(CHR.Table.INSTRUCTOR);
                instructorList.Columns.Add("Name", typeof(string), "FirstName + ' ' + LastName");


                ddlInstructors.DataSource = instructorList;
                ddlInstructors.DataValueField = "Id";
                ddlInstructors.DataTextField = "Name";
                ddlInstructors.DataBind();

                ddlLocations.DataSource = CHR.Master.FetchRecordList(CHR.Table.LOCATION);
                ddlLocations.DataValueField = "Id";
                ddlLocations.DataTextField = "Name";
                ddlLocations.DataBind();

                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("adminsessionlist.aspx");
                }
                else
                {

                    var id = Convert.ToInt32(Request.QueryString["id"]);
                    var sess = CHR.Master.ReturnSession(id);
                    var loc = CHR.Master.ReturnLocation(sess.LocId);

                    if (sess == null)    // Verify that the id passed through was valid.
                        Response.Redirect("adminsessionlist.aspx");
                    else
                    {
                        hidSessId.Value = sess.Id.ToString();
                        hidLocId.Value = sess.LocId.ToString();
                        hidInstId.Value = sess.InstId.ToString();

                        txtSessionName.Text = sess.Name;
                        txtDesc.Text = sess.Description;
                        txtWeek.Text = sess.Week.ToString();
                        txtCapacity.Text = loc.Capacity.ToString();

                        ddlInstructors.SelectedIndex = ddlInstructors.Items.IndexOf(ddlInstructors.Items.FindByValue(sess.InstId.ToString()));
                        ddlLocations.SelectedIndex = ddlLocations.Items.IndexOf(ddlLocations.Items.FindByValue(sess.LocId.ToString()));
                    }
                }
            }

        }

        public void ddlInstructors_IndexChanged(object sender, EventArgs e)
        {
            hidInstId.Value = ddlInstructors.SelectedValue;
        }

        public void ddlLocations_IndexChanged(object sender, EventArgs e)
        {
            hidLocId.Value = ddlLocations.SelectedValue;
            var loc = CHR.Master.ReturnLocation(Convert.ToInt32(ddlLocations.SelectedValue));

            txtCapacity.Text = loc.Capacity.ToString();
        }
        public void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var updateSess = new CHR.Session(txtSessionName.Text, txtDesc.Text, Convert.ToInt32(hidSessId.Value), Convert.ToInt32(hidLocId.Value), Convert.ToInt32(hidInstId.Value), Convert.ToInt32(txtWeek.Text));
                if(CHR.Master.UpdateRecord(updateSess))
                    Response.Redirect("adminsessionlist.aspx");
                else
                    litError.Text = ERROR_ONUPDATE;
            }
            catch(Exception)
            {
                litError.Text = ERROR_ONUPDATE;
            }
        }

    }
}