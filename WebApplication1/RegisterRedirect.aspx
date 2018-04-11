<!--Registration Redirect Page-->

<%@ Page MasterPageFile="masterPage.master" %>
            
<asp:Content ContentPlaceHolderId="CPH1" runat="server">
    <div class="page-header">
        <h1>Registration Successful</h1>
    </div>
        <p>
            You have successfully registered for Freshman Common Hour.<br><br>
            A confirmation email will be sent out to your student email.<br>
             Please verify your email before reserving a session.

            <br><br>
            <!--Need link to session homepage-->
            <form runat="server" class="form-inline" role="form" method="post">
                <a href="#"><asp:Button runat="server" type="button" class="btn btn-default" text="View Sessions"/></a>
            </form>
        </p>

</asp:Content>