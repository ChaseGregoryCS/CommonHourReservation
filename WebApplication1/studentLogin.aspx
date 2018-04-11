<%@ Page MasterPageFile="masterPage.master" CodeBehind="studentLogin.aspx.cs" Inherits="CHR.studentLogin" Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="CHR" %>

<asp:Content ContentPlaceHolderId="CPH1" runat="server">
	<div class="page-header">
    	<h1>Student Login Page</h1>
   	</div>
   	<p>Please Enter Your Student Credentials</p>

  		<div class="form-group" style="text-align:center">
        <asp:Login ID="StudentLogin" runat="server" OnAuthenticate="AuthenticateStudent">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblStuEmail" runat="server" AssociatedControlID="UserName">Student ID:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server" ToolTip="Your Edinboro Student ID."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="StuIdRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Student ID is required." ToolTip="Student ID is required." ValidationGroup="StudentLogin">*</asp:RequiredFieldValidator>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblStuId" runat="server" AssociatedControlID="Password">Student Email:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" ToolTip="Your Edinboro student email address."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="StuEmailRequired" runat="server" ControlToValidate="Password" ErrorMessage="Email is required." ToolTip="Email is required." ValidationGroup="StudentLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="StudentLogin" class="btn btn-danger" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            </asp:Login>
  		</div>
</asp:Content>