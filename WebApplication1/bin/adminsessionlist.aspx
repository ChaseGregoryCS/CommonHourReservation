<%@ Page MasterPageFile="masterPage.master" CodeBehind="adminsessionlist.aspx.cs" Inherits="CHR.adminsessionlist" Language="C#" AutoEventWireup="True" %>



<asp:Content ContentPlaceHolderId="CPH1" runat="server">

<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"
integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS"
crossorigin="anonymous"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>

<h1>Welcome, Admin!</h1>
	<p> Choose a session below to view/edit. Or create a new session. </p>

	<ul class="nav nav-tabs">
		<li class="nav-item">
			<a runat="server" id="adminTab1" class="nav-link active" data-toggle="tab" href="#active" role="tab">First Tuesday</a>
		</li>
		<li class="nav-item">
			<a runat="server" id="adminTab2" class="nav-link" data-toggle="tab" href="#link" role="tab">Second Tuesday</a>
		</li>
		<li class="nav-item">
			<a runat="server" id="adminTab3" class="nav-link" data-toggle="tab" href="#anotherlink" role="tab">Third Tuesday</a>
		</li>
	</ul>

	<div class="tab-content">

		<div class="tab-pane active" id="active" role="tabpanel">
                    <asp:Repeater ID="rptSessWeek1" runat="server" >
                          <HeaderTemplate>
                          <table  class="table table-striped" style="padding: 5%;">
                          </HeaderTemplate>

                          <ItemTemplate>
                              <tr>
                                <asp:HiddenField ID="hidSessId" Value='<%# Eval("Id") %>' runat="server" />

                                <td runat="server" id="sessionName1"><%# Eval("Name") %></td>
					            <td><a href="#"><asp:Button runat="server" name="viewDeets" type="button" class="btn btn-danger" Text="View Details" OnClick="btnEditSession_Click" /></td>
                               </tr>
                          </ItemTemplate>
                            
                          <FooterTemplate>
                             </table>  
                          </FooterTemplate>
                      </asp:Repeater>
        </div>

		<div class="tab-pane" id="link" role="tabpanel">
                <asp:Repeater ID="rptSessWeek2" runat="server" >
                          <HeaderTemplate>
                          <table  class="table table-striped" style="padding: 5%;">
                          </HeaderTemplate>

                          <ItemTemplate>
                              <tr>
                                <asp:HiddenField ID="hidSessId" Value='<%# Eval("Id") %>' runat="server" />

                                <td runat="server" id="sessionName1"><%# Eval("Name") %></td>
					            <td><a href="#"><asp:Button runat="server" name="viewDeets" type="button" class="btn btn-danger" Text="View Details" OnClick="btnEditSession_Click"  /></td>
                               </tr>
                          </ItemTemplate>
                            
                          <FooterTemplate>
                             </table>  
                          </FooterTemplate>
                      </asp:Repeater>



		</div>

		<div class="tab-pane" id="anotherlink" role="tabpanel">
            <asp:Repeater ID="rptSessWeek3" runat="server" >
                          <HeaderTemplate>
                          <table  class="table table-striped" style="padding: 5%;">
                          </HeaderTemplate>

                          <ItemTemplate>
                              <tr>
                                <asp:HiddenField ID="hidSessId" Value='<%# Eval("Id") %>' runat="server" />

                                <td runat="server" id="sessionName1"><%# Eval("Name") %></td>
					            <td><a href="#"><asp:Button runat="server" name="viewDeets" type="button" class="btn btn-danger" Text="View Details" OnClick="btnEditSession_Click"  /></td>
                               </tr>
                          </ItemTemplate>
                            
                          <FooterTemplate>
                             </table>  
                          </FooterTemplate>
                      </asp:Repeater>



		</div>
			<a href="#"><asp:Button runat="server" type="button" name="addASession" class="btn btn-danger" Text="Add New Session" /></a>
	</div>

</asp:Content>
