<!--Reservation Redirect Page-->

<%@ Page MasterPageFile="masterPage.master" %>
            
<asp:Content ContentPlaceHolderId="CPH1" runat="server">
    <div class="page-header">
        <h1>Session Successfully Reserved</h1>
    </div>
    <p>
        You have successfully reserved a seat for <!--Need to post session name here-->Freshman Common Hour.<br>
                    
        <!--Need link to student homepage-->
        View all currently reserved sessions <a href="#">here</a>.

        <br><br>
        <h4>Need to reserve more sessions?</h4><br>
        <!--Needs link to session homepage-->
        <form runat="server" class="form-inline" role="form" method="post">
            <a href="#"><asp:Button runat="server" type="button" class="btn btn-default" text="Go Back"/></a>
        </form>

</asp:Content>