using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


// TODO: Verify code once Instructor is added

namespace CHR
{
    /// <summary>
    /// The master handler for everything relating to CHR. Contains the highest level of abstraction for database communication.
    /// </summary>
    public static class Master
    {
        static private DBObject _database;

        // static Master()
        /// <summary>
        ///  Implicity called whenever a static method is called. Initalizes _database.
        /// </summary>
        static Master()
        {
            _database = new DBObject();
        }

        // bool AddRecord(Instructor newInstructor)
        /// <summary>
        /// Adds an instructor record. Returns false if record insertion was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newInstructor">The instructor object you want to insert.</param>
        public static bool AddRecord(Instructor newInstructor)
        {
            try
            {
                return _database.InsertRecord(newInstructor);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool AddRecord(Student newStudent)
        /// <summary>
        /// Adds an student record. Returns false if record insertion was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newStudent">The student object you want to insert.</param>
        public static bool AddRecord(Student newStudent)
        {
            try
            {
                return _database.InsertRecord(newStudent);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool AddRecord(Location newLoc)
        /// <summary>
        /// Adds an location record. Returns false if record insertion was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newLoc">The location object you want to insert.</param>
        public static bool AddRecord(Location newLoc)
        {
            try
            {
                return _database.InsertRecord(newLoc);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool AddRecord(Session newSess)
        /// <summary>
        /// Adds an session record. Returns false if record insertion was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newSess">The session object you want to insert.</param>
        public static bool AddRecord(Session newSess)
        {
            try
            {
                return _database.InsertRecord(newSess);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool UpdateRecord(Instructor newInstructor)
        /// <summary>
        /// Updates an instructor record. Returns false if record Update was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newInstructor">The instructor object you want to Update.</param>
        public static bool UpdateRecord(Instructor newInstructor)
        {
            try
            {
                return _database.UpdateRecord(newInstructor);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool UpdateRecord(Student newStudent)
        /// <summary>
        /// Updates an student record. Returns false if record Update was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newStudent">The student object you want to Update.</param>
        public static bool UpdateRecord(Student newStudent)
        {
            try
            {
                return _database.UpdateRecord(newStudent);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool UpdateRecord(Location newLoc)
        /// <summary>
        /// Updates an location record. Returns false if record Update was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newLoc">The location object you want to Update.</param>
        public static bool UpdateRecord(Location newLoc)
        {
            try
            {
                return _database.UpdateRecord(newLoc);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool UpdateRecord(Session newSess)
        /// <summary>
        /// Updates an session record. Returns false if record Update was unsuccessful or if _database was not initalized.
        /// </summary>
        /// <param name="newSess">The session object you want to Update.</param>
        public static bool UpdateRecord(Session newSess)
        {
            try
            {
                return _database.UpdateRecord(newSess);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool RemoveRecord(int id, Table table)
        /// <summary>
        /// Removes a record from the indicated table. Returns false if record removal was unsuccessful or if _database was not initialized.
        /// </summary>
        /// <param name ="id"> The record id you want to delete. </param>
        public static bool RemoveRecord(int id, Table table)
        {
            try
            {
                return _database.DeleteRecord(id, table);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // Student ReturnStudent(int id)
        /// <summary>
        /// Fetches a student with the corresponding id as a Student object. Returns null if id does not exist or if _database is not initalized.
        /// </summary>
        /// <param name ="id"> The student id you want to fetch. </param>
        public static Student ReturnStudent(int id)
        {
            try
            {
                var studentData = _database.SelectRecord(id, Table.STUDENT);
                var reservations = _database.GetRegisteredSessions(id);

                var rtnStudent = new Student(reservations, Convert.ToInt32(studentData[Constants.STU_ID_INDEX]), studentData[Constants.STU_FNAME_INDEX], studentData[Constants.STU_LNAME_INDEX], studentData[Constants.STU_EMAIL_INDEX]);

                return rtnStudent;
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return null;
            }
        }
        
        // Session ReturnSession(int id)
        /// <summary>
        /// Fetches a Session with the corresponding id as a Session object. Returns null if id does not exist or if _database is not initalized.
        /// </summary>
        /// <param name ="id"> The Session id you want to fetch. </param>
        public static Session ReturnSession(int id)
        {
            try
            {
                var SessionData = _database.SelectRecord(id, Table.SESSION);

                var rtnSession = new Session(SessionData[1], SessionData[2], Convert.ToInt32(SessionData[0]), Convert.ToInt32(SessionData[3]), Convert.ToInt32(SessionData[4]), Convert.ToInt32(SessionData[5]));
                return rtnSession;
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return null;
            }
        }

        // Location ReturnLocation(int id)
        /// <summary>
        /// Fetches a Location with the corresponding id as a Location object. Returns null if id does not exist or if _database is not initalized.
        /// </summary>
        /// <param name ="id"> The Location id you want to fetch. </param>
        public static Location ReturnLocation(int id)
        {
            try
            {
                var LocationData = _database.SelectRecord(id, Table.LOCATION);
                var rtnLocation = new Location(LocationData[Constants.LOC_NAME_INDEX], Convert.ToInt32(LocationData[Constants.LOC_ID_INDEX]),Convert.ToInt32(LocationData[Constants.LOC_CAP_INDEX]));

                return rtnLocation;
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return null;
            }
        }

        // Instructor ReturnInstructor(int id)
        /// <summary>
        /// Fetches an Instructor with the corresponding id as an Instructor object. Returns null if id does not exist or if _database is not initalized.
        /// </summary>
        /// <param name ="id"> The Instructor id you want to fetch. </param>
        public static Instructor ReturnInstructor(int id)
        {
            try
            {
                var instructorData = _database.SelectRecord(id, Table.INSTRUCTOR);
                var rtnLocation = new Instructor(Convert.ToInt32(instructorData[Constants.INST_ID_INDEX]), instructorData[Constants.INST_FNAME_INDEX], instructorData[Constants.INST_LNAME_INDEX], instructorData[Constants.INST_EMAIL_INDEX]);

                return rtnLocation;
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return null;
            }
        }

        // DataTable FetchRecordList(Table table)
        /// <summary>
        /// Returns a DataTable populated with all records from the specified table. Returns null if retrieval fails.
        /// </summary>
        /// <param name ="table"> The table you want to return. Valid candidate are: STUDENT, LOCATION, SESSION, INSTRUCTOR, REG_QUEUE</param>
        /// <param name="week">If you are fetching a list of sessions, this is the week you want to look at. This parameter is optional.</param>
        public static DataTable FetchRecordList(Table table,int week = 0)
        {
            try
            {
                return _database.FetchAll(table,week);
            }
            catch(Exception err)
            {
                ErrorLogger.AddError(err);
                return null;
            }
        }

        // bool RegisterStudent(string hashkey)
        /// <summary>
        /// Transfers a student record from REG_QUEUE to STUDENT if the provided hashkey exists in REG_QUEUE. Returns true if registration is successful.
        /// </summary>
        /// <param name ="hashKey">The hashed email you want to register.</param>
        public static bool RegisterStudent(string hashKey)
        {
            return _database.RegisterStudent(hashKey);
        }

        // bool AddRegistrationRecord(int stuId,int sessId)
        /// <summary>
        /// Creates a new reservation for a session. If sessId is full or an unexpected error occurs, no reservation is placed and the function returns false.
        /// </summary>
        /// <param name ="stuId">The Student Id that is reserving a position</param>
        /// <param name="sessId">The session Id that you want to reserve a position for</param>
        public static bool AddRegistrationRecord(int stuId,int sessId,int locId)
        {
            try
            {
                return _database.AddRegistration(stuId, sessId, locId);
            }
            catch(Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool RemoveRegistrationRecord(int stuId,int sessId)
        /// <summary>
        /// Removes a reservation. If the reservation does not exist or another error occurs, nothing changes and the function returns false.
        /// </summary>
        /// <param name ="stuId">The Student Id that is trying to cancel a registration</param>
        /// <param name="sessId">The session Id that the student has signed up for</param>
        public static bool RemoveRegistrationRecord(int stuId, int sessId)
        {
            try
            {
                return _database.DeleteRegistration(stuId, sessId);
            }
            catch(Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // bool CheckExistingName(string name, Table table)
        /// <summary>
        /// Checks to see if the given name already exists in a record in the specified table.
        /// </summary>
        /// <param name="name">
        /// The name you want to check for existance.
        /// </param>
        /// <param name="table">
        /// The table you want to check for existance in.
        /// </param>
        public static bool CheckExistingName(string name,Table table)
        {
            try
            {
                return false;//_database.CheckPreExistingName(name, table);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return false;
            }
        }

        // int GetNumSeatsOpen(int sessId,int locId)
        /// <summary>
        /// Returns the number of seats still open in the provided session.
        /// </summary>
        /// <param name="session">
        /// The session you want to query.
        /// </param>
        public static int GetNumSeatsOpen(int sessId,int locId)
        {
            try
            {
                var chkSessionSeats = new Session(sessId, locId);
                return _database.CheckNumOpenSeats(chkSessionSeats);
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                return 0;
            }
        }



    }
}
