<!--Registration Page-->

<%@ Page MasterPageFile="masterPage.master" %>

<asp:Content ContentPlaceHolderId="CPH1" runat="server">

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js" 
    integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS" 
    crossorigin="anonymous">
</script>

<asp:Content ContentPlaceHolderId="CPH1" runat="server">
    <div class="page-header">
        <h1> Register for Freshman Common Hour</h1>
    </div>
        <p>
            <form runat="server" class="form-inline" role="form" method="post">
                <div class="form-group">
                    <label for="RegisterFN">First Name:</label>
                    <asp:TextBox runat="server" type="RegisterFN" class="form-control" id="RegisterFN" />
                </div> 
                    &nbsp; &nbsp;
                <div class="form-group">
                    <label for="RegisterLN">Last Name:</label>
                    <asp:TextBox runat="server" type="RegisterLN" class="form-control" id="RegisterLN" />
                </div>
            </form>
            <br>

            <form runat="server" role="form" method="post">
                <div class="form-group">
                    <label for="RegisterStudentID">Student ID:</label>
                    <!--Tooltip-->
                    <div class="input-group add on">
                        <input runat="server" type="RegisterStudentID" class="form-control" id="RegisterStudentID" placeholder='@00000000' aria-describedby="basic-addon2">
                        <span class="input-group-addon" id="basic-addon2" data-toggle="popover" title="Student ID" data-placement="top"
                        data-content="Also known as your banner ID number. This is a 8 digit number beginning with an '@' sign. It can be found on your student ID card." data-trigger="click">
                        <i class="fa fa-question-circle"></i><i class="glyphicon glyphicon-question-sign"></i></span>
                    </div>
                    <script>
                        $(document).ready(function(){
                            $('[data-toggle="popover"]').popover();   
                                    container: '.form-group'
                        });
                    </script>
                </div>
                <div class="form-group">
                    <label for="RegisterReID">Re-enter Student ID:</label>
                    <asp:TextBox runat="server" type="RegisterReID" class="form-control" id="RegisterReID" placeholder='@00123456'/>
                </div>
                <div class="form-group">
                    <label for="RegisterStudentEmail">Student Email:</label>
                    <!--Tooltip-->
                    <div class="input-group add on">
                        <input runat="server" type="RegisterStudentEmail" class="form-control" id="RegisterStudentEmail" placeholder='ab123456@scots.edinboro.edu' aria-describedby="basic-addon2">
                        <span class="input-group-addon" id="basic-addon2" data-toggle="popover" title="Student Email" data-placement="top"
                        data-content="This is your student email address. The 'ab123456' should be the same username you use to sign on to scots. This is followed by @scots.edinboro.edu." data-trigger="click">
                        <i class="fa fa-question-circle"></i><i class="glyphicon glyphicon-question-sign"></i></span>
                    </div>
                    <script>
                        $(document).ready(function(){
                            $('[data-toggle="popover"]').popover();   
                                container: '.form-group'
                        });
                    </script>
                </div>
                <div class="form-group">
                    <label for="RegisterReEmail">Re-enter Student Email:</label>
                    <asp:TextBox runat="server" type="RegisterReEmail" class="form-control" id="RegisterReEmail" placeholder='ab123456@scots.edinboro.edu'/>
                </div>

                <!--The OnClick should go back to the previous page the user visted-->
                <asp:Button runat="server" type="button" class="btn btn-default" onClick="history.go(-1);return true;" text="Back"/>
                &nbsp;
                <asp:Button runat="server" type="submit" class="btn btn-default" text="Complete"/>
                <br><br>
                    
            </form>
        </p>

</asp:Content>