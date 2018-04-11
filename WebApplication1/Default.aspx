<%@ Page MasterPageFile="masterPage.master" CodeBehind="Default.aspx.cs" Inherits="CHR.studenthomepage" Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="CHR" %>

<asp:Content ContentPlaceholderId="CPH1" runat="server">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"
	integrity="sha384-0mSbJDEHialfmuBBQP6A4Qrprq5OVfW37PRR3j5ELqxss1yVqOtnepnHVP9aJ7xS"
	crossorigin="anonymous"></script>
	<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>

            
			<ul class="nav nav-tabs">
				<li class="nav-item">
					<a runat="server" id="tab1" class="nav-link active" data-toggle="tab" href="#firstTues" role="tab">First Tuesday</a>
				</li>
				<li class="nav-item">
					<a runat="server" id="tab2" class="nav-link" data-toggle="tab" href="#secondTues" role="tab">Second Tuesday</a>
				</li>
				<li class="nav-item">
					<a runat="server" id="tab3" class="nav-link" data-toggle="tab" href="#thirdTues" role="tab">Third Tuesday</a>
				</li>
			</ul>

             <asp:ScriptManager ID="WeekPanelScriptManager" runat="server"></asp:ScriptManager>
			<div class="tab-content">

				
                <div class="tab-pane active" id="firstTues" role="tabpanel">
                <asp:UpdatePanel ID="updateWeek1" runat="server"> 
                    <ContentTemplate>
				        <div id="accordionWeek1" role="tablist" aria-multiselectable="true">
                                <asp:Repeater ID="rptSessWeek1" runat="server" OnItemDataBound="OnSessionRepeater_DataBind">
                                  <HeaderTemplate>
                              
                                  </HeaderTemplate>

                                  <ItemTemplate>
                                      <div style="color: red;font-size: large" ><asp:Literal ID="litError" runat="server"/></div>
                                  <div class="panel panel-default">
                                                    <asp:HiddenField ID="hidSessId" Value='<%# Eval("Id") %>' runat="server" />
                                                    <asp:HiddenField ID="hidLocId" Value='<%# Eval("l_ID") %>' runat="server"  />
                                                    <asp:HiddenField ID="hidWeek" Value='<%# Eval("Week") %>' runat="server" />


							                        <div class="panel-heading" role="tab" id='<%# Eval("Id") %>_Heading'>
								                        <h4 class="panel-title">
									                        <a data-toggle="collapse" data-parent="#accordionWeek1" href='#<%# Eval("Id") %>' aria-expanded="true" aria-controls='<%# Eval("Id") %>'>
										                        <%# Eval("Name") %>
									                        </a>
								                        </h4>
							                        </div>

							                            <div id='<%# Eval("Id") %>' class="panel-collapse collapse" role="tabpanel" aria-labelledby='<%# Eval("Id") %>_Heading'>
								                        <div runat="server" id="Desc" class="left-box">
								                        <%# Eval("Description") %>

								                        </div>
								                        <div class="right-box">
								                        <h3>Reservation Details</h3>
                                                        <p>Instructor: <asp:Literal ID="litInst" runat="server" /></p>
                                                        <p>Email: <asp:Literal ID="litLoc" runat="server" /></p>
								                       <p><span runat="server" id="thumbUpIcon1" class="glyphicon glyphicon-thumbs-up" aria-hidden="true" style="color: green; font-size: 2em;" visible='<%# IsOpen(Eval("Id").ToString(), Eval("l_ID").ToString()) %>'/>
                                                            <span runat="server" id="thumbDownIcon1" class="glyphicon glyphicon-thumbs-down" aria-hidden="true" style="color: red; font-size: 2em;" visible='<%# !IsOpen(Eval("Id").ToString(), Eval("l_ID").ToString()) %>' /></p>
								                        <p>This session is currently <asp:Label ID="lblIsOpen" runat="server"/>.</p>
								                        <p><span runat="server" id="openSeats1"> <asp:Label ID="lblNumSeatsOpen" runat="server" /> </span>/<span runat="server" id="totalSeats1"> <asp:Label ID="lblCapacity" runat="server"/> </span> Seats are available.</p>

								                        <asp:Button runat="server" ID="btnReserve_Click" type="button" class="btn btn-danger" Text="Reserve This Session" OnClick="btnReserve_Click" />
                                               
								                        </div>
							                        </div>
						                        </div>
                                  </ItemTemplate>

                                  <FooterTemplate>
                               
                                  </FooterTemplate>
                              </asp:Repeater>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>
                

        <div class="tab-pane" id="secondTues" role="tabpanel">
            <asp:UpdatePanel ID="updateWeek2" runat="server">
                <ContentTemplate>
                        
                        <div id="accordionWeek2" role="tablist" aria-multiselectable="true">
		                        <asp:Repeater ID="rptSessWeek2" runat="server" OnItemDataBound="OnSessionRepeater_DataBind">
                                  <HeaderTemplate>
                                        
                                  </HeaderTemplate>

                                  <ItemTemplate>
                                  <div style="color: red;font-size: large" ><asp:Literal ID="litMsg" runat="server" /></div>
                                  <div class="panel panel-default">
                                                    <div style="color: red;font-size: large" ><asp:Literal ID="litError" runat="server" /></div>
                                                    <asp:HiddenField ID="hidSessId" Value='<%# Eval("Id") %>' runat="server" />
                                                    <asp:HiddenField ID="hidLocId" Value='<%# Eval("l_ID") %>' runat="server"  />
                                                    <asp:HiddenField ID="hidWeek" Value='<%# Eval("Week") %>' runat="server" />

							                        <div class="panel-heading" role="tab" id='<%# Eval("Id") %>_Heading'>
								                        <h4 class="panel-title">
									                        <a class="collapsed" data-toggle="collapse" data-parent="#accordionWeek2" href='#<%# Eval("Id") %>' aria-expanded="false" aria-controls='<%# Eval("Id") %>'>
										                        <%# Eval("Name") %>
									                        </a>
								                        </h4>
							                        </div>

							                        <div id='<%# Eval("Id") %>' class="panel-collapse collapse" role="tabpanel" aria-labelledby='<%# Eval("Id") %>_Heading'>
								                        <div runat="server" id="Desc" class="left-box">
								                        <%# Eval("Description") %>
								                        </div>
								                        <div class="right-box">
								                        <h3>Reservation Details</h3>
                                                        <p>Instructor: <asp:Literal ID="litInst" runat="server" /></p>
                                                        <p>Email: <asp:Literal ID="litLoc" runat="server" /></p>
								                        <p><span runat="server" id="thumbUpIcon1" class="glyphicon glyphicon-thumbs-up" aria-hidden="true" style="color: green; font-size: 2em;" visible='<%# IsOpen(Eval("Id").ToString(), Eval("l_ID").ToString()) %>'/>
                                                            <span runat="server" id="thumbDownIcon1" class="glyphicon glyphicon-thumbs-down" aria-hidden="true" style="color: red; font-size: 2em;" visible='<%# !IsOpen(Eval("Id").ToString(), Eval("l_ID").ToString()) %>' /></p>
								                        <p>This session is currently <asp:Label ID="lblIsOpen" runat="server"/>.</p>
								                        <p><span runat="server" id="openSeats1"> <asp:Label ID="lblNumSeatsOpen" runat="server" /> </span>/<span runat="server" id="totalSeats1"> <asp:Label ID="lblCapacity" runat="server"/> </span> Seats are available.</p>

								                        <asp:Button runat="server" ID="btnReserve_Click" type="button" class="btn btn-danger" Text="Reserve This Session" OnClick="btnReserve_Click" />
								                        </div>
							                        </div>
						                        </div>
                                  </ItemTemplate>

                                  <FooterTemplate>
                              
                                  </FooterTemplate>
                              </asp:Repeater>
					        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
				   </div>

			<div class="tab-pane" id="thirdTues" role="tabpanel">
                <asp:UpdatePanel ID="UpdateWeek3" runat="server">
                    <ContentTemplate>
		            <div id="accordionWeek3" role="tablist" aria-multiselectable="true">
                    <asp:Repeater ID="rptSessWeek3" runat="server" OnItemDataBound="OnSessionRepeater_DataBind">
                                  <HeaderTemplate>
                              
                                  </HeaderTemplate>

                                  <ItemTemplate>
                                 <div class="panel panel-default">
                                                    <asp:HiddenField ID="hidSessId" Value='<%# Eval("Id") %>' runat="server" />
                                                    <asp:HiddenField ID="hidLocId" Value='<%# Eval("l_ID") %>' runat="server"  />
                                                    <asp:HiddenField ID="hidWeek" Value='<%# Eval("Week") %>' runat="server" />

							                        <div class="panel-heading" role="tab" id='<%# Eval("Id") %>_Heading'>
								                        <h4 class="panel-title">
									                        <a data-toggle="collapse" data-parent="#accordionWeek3" href='#<%# Eval("Id") %>' aria-expanded="true" aria-controls='<%# Eval("Id") %>'>
										                        <%# Eval("Name") %>
									                        </a>
								                        </h4>
							                        </div>

							                        <div id='<%# Eval("Id") %>' class="panel-collapse collapse" role="tabpanel" aria-labelledby='<%# Eval("Id") %>_Heading'>
								                        <div runat="server" id="Desc" class="left-box">
								                        <%# Eval("Description") %>
								                        </div>
								                        <div class="right-box">
								                        <h3>Reservation Details</h3>
                                                        <p>Instructor: <asp:Literal ID="litInst" runat="server" /></p>
                                                        <p>Email: <asp:Literal ID="litLoc" runat="server" /></p>
								                        <p><span runat="server" id="thumbUpIcon1" class="glyphicon glyphicon-thumbs-up" aria-hidden="true" style="color: green; font-size: 2em;" visible='<%# IsOpen(Eval("Id").ToString(), Eval("l_ID").ToString()) %>'/>
                                                            <span runat="server" id="thumbDownIcon1" class="glyphicon glyphicon-thumbs-down" aria-hidden="true" style="color: red; font-size: 2em;" visible='<%# !IsOpen(Eval("Id").ToString(), Eval("l_ID").ToString()) %>' /></p>
								                        <p>This session is currently <asp:Label ID="lblIsOpen" runat="server"/>.</p>
								                        <p><span runat="server" id="openSeats1"> <asp:Label ID="lblNumSeatsOpen" runat="server" /> </span>/<span runat="server" id="totalSeats1"> <asp:Label ID="lblCapacity" runat="server"/> </span> Seats are available.</p>

								                        <asp:Button runat="server" ID="btnReserve_Click" type="button" class="btn btn-danger" Text="Reserve This Session" OnClick="btnReserve_Click" />
								                        </div>
							                        </div>
						                        </div>
                                  </ItemTemplate>

                                  <FooterTemplate>
                              
                                  </FooterTemplate>
                              </asp:Repeater>
					          </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
				      </div>

				
            
					



			</div>
</asp:Content>
