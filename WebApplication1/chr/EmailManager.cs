// CHR email management class
// @author: Ryan McAndrew
// @version: 1.4
/*
using System;
using System.Net.Mail;

namespace CHR {

    public class EmailManager {

        // ***************************************************************
        // class data ****************************************************
        // ***************************************************************
        
            private static readonly int NUM_CONTENTS = 3;

            private static readonly string EMAIL_SENDER = "chr_rsvp.noreply@yahoo.com";

            private static readonly string EMAIL_PASS = "chreservation";

            private static readonly string SERVER = "commonhourrsvp.cs.edinboro.edu";

            private static readonly string INST_DOMAIN = "edinboro.edu";

            private static readonly string STU_DOMAIN = "scots.edinboro.edu";

            private static bool regFlag = false;
            
            public enum ContentType { SUBJECT, BODY, FOOTER };

        //  **************************************************************
        //  constructors *************************************************
        //  **************************************************************

            // Narrative: Initializes content, clientSenderAddress, and client.
            // Pre-Conditions: none
            // Post-Conditions: email server and client sender address have been set. Content is initialized.

            ///<summary> Initializes content, clientSenderAddress, and client. </summary>
            ///<param name=""> </param>
            ///<returns> </returns>

                public EmailManager() {

                    content = new string[ NUM_CONTENTS ];

                    clientSenderAddress = new MailAddress( EMAIL_SENDER );

                    client = new SmtpClient(SERVER);

                }

        // ***************************************************************
        // public observer methods ***************************************
        // ***************************************************************

            // Narrative: returns the subject content of the email
            // Pre-Conditions: none 
            // Post-Conditions: null if no subject is set, subject returned otherwise.

            ///<summary> returns the subject content of the email </summary>
            ///<param name=""> </param>
            ///<returns> null if no subject is set, subject returned otherwise. </returns>

                public string Subject() {

                    return content[ (int)ContentType.SUBJECT ];

                }

            // Narrative: returns the body content of the email
            // Pre-Conditions: none
            // Post-Conditions: null if no content is set, body returned otherwise.

            ///<summary> returns the body content of the email </summary>
            ///<param name=""> </param>
            ///<returns> null if no body is set, body returned otherwise. </returns>

                public string Body() {

                    return content[ (int)ContentType.BODY ];

                }

            // Narrative: returns the footer content of the email
            // Pre-Conditions: none
            // Post-Conditions: null if no footer is set, footer returned otherwise.

            ///<summary> returns the footer content of the email </summary>
            ///<param name=""> </param>
            ///<returns> null if no footer is set, footer returned otherwise.</returns>

                public string Footer() {    

                    return content[ (int)ContentType.FOOTER ];

                }

        // ***************************************************************
        // private observer methods **************************************
        // ***************************************************************

            // Narrative: validates str input is a students email
            // Pre-Conditions: str is validated for email user name
            // Post-Conditions: returns true if domain is a valid student email, false otherwise

            ///<summary> validates str input is a students email </summary>
            ///<param name="str"> A string containg the students email -- required </param>
            ///<returns> returns true if domain is a valid student email, false otherwise </returns>

                private bool IsStudentEmail( string str ) {

                    return CheckDomain( str, STU_DOMAIN );

                }

            // Narrative: validates str input is a instructors email
            // Pre-Conditions: str is validated for email user name
            // Post-Conditions: returns true if domain is a valid student email, false otherwise

            ///<summary> validates str input is a instructors email </summary>
            ///<param name="str"> A string containing the instructors email -- required </param>
            ///<returns> returns true if domain is a valid student email, false otherwise </returns>

                private bool IsInstructorEmail( string str ) {

                    return CheckDomain( str, INST_DOMAIN );

                }

            // Narrative: validates str input is a domain type of the passed in domain
            // Pre-Conditions: substring before domain has been validated
            // Post-Conditions: returns true if domain is a valid domain based on domain send in, false otherwise

            ///<summary> validates str input is a domain type of the passed in domain </summary>
            ///<param name="str"> a string containing either a student or instructors email -- required </param>
            ///<param name="domain"> a string containing the domain of either an instructor or a student domain type -- required </param>
            ///<returns> returns true if domain is a valid domain based on domain send in, false otherwise </returns>

                private bool CheckDomain( string str, string domain ) {

                    int i = str.IndexOf( "@" );
                    bool result = false;
                
                    if ( i != -1 ) {

                        if ( str.Substring( i, str.Length ) == domain ) {

                           result = true;

                        }

                    }

                    return result;

                }

        // ***************************************************************
        // public transformer methods ************************************
        // ***************************************************************

            // Narrative: turns on or off the change in registration flag for sending change in reg emails to students 
            // Pre-Conditions: none
            // Post-Conditions: returns current state of the change in registration flag 

            ///<summary> turns on or off the change in registration flag for sending change in reg emails to students </summary>
            ///<param name=""> </param>
            ///<returns> returns current state of the change in registration flag </returns>

                public bool SwitchChangeInReg() {

                    if ( regFlag )

                        regFlag = false;
                
                    else 
                
                        regFlag = true;

                    return regFlag;

                }

            // Narrative: formats and sends an email in plain text form
            // Pre-Conditions: email string has been validated, if sending a change in registration email, 
            //                 it must be turned on with the EnableChngInReg method
            // Post-Conditions: returns true if email has been sent, false if either formating failed or emailing failed

            ///<summary> formats and sends an email in plain text form </summary>
            ///<param name="recipientEmail"> a string containing the recipients full email (including domain) -- required</param>
            ///<param name="recipientID"> either the student or instructor id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if email has been sent, false if either formating failed or emailing failed </returns>

                public bool EmailPlainTxt( string recipientEmail, int recipientID, Session session ) {

                    bool result = false;

                    if ( FormatPTMessage( recipientEmail, recipientID, session ) ) {

                        if ( EmailContents() ) {

                        result = true;

                        }
                 
                    }

                    return result;

                }

            // Narrative: formats and sends an email in HTML form
            // Pre-Conditions: email string has been validated, if sending a change in registration email, 
            //                 it must be turned on with the EnableChngInReg method
            // Post-Conditions: returns true if email has been sent, false if either the formatting or the emailing has failed

            ///<summary> formats and sends an email in HTML form </summary>
            ///<param name="recipientEmail"> a string containing the recipients full email (including domain) -- required</param>
            ///<param name="recipientID"> either the student or instructor id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if email has been sent, false if either the formatting or the emailing has failed </returns>

                public bool EmailHTML( string recipientEmail, int recipientID, Session session ) {
                
                    bool result = false;

                    if ( FormatHTMLMessage( recipientEmail, recipientID, session ) ) {

                        if ( EmailContents() ) {

                            result = true;

                        }

                    }
                
                    return result;
                }

        // ****************************************************************
        // private transformer methods ************************************
        // ****************************************************************

            // Narrative: final stage in the emailing process, sets up the formatted email, sets the recipient and senders email, and sends the message. Catches exceptions and logs to errorlogger class.
            // Pre-Conditions: client sender and recipient addresses have been set
            //                 subject and body has been set from content
            // Post-Conditions: returns true if email sent, false if exception occured

            ///<summary> final stage in the emailing process, sets up the formatted email, sets the recipient and senders email, and sends the message. Catches exceptions and logs to errorlogger class. </summary>
            ///<param name=""> </param>
            ///<returns> returns true if email sent, false if exception occured </returns>

                private bool EmailContents() {

                    bool result = false;

                    try {

                        clientMsg = new MailMessage( clientSenderAddress, clientRecipientAddress );
                    
                        clientMsg.Subject = content[ (int)ContentType.SUBJECT ];

                        clientMsg.Body = content[ (int)ContentType.BODY ] + content[ (int)ContentType.FOOTER ];

                        client.UseDefaultCredentials = true;

                        client.Send(clientMsg);

                        result = true;

                    }

                    catch (Exception err) {

                        ErrorLogger.AddError(err);
                  
                        result = false;

                    }

                    return result;

                }

            // Narrative: Determines the path to formatting plaintext content based on input, all formatting comes through here.
            // Pre-Conditions: none
            // Post-Conditions: returns true if content is formatted, false otherwise

            ///<summary> Determines the path to formatting plaintext content based on input, all formatting comes through here. </summary>
            ///<param name="recipientEmail"> a string containing the recipients full email (including domain) -- required</param>
            ///<param name="recipientID"> either the student or instructor id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if content is formatted, false otherwise</returns>

                private bool FormatPTMessage( string recipientEmail, int recipientID, Session session ) {

                    bool result = false;

                    if ( IsInstructorEmail( recipientEmail ) ) {

                        if ( FormatInstrEmailPT( recipientID, session ) )

                            result = true;

                    }

                    else if ( IsStudentEmail( recipientEmail ) ) {

                        if ( regFlag ) {
                   
                            if ( FormatChangeEmailPT( recipientID, session ) )

                                result = true;
                  
                        }

                        else {

                            if ( FormatStuEmailPT( recipientID, session ) )

                                result = true;

                        }

                    }

                    if ( result )
                    
                        FormatFooterPT();

                    return result;

                }

            // Narrative: Determines the path to formatting html content based on input, all formatting comes through here.
            // Pre-Conditions: none
            // Post-Conditions: returns true if content is formatted, false otherwise

            ///<summary> Determines the path to formatting html content based on input, all formatting comes through here. </summary>
            ///<param name="recipientEmail"> a string containing the recipients full email (including domain) -- required</param>
            ///<param name="recipientID"> either the student or instructor id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if content is formatted, false otherwise</returns>

                private bool FormatHTMLMessage(string recipientEmail, int recipientID, Session session ) {

                    bool result = false;

                    if ( IsInstructorEmail( recipientEmail ) ) {

                        if ( FormatInstrEmailHTML( recipientID, session ) )

                            result = true;

                    }

                    else if ( IsStudentEmail( recipientEmail ) ) {

                        if ( regFlag ) {
                   
                            if ( FormatChangeEmailHTML( recipientID, session ) )

                                result = true;
                  
                        }

                        else {

                            if ( FormatStuEmailHTML( recipientID, session ) )

                                result = true;

                        }

                    }

                    if ( result )

                        FormatFooterHTML();

                    return result;

                }

            // Narrative: Formats the plaintext course registration subject and body. Fills the content variables based on input.
            // Pre-Conditions: session has been validated
            // Post-Conditions: returns true if subject and body have been formatted, false if recipient is invalid or if session is null.

            ///<summary> Formats the plaintext course registration subject and body. Fills the content variables based on input. </summary>
            ///<param name="recipientID"> the student id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required</param>
            ///<returns> returns true if subject and body have been formatted, false if recipient is invalid or if session is null.</returns>

                private bool FormatStuEmailPT( int recipientID, Session session ) {

                    bool result = false;

                    var recipient = Master.ReturnStudent( recipientID.ToString() );

                    if ( recipient != null ) { 
                  
                        if ( session != null ) {
                  
                            content[ (int)ContentType.SUBJECT ] = "Common Hour Session Registration Confirmation";
                    
                            content[ (int)ContentType.BODY ] = "Greetings " + recipient.FirstName + " " + recipient.LastName;
                            content[ (int)ContentType.BODY ] += ",\n\nThis is an automated message to confirm that you have registered for ";
                            content[ (int)ContentType.BODY ] += session.Name;
                            content[ (int)ContentType.BODY ] += " on " + DateTime.Today.ToString("D") + ". ";
                            content[ (int)ContentType.BODY ] += "\nPlease, note that the location for this session will appear only in this message. Your seating will be reserved for "; 
                            content[ (int)ContentType.BODY ] += session.Week + " at " + session.Loc + " with " + session.Inst;
                            content[ (int)ContentType.BODY ] += " once you have navigated to the link below.\n\n";
                            content[ (int)ContentType.BODY ] += "www.commonhourrsvp.cs.edinboro.edu/sample_page.html";
                            content[ (int)ContentType.BODY ] += "\n\n If you have received the message in error, please ignore this message. \n\n";

                            result = true;

                        }

                    }

                    return result;

                }

            // Narrative: Formats the plaintext instructor seating size message subject and body. Fills the content variables based on input.
            // Pre-Conditions:  session has been validated
            // Post-Conditions: returns true if subject and body have been formatted, false if recipient is invalid or if session is null.

            ///<summary> Formats the plaintext instructor seating size message subject and body. Fills the content variables based on input. </summary>
            ///<param name="recipientID"> the instructor id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if subject and body have been formatted, false if recipient is invalid or if session is null. </returns>

                public bool FormatInstrEmailPT( int recipientID, Session session ) {

                    bool result = false;

                    var recipient = Master.ReturnInstructor( recipientID.ToString() );

                    if ( recipient != null ) {

                        if ( session != null ) {

                            content[ (int)ContentType.SUBJECT ] = "Common Hour " + session.Name + " current seating size.";

                            content[ (int)ContentType.BODY ] = "Greetings " + recipient.Name;
                            content[ (int)ContentType.BODY ] += ",\n\nThis is an automated message containing information regarding seating capacity of a Freshman Common Hour session.";
                            content[ (int)ContentType.BODY ] += session.Name + " seating size is currently " + ( Master.ReturnLocation(session.Loc)._cap - Master.GetNumSeatsOpen( session.Id, session.Loc ) ) + " out of " + Master.ReturnLocation(session.Loc)._cap;
                            content[ (int)ContentType.BODY ] += " as of " + DateTime.Today.ToString("D") + ".";

                        result = true;

                        }

                    }

                    return result;

                }

            // Narrative: Formats the plaintext student change in registration message subject and body. Fills the content variables based on input. 
            // Pre-Conditions: none
            // Post-Conditions: returns true if subject and body have been formatted, false if recipient is invalid or if session is null.

            ///<summary> Formats the plaintext student change in registration message subject and body. Fills the content variables based on input. </summary>
            ///<param name="recipientID"> the student id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if subject and body have been formatted, false if recipient is invalid or if session is null. </returns>

                public bool FormatChangeEmailPT( int recipientID, Session session ) {

                    bool result = false;

                    var recipient = Master.ReturnStudent( recipientID.ToString() );

                    if ( recipient != null ) {

                        if ( session != null ) {

                            content[ (int)ContentType.SUBJECT ] = "Common Hour " + session.Name + "change in registration.";
                    
                            content[ (int)ContentType.BODY ] = "Greetings " + recipient.FirstName + recipient.LastName;
                            content[ (int)ContentType.BODY ] += ", \n\nThis is an automated message for your records that you will be unregistered for ";
                            content[ (int)ContentType.BODY ] += session.Name + ".";

                            result = true;

                        }

                    }

                    return result;

                }

            // Narrative: formats the plain text footer content of all email messages.
            // Pre-Conditions:  none
            // Post-Conditions: footer has been set.

            ///<summary> formats the plain text footer content of all email messages. </summary>
            ///<param name=""> </param>
            ///<returns> footer has been set. </returns>

                public void FormatFooterPT(  ) {

                    content[ (int)ContentType.FOOTER ] = "\n\nsender tba | position tba Edinboro University\ndepartment tba | 219 Meadville Street | Edinboro, PA 16444\nphone tba | email tba\n\n";

                }

            // Narrative: Formats the html course registration subject and body. Fills the content variables based on input.
            // Pre-Conditions: session has been validated
            // Post-Conditions: returns true if subject and body have been formatted, false if recipient is invalid or if session is null.

            ///<summary> Formats the html course registration subject and body. Fills the content variables based on input. </summary>
            ///<param name="recipientID"> the student id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required</param>
            ///<returns> returns true if subject and body have been formatted, false if recipient is invalid or if session is null.</returns>

                public bool FormatStuEmailHTML( int recipientID, Session session ) {

                    bool result = false;

                    var recipient = Master.ReturnStudent( recipientID.ToString() );

                    if ( recipient != null ) { 
                  
                        if ( session != null ) {
                  
                            content[ (int)ContentType.SUBJECT ] = "Common Hour Session Registration Confirmation";
                    
                            content[ (int)ContentType.BODY ] = "<p>Greetings " + recipient.FirstName + " " + recipient.LastName;
                            content[ (int)ContentType.BODY ] += ",</p> <p>This is an automated message to confirm that you have registered for ";
                            content[ (int)ContentType.BODY ] += session.Name;
                            content[ (int)ContentType.BODY ] += " on " + DateTime.Today.ToString("D") + ". </p>";
                            content[ (int)ContentType.BODY ] += "<p>Please, note that the location for this session will appear only in this message. Your seating will be reserved for "; 
                            content[ (int)ContentType.BODY ] += session.Week + " at " + session.Loc + " with " + session.Inst;
                            content[ (int)ContentType.BODY ] += " once you have clicked the register button below.<p>";
                            content[ (int)ContentType.BODY ] += "<a style='display: block; margin: auto;' href='www.commonhourrsvp.cs.edinboro.edu/sample_page.html'>Register</a>";
                            content[ (int)ContentType.BODY ] += "<p> If you have received the message in error, please ignore this message. </p>";

                            result = true;

                        }

                    }

                    return result;

                }

            // Narrative: Formats the html instructor seating size message subject and body. Fills the content variables based on input.
            // Pre-Conditions:  session has been validated
            // Post-Conditions: returns true if subject and body have been formatted, false if recipient is invalid or if session is null.

            ///<summary> Formats the html instructor seating size message subject and body. Fills the content variables based on input. </summary>
            ///<param name="recipientID"> the instructor id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if subject and body have been formatted, false if recipient is invalid or if session is null. </returns>

                public bool FormatInstrEmailHTML( int recipientID, Session session ) {

                    bool result = false;

                    var recipient = Master.ReturnInstructor( recipientID.ToString() ) ;

                    if ( recipient != null ) {

                        if ( session != null ) {

                            content[ (int)ContentType.SUBJECT ] = "Common Hour " + session.Name + " current seating size.";

                            content[ (int)ContentType.BODY ] = "<p>Greetings " + recipient.Name;
                            content[ (int)ContentType.BODY ] += ",</p> <p>This is an automated message containing information regarding seating capacity of a Freshman Common Hour session.</p>";
                            content[ (int)ContentType.BODY ] += "<p> " + session.Name + " seating size is currently " + ( Master.ReturnLocation( session.Loc )._cap - Master.GetNumSeatsOpen( session.Id, session.Loc ) ) + " out of " + Master.ReturnLocation(session.Loc)._cap;
                            content[ (int)ContentType.BODY ] += " as of " + DateTime.Today.ToString("D") + ".</p>";

                            result = true;

                        }

                    }

                    return result;

                }

            // Narrative: Formats the html student change in registration message subject and body. Fills the content variables based on input. 
            // Pre-Conditions: none
            // Post-Conditions: returns true if subject and body have been formatted, false if recipient is invalid or if session is null.

            ///<summary> Formats the html student change in registration message subject and body. Fills the content variables based on input. </summary>
            ///<param name="recipientID"> the student id in the database -- required </param>
            ///<param name="session"> the session in consideration for the content of the email -- required </param>
            ///<returns> returns true if subject and body have been formatted, false if recipient is invalid or if session is null. </returns>

                public bool FormatChangeEmailHTML( int recipientID, Session session ) {

                    bool result = false;

                    var recipient = Master.ReturnStudent( recipientID.ToString() );

                    if ( recipient != null ) {

                        if ( session != null ) {

                            content[ (int)ContentType.SUBJECT ] = "Common Hour " + session.Name + "change in registration.";
                    
                            content[ (int)ContentType.BODY ] = "<p>Greetings " + recipient.FirstName + recipient.LastName;
                            content[ (int)ContentType.BODY ] += ", </p> <p>This is an automated message for your records that you will be unregistered for ";
                            content[ (int)ContentType.BODY ] += session.Name + ".</p>";

                            result = true;

                        }

                    }

                    return result;

                }

            // Narrative: formats the html footer content of all email messages.
            // Pre-Conditions:  none
            // Post-Conditions: footer has been set.

            ///<summary> formats the html footer content of all email messages. </summary>
            ///<param name=""> </param>
            ///<returns> footer has been set. </returns>

                public void FormatFooterHTML(  ) {

                    content[ (int)ContentType.FOOTER ] = "<p> sender tba | position tba Edinboro University </p> <img style=\"display: block; float: left\" src=\"\"> <p> department tba | 219 Meadville Street | Edinboro, PA 16444 </p> <p> phone tba | email tba </p>";

                }


        // ***************************************************************
        // instance data *************************************************
        // ***************************************************************

            private string[] content;

            private SmtpClient client;
            
            private MailMessage clientMsg;

            private MailAddress clientSenderAddress;

            private MailAddress clientRecipientAddress;

    }

}*/