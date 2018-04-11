<%@ Page MasterPageFile="masterPage.master" CodeBehind="adminAddSession.aspx.cs" Inherits="CHR.adminAddSession" Language="C#" AutoEventWireup="True" %> 
            
<asp:Content ContentPlaceHolderId="CPH1" runat="server">
    <asp:HiddenField ID="hidLocId" runat="server" />
    <asp:HiddenField ID="hidInstId" runat="server" />

	<div class="page-header">
    	<h1> Add a Session </h1>
   	</div>
    <p style="color: red; font-size:large;"><asp:Literal ID="litError" runat="server" /></p>
    	<div class="row">
        	<div class="col-md-6">
          		<div class="form-group">
    				<label for="sessionName">Session Name:</label>
    				<asp:TextBox runat="server" type="sessionName" class="form-control" ID="txtSessionName" placeholder='Session Name'/>
  				</div>
                <div class="form-group">
    				<label for="sessionDate">Session Date:</label>
                    <div id="datepicker">
    					<asp:DropDownList ID="ddlWeek" runat="server" AutoPostBack="true" >
                            <asp:ListItem Text="1" Value="1" />
                            <asp:ListItem Text="2" Value="2" />
                            <asp:ListItem Text="3" Value="3" />
                        </asp:DropDownList>
					</div>
  				</div>
                <div class="form-group">
    				<label for="sessionDesc">Session Description:</label>
    				<asp:TextBox runat="server" type="sessionDesc" class="form-control" rows="4" ID="txtDesc" placeholder='A description of the session...'/>
  				</div>
        	</div>
        	<div class="col-md-6">
        		<div class="form-group">
    				<label for="capacity">Location:</label>
    				 <asp:DropDownList ID="ddlLocations" runat="server" OnSelectedIndexChanged="ddlInstructors_IndexChanged" AutoPostBack="true"/>
  				</div>
                <div class="form-group">
    				<label for="instructorName">Instructor:</label>
    				 <asp:DropDownList ID="ddlInstructors" runat="server" OnSelectedIndexChanged="ddlInstructors_IndexChanged" AutoPostBack="true"/>
  				</div>
                <asp:Button name="addSession"  runat="server" class="btn btn-default" Text="Add Session" OnClick="btnAdd_Click" />
          	</div>
      	</div>
</asp:Content>
