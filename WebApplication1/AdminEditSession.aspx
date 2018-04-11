<%@ Page MasterPageFile="masterPage.master" CodeBehind="AdminEditSession.aspx.cs" Inherits="CHR.AdminEditSession" Language="C#" AutoEventWireup="True" %> 
            
<asp:Content ContentPlaceHolderId="CPH1" runat="server">

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" 
    integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" 
    crossorigin="anonymous">
</script>

    <div class="page-header">
        <h1> Edit Session</h1>
    </div>
    <p>
        <asp:HiddenField ID="hidSessId" runat="server" />
        <asp:HiddenField ID="hidLocId" runat="server" />
        <asp:HiddenField ID="hidInstId" runat="server" />

        <p style="color: red; font-size:large;"><asp:Literal ID="litError" runat="server" /></p>

            <div class="form-group">
                <label for="SessionName">Session Name:</label>
                <asp:TextBox runat="server" type="SessionName" class="form-control" ID="txtSessionName" />
            </div> 
            &nbsp; &nbsp;
            <div class="form-group">
                <label for="sessionDate">Week:</label>
                <asp:TextBox runat="server" type="SessionName" class="form-control" ID="txtWeek" />
                <asp:RegularExpressionValidator ID="weekValidator" ControlToValidate="txtWeek" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+" />
            </div>
            <br><br>
            <div class="form-group">
                <label for="SessionDesc">Session Description:</label> <br/>
                <asp:TextBox runat="server" type="SessionName" class="form-control" ID="txtDesc" MaxLength="100" />
            </div> 
        <br>
            <div class="form-group">
                <label for="Capacity">Total Capacity:</label>
                <asp:Textbox runat="server" type="Capacity" class="form-control" ID="txtCapacity" BackColor="DarkGray"/>
            </div>
            <div class="form-group">
                <label for="InstName">Instructor:</label>
                <asp:DropDownList ID="ddlInstructors" runat="server" OnSelectedIndexChanged="ddlInstructors_IndexChanged" AutoPostBack="true"/>
            </div>
            <div class="form-group">
                <label for="Location">Location:</label>
                <asp:DropDownList ID="ddlLocations" runat="server" OnSelectedIndexChanged="ddlLocations_IndexChanged" AutoPostBack="true" />
            </div>

            <asp:Button runat="server" type="submit" class="btn btn-default" text="Save Changes" OnClick="btnSave_Click"/>
        <br> 
    </p>

 </asp:Content>