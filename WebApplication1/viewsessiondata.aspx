<%@ Page MasterPageFile="masterPage.master" %>

<asp:Content ContentPlaceholderId="CPH1" runat="server">
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"
	integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS"
	crossorigin="anonymous"></script>
	<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>

	<form runat="server">

	  <div class="page-header">
	    <h1>View Session Details</h1>

			<asp:Button runat="server" name="editSession" type="button" class="btn btn-danger" Text="Edit This Session" />
	  </div>
	  <div class="row">
	    <div class="col-md-4">
					<table runat="server" class="table">
	  				<thead>
	    					<tr>
	     						<th colspan="3" runat="server" id="sessionName">Session Name</th>
	    					</tr>
	  				</thead>
	  				<tbody>
	    					<tr>
	      					<td>Instructor Name:</td>
	      					<td runat="server" id="instructorName">John Smith</td>
	    					</tr>
	    					<tr>
	      					<td>Instructor Email:</td>
	      					<td runat="server" id="instructorEmail">jsmith@example.com</td>
	    					</tr>
	  				</tbody>
					 </table>
			</div>
			<div class="col-md-4">
	      <table runat="server" class="table">
	          <thead>
	              <tr>
	                <th colspan="3" runat="server" id="sessionName2">Session Date</th>
	              </tr>
	          </thead>
	            <tbody>
	                <tr>
	                  <td>Number Registered:</td>
	                  <td runat="server" id="sessionRegistered">23</td>
	                </tr>
	                <tr>
	                  <td>Total Capacity:</td>
	                  <td runat="server" id="sessionCapacity">30</td>
	                </tr>
	            </tbody>
	         </table>
			</div>

	    <div class="col-md-4">
	      <table runat="server" class="table">
	          <thead>
	              <tr>
	                <th colspan="3" id="sessionName3">&nbsp;</th>
	              </tr>
	          </thead>
	            <tbody>
	                <tr>
	                  <td>Session Description:</td>
	                  <td runat="server" id="sessionRegistered2">Lorem Ipsum blah blah blah....</td>
	                </tr>
	            </tbody>
	         </table>
	    </div>
	  </div>
	  <div class="row">
	    <div class="col-md-12">
	      <table runat="server" class="table table-striped">
	          <thead>
	              <tr>
	                <th>List of Registered Students</th>
	              </tr>
	          </thead>
	            <tbody>
	                <tr>
	                  <td runat="server" id="registeredStudent1">Student Name, email@example.com, @00000001 <asp:Button runat="server" name="removeStudent1" type="button" class="btn btn-danger" Text="Remove This Student" /></td>
	                </tr>
									<tr>
	                  <td runat="server" id="registeredStudent2">Student Name, email@example.com, @00000001 <asp:Button runat="server" name="removeStudent2" type="button" class="btn btn-danger" Text="Remove This Student" /></td>
	                </tr>
									<tr>
	                  <td runat="server" id="registeredStudent3">Student Name, email@example.com, @00000001 <asp:Button runat="server" name="removeStudent3" type="button" class="btn btn-danger" Text="Remove This Student" /></td>
	                </tr>
	            </tbody>
	         </table>
	    </div>


	  </div>
	    </form>
</asp:Content>
