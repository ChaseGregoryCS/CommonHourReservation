/*Student and Session class implementations
  Jeremy Core */
using System;
using System.Data;

namespace CHR
{
   public class Session
   {
      public Session(string pName, string pDescription, int pID, int locId,int instId, int week)
      //Narrative: Parameterized constructor for session class
      //Pre: Information entered into form
      //Post: Session object created
      {
         Name = pName;
         Description = pDescription;
         Id = pID;
         LocId = locId;
		 InstId = instId;
		 Week = week;
      }

     public Session(int sessId, int locId)
        {
            Id = sessId;
            LocId = locId;
        }
      public string Name {get;set;}
      //Narrative: Observer for name variable
      //Pre: N/A
      //Post: name value retrieved

      public string Description {get;set;}
      //Narrative: Observer for description variable
      //Pre: N/A
      //Post: description value retrieved

      public int Id{get;set;}
      //Narrative: Observer for ID variable
      //Pre: N/A
      //Post: ID value returned

      public int LocId{get;set;}
      //Narrative: Observer for Location variable
      //Pre: N/A
      //Post: Location value returned
 
      public int InstId{get;set;}
      //Narrative: Observer for Instructor variable
      //Pre: N/A
      //Post: Instructor value returned
      
      public int Week{get;set;}
      //Narrative: Observer for Week variable
      //Pre: N/A
      //Post: Week value returned
   }  
 }