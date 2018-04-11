<%@ Page MasterPageFile="masterPage.master" CodeBehind="studentDetails.aspx.cs" Inherits="CHR.studentDetails" Language="C#" AutoEventWireup="True" EnableEventValidation="true" %>

<asp:Content ContentPlaceHolderId="CPH1" runat="server">
	<div class="page-header">
    	<h1> Student Information</h1>
   	</div>
   	<div class="row">
    	<div class="col-md-6">
          	<table runat="server" class="table">
            	<thead>
              		<tr>
               			<th colspan="2">Biographical Data</th>
              		</tr>
            	</thead>
            	<tbody>
              		<tr>
                		<td>Name:</td>
                		<td> <asp:Literal ID="litStuName" runat="server" /></td>
              		</tr>
              		<tr>
                		<td>Student ID:</td>
                		<td>@<asp:Literal ID="litStuId" runat="server" /></td>
              		</tr>
              		<tr>
              	 		<td>Student Email:</td>
               			<td><asp:Literal ID="litStuEmail" runat="server" />@scots.edinboro.edu</td>
              		</tr>
            	</tbody>
         	</table>
        </div>
        <div class="col-md-6">
        	<p> You have reserved the following sessions:</p>
          	

                    <asp:Repeater ID="rptStudentSess" runat="server">
                          <HeaderTemplate>
                              <table class="table table-striped">
            	                <thead>
              		                <tr>
                		                <th>Week</th>
                		                <th>Session Name</th>
              		                </tr>
            	                </thead>
            	                <tbody>
                          </HeaderTemplate>

                          <ItemTemplate>
                                <asp:HiddenField ID="hidSessId" runat="server" Value='<%# Eval("Id") %>' />
                                <tr runat="server">
                		        <td runat="server" style="vertical-align: middle;"><%# Eval("Week") %></td>
                		        <td runat="server" style="vertical-align: middle;"><%# Eval("Name") %></td>

                		        <td runat="server" style="vertical-align: middle;"><asp:Button ID="btnUnReserve" type="button" runat="server" class="btn btn-danger" Text="Unreserve" OnClick="btnUnReserve_Click"/></td>
              		            </tr>
                          
                          </ItemTemplate>

                          <FooterTemplate>
                              </tbody>
          	                </table>
                          </FooterTemplate>
                      </asp:Repeater>
            	
          	<div class="center">
          		<asp:Button name="ubtnUnReserveAll" type="button" runat="server" class="btn btn-danger" Text="Unreserve All Sessions" OnClick="btnUnReserveAll_Click" />
          	</div>
        </div>
	</div>
</asp:Content>
