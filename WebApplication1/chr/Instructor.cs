/**
 * Location Class CHR
 * @author: Chase Gregory
 * @version: 1.0
 **/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHR
{
    public class Instructor
    {
        
        /**
         * Narrative: Parameterized constructor for Instructor. 
         * Pre: A site with instructor data is in Lifecycle
         * Post: Instantiated Instructor.
        **/
        public Instructor(int id, string firstName, string lastName, string email)
        {
            Id = id;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
        }

        /**
         * Narrative: Getter/setter for FirstName
         * Pre: N/A
         * Post: instructor's first name set/returned
        **/
        public string FirstName
        {get;set;}
		
		/**
         * Narrative: Getter/Setter for LastName
         * Pre: N/A
         * Post: instructor's last name set/returned
        **/
        public string LastName
        {get;set;}

        /**
         * Narrative: Getter/Setter for ID
         * Pre: N/A
         * Post: instructor's ID set/returned
        **/
        public int Id
        {get;private set;}

        /**
         * Narrative: Getter/Setter for Email
         * Pre: N/A
         * Post: instructor's email set/returned
        **/
        public string Email
        {get;set;}
    }
    
}

