/*Student and Session class implementations
  Jeremy Core */

using System;
using System.Collections.Generic;
using System.Data;

namespace CHR
{
   public class Student
   {
      public DataTable regSessions
        { get; set; }

      public Student(DataTable SessionList, int id, string firstName, string lastName, string email)
      //Narrative: Parameterized constructor for student object
      //Pre: Data entered in form
      //Post: Student object created
      {
            if (SessionList != null)
                regSessions = SessionList;
	
	 Id = id;
	 FirstName = firstName;
	 LastName = lastName;
	 Email = email;
      }
      
      public string FirstName
      //Narrative: Observer for first name field
      //Pre: N/A
      //Post: first name value returned
      {get;set;}

      public string LastName
      //Narrative: Observer for last name field
      //Pre: N/A
      //Post: last name value returned
      {get;set;}
     
      public string Email
      //Narrative: Observer for email field
      //Pre: N/A
      //Post: email value returned
      {get;set;}

      public int Id
      //Narrative: Observer for ID field
      //Pre: N/A
      //Post: ID value returned
      { get; private set; }

      public bool CheckWeek(int week)
      //Narrative: Checks to see if student is registered for the week
      //Pre: N/A
      //Post: Returns true if student has scheduled for the week, false otherwise
      {
         if (regSessions == null)
                return false;
         foreach(DataRow row in regSessions.Rows)
            if(row["Week"].ToString() == week.ToString())
               return true;
         return false;
      }
   }
}
