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
    public class Location
    {

        /**
         * Narrative: Parameterized constructor for Location. 
         * Pre: A site with instructor data is in Lifecycle
         * Post: Instantiated Instructor .
         **/
        public Location(string iName, int iID, int iCap)
        {
            Name = iName;
            Id = iID;
            Capacity = iCap;
        }

        /**
         * Narrative: Observer for _name 
         * Pre: N/A
         * Post: _name returned
         **/
        public string Name {get;set;}

        /**
         * Narrative: Observer for _id
         * Pre: N/A
         * Post: _id returned
         **/
        public int Id {get;set;}

        /**
         * Narrative: Observer for _cap
         * Pre: N/A
         * Post: _cap returned
         **/
        public int Capacity {get;set;}
    }
}

