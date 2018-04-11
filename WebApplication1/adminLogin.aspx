<%@ Page MasterPageFile="masterPage.master"  CodeBehind="adminLogin.aspx.cs" Inherits="CHR.adminLogin" Language="C#" AutoEventWireup="True"%>

<asp:Content ContentPlaceholderId="CPH1" runat="server">

	<div class="page-header">
    	<h1> Administrator Login </h1>
    </div>
    <p> If you have administrator privledges, you may login to the Admin Portal below.</p>  

     <asp:Login ID="AdminLogin" runat="server" OnAuthenticate="AuthenticateAdmin" >
            <LayoutTemplate>
                <table cellpadding="0">
                                <tr>
                                    <td>Administrator Username:</td>
    		                         <td>      
                                         <asp:TextBox runat="server" ID="UserName" type="adminUser" class="form-control" placeholder='Username' />
                                         <asp:RequiredFieldValidator ID="AdminIdRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Username is required." ToolTip="Username is required." ValidationGroup="AdminLogin">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Administrator Password:</td>
                                    <td>
    		                                <asp:TextBox runat="server" type="adminPass" class="form-control" ID="Password" placeholder='Password' TextMode="Password" />
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="AdminLogin">*</asp:RequiredFieldValidator>
                           
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
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="AdminLogin" class="btn btn-danger" />
                                    </td>
                                </tr>
                            </table>
            </LayoutTemplate>
            </asp:Login>
</asp:Content>
