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
    public partial class adminAddSession : Page
    {
        private const string ERROR_ONUPDATE = "Error: Could not add session. Does another session with this name exist?";
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

                hidInstId.Value = ddlInstructors.SelectedValue;
                hidLocId.Value = ddlLocations.SelectedValue;
            }

        }

        public void ddlInstructors_IndexChanged(object sender, EventArgs e)
        {
            hidInstId.Value = ddlInstructors.SelectedValue;
        }

        public void ddlLocations_IndexChanged(object sender, EventArgs e)
        {
            hidLocId.Value = ddlLocations.SelectedValue;
        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var newSess = new CHR.Session(txtSessionName.Text, txtDesc.Text, 0, Convert.ToInt32(hidLocId.Value), Convert.ToInt32(hidInstId.Value), Convert.ToInt32(ddlWeek.SelectedValue));

                if (CHR.Master.AddRecord(newSess))
                    Response.Redirect("adminsessionlist.aspx");
                else
                    litError.Text = ERROR_ONUPDATE;
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                litError.Text = ERROR_ONUPDATE;
            }
        }

    }
}