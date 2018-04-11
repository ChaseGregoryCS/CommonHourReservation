using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace CHR
{
    /// <summary>
    /// The list of tables that exist in the database.
    /// </summary>
    public enum Table { INSTRUCTOR, LOCATION, REG_QUEUE, RESERVATION, SESSION, STUDENT };


    /// <summary>
    /// A class that provides an abstraction layer for database communication.
    /// </summary>
    public class DBObject
    {
        private const int MINSEATSAVAILABLE = 0;

        private MySqlConnection _connection;

        // DBObject()
        /// <summary>
        /// Initalizes _connection to prepare it for queries.
        /// </summary>
        public DBObject()
        {
            try
            {
                _connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MainDBConnectionString"].ToString());
            }
            catch(Exception err)
            {
                ErrorLogger.AddError(err);
            }
            
        }

        public bool checkConnected()
        {
            if (_connection == null)
                return false;
            else
            {
                _connection.Open();
                return (_connection.State == ConnectionState.Open);
            }
        }
        // CheckExists(int id, Table table)
        /// <summary>
        /// Checks if an id number exists in the given table.
        /// </summary>
        /// <param name="id">The id number to check for.</param>
        /// <param name="table">The table to check in.</param>
        /// <returns>
        /// True if the id exists. False if it doesn't or the query fails.
        /// </returns>
        public bool CheckExists(int id,Table table)
        {
            try
            {

                _connection.Open();

                var cmd = new MySqlCommand
                {
                    CommandText = Constants.CHECKEXISTS.Replace("@Table",table.ToString()), // For some dumb reason you can't parameterize the table, so we have to set it here.
                    CommandType = CommandType.Text,
                    Connection = _connection
                };

                cmd.Parameters.AddWithValue(Constants.ID, id);
                cmd.Prepare();

                
                bool exists = false; 
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    exists = reader.HasRows;
                }

                _connection.Close();
                return exists;
            }
            catch(Exception err)
            {
                // If something went wrong, make sure we don't allow further record manipulation.
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool CheckPreExistingName(string name, Table table)
        /// <summary>
        /// Checks if a record in a table already contains the given name.
        /// </summary>
        /// <param name="name">The name you want to check for.</param>
        /// <param name="table">The table you want to check in.</param>
        /// <returns>
        /// True if the name exists. False if it doesn't exist or the query fails.
        /// </returns>
        public bool CheckPreExistingName(string name, int id, Table table)
        {
            try
            {
                var cmd = new MySqlCommand
                {
                    CommandText = Constants.CHECKEXISTINGNAME.Replace("@Table", table.ToString()), // For some dumb reason you can't parameterize the table, so we have to set it here.
                    Connection = _connection
                };

                cmd.Parameters.AddWithValue(Constants.NAME, name);
                cmd.Parameters.AddWithValue(Constants.ID, id);

                _connection.Open();

                bool exists = false;
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    exists = reader.HasRows;
                }

                _connection.Close();
                return exists;
            }
            catch (Exception err)
            {
                // If something went wrong, make sure we don't allow further record manipulation.
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // List<Session> GetRegisteredSessions(int stuId)
        /// <summary>
        /// Gets a list of all sessions a student has registered for.
        /// </summary>
        /// <param name="stuId">The student id you want to check.</param>
        /// <returns>
        /// A list of sessions if stuId was valid and the query succeeds. Null otherwise.
        /// </returns>
        public DataTable GetRegisteredSessions(int stuId)
        {
            try
            {
                var sessions = new List<Session>();

                // First we have to find all sessions that the student has signed up for
                var cmd = new MySqlCommand
                {
                    CommandText = Constants.GETREGISTEREDSESS,
                    Connection = _connection
                };

                cmd.Parameters.AddWithValue(Constants.ID, stuId);

                _connection.Open();

                var regSess = new DataTable();
                using (var reader = new MySqlDataAdapter(cmd))
                {
                    reader.Fill(regSess);
                }
                _connection.Close();

                if (regSess.Rows.Count == 0)
                    return null;

                return regSess;
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return null;
            }
        }

        // List<string> SelectRecord(int id,Table table)
        /// <summary>
        /// Pulls a record from the database.
        /// </summary>
        /// <param name="id">The record id you want to fetch.</param>
        /// <param name="table">The table where the record exists in.</param>
        /// <returns>
        /// Formatted List of strings if query was successful. Returns null otherwise.
        /// </returns>
        public List<string> SelectRecord(int id,Table table)
        {
            try
            {
                var cmd = new MySqlCommand
                {
                    CommandText = Constants.SELECTRECORD.Replace("@Table", table.ToString()),
                    Connection = _connection
                };

                cmd.Parameters.AddWithValue(Constants.ID, id);

                _connection.Open();

                var record = new DataTable();
                using (var reader = new MySqlDataAdapter(cmd))
                {
                    reader.Fill(record);
                   
                }

                _connection.Close();

                if (record.Rows.Count == 0)
                    return null;

                var selectedRecord = new List<string>();
                foreach (DataRow row in record.Rows)
                {
                    for(int i = 0; i < row.Table.Columns.Count; i++)
                    {
                        selectedRecord.Add(row[i].ToString());
                    }
                }
                
                return selectedRecord;
            }
            catch (Exception err)
            {
                // If something went wrong, make sure we don't allow further record manipulation.
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return null;
            }
        }

        // bool DeleteRecord(int id,Table table)
        /// <summary>
        /// Deletes a record with the specified id in the specified table.
        /// </summary>
        /// <param name="id">The record id you want to delete.</param>
        /// <param name="table">The table you want to delete from.</param>
        /// <returns>
        /// True if deletion was successful. False otherwise.
        /// </returns>
        public bool DeleteRecord(int id, Table table)
        {
            try
            {
                var cmd = new MySqlCommand
                {
                    CommandText = Constants.DELETERECORD.Replace("@Table", table.ToString()),
                    Connection = _connection
                };

                cmd.Parameters.AddWithValue(Constants.ID, id);

                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool InsertRecord(List<string> param,Table table)
        /// <summary>
        ///  Returns true if we are able to insert the specified instuctor into the database. Returns false otherwise. This function will always return false if you attempt to insert into REG_QUEUE or if you try inserting non-existant ID
        ///  numbers into RESERVATION.
        /// </summary>
        /// <param name="newInstructor">
        /// The instuctor you want to add.
        /// </param>
        /// <returns></returns>
        public bool InsertRecord(Instructor newInstructor)
        {
            if (newInstructor == null)
                return false;

            if (CheckExists(newInstructor.Id, Table.INSTRUCTOR))
                 return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.INSERTINSTRUCTOR;
                cmd.Parameters.AddWithValue(Constants.FNAME, newInstructor.FirstName);
                cmd.Parameters.AddWithValue(Constants.LNAME, newInstructor.LastName);
                cmd.Parameters.AddWithValue(Constants.EMAIL, newInstructor.Email);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool InsertRecord(Location newLoc)
        /// <summary>
        ///  Returns true if we are able to insert the specified location into the database. Returns false otherwise.
        /// </summary>
        /// <param name="newLoc">
        /// The location you want to add.
        /// </param>
        /// <returns></returns>
        public bool InsertRecord(Location newLoc)
        {
            if (newLoc == null)
                return false;

            if (CheckExists(newLoc.Id, Table.LOCATION) || CheckPreExistingName(newLoc.Name, newLoc.Id, Table.LOCATION))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.INSERTLOCATION;
                cmd.Parameters.AddWithValue(Constants.NAME, newLoc.Name);
                cmd.Parameters.AddWithValue(Constants.CAPACITY, newLoc.Capacity);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool InsertRecord(Student stu,Session sess)
        /// <summary>
        ///  Creates a new reservation record.
        /// </summary>
        /// <param name="stu">
        /// The student that is reserving a position.
        /// </param>
        /// <param name="sess">
        /// The session being reserved.
        /// </param>
        /// <returns></returns>
        public bool InsertRecord(Student stu,Session sess)
        {
            if (stu == null || sess == null)
                return false;

            if (!CheckExists(stu.Id, Table.STUDENT) || !CheckExists(sess.Id, Table.SESSION))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.INSERTINSTRUCTOR;
                cmd.Parameters.AddWithValue(Constants.STUID, stu.Id);
                cmd.Parameters.AddWithValue(Constants.SESSID, sess.Id);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool InsertRecord(Session sess)
        /// <summary>
        ///  Creates a new session record.
        /// </summary>
        /// <param name="sess">
        /// The session being created.
        /// </param>
        /// <returns></returns>
        public bool InsertRecord(Session sess)
        {
            if (sess == null)
                return false;

            if (CheckExists(sess.Id, Table.SESSION) || CheckPreExistingName(sess.Name, sess.Id, Table.SESSION))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.INSERTSESSION;
                cmd.Parameters.AddWithValue(Constants.NAME, sess.Name);
                cmd.Parameters.AddWithValue(Constants.INSTID, sess.InstId);
                cmd.Parameters.AddWithValue(Constants.LOCID, sess.LocId);
                cmd.Parameters.AddWithValue(Constants.DESC, sess.Description);
                cmd.Parameters.AddWithValue(Constants.WEEK, sess.Week);

                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool InsertRecord(Student stu)
        /// <summary>
        ///  Creates a new student record.
        /// </summary>
        /// <param name="stu">
        /// The student being created.
        /// </param>
        /// <returns></returns>
        public bool InsertRecord(Student stu)
        {
            if (stu == null)
                return false;

            if (CheckExists(stu.Id, Table.SESSION))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.INSERTSESSION;
                cmd.Parameters.AddWithValue(Constants.ID, stu.Id);
                cmd.Parameters.AddWithValue(Constants.FNAME, stu.FirstName);
                cmd.Parameters.AddWithValue(Constants.LNAME, stu.LastName);
                cmd.Parameters.AddWithValue(Constants.EMAIL, stu.Email);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool UpdateInsturctor(Instructor updateInstructor)
        /// <summary>
        ///  Returns true if we are able to update a record in the database that has the same id as the object passed in.
        /// </summary>
        /// <param name="updateInstructor">
        /// The instuctor you want to update.
        /// </param>
        /// <returns></returns>
        public bool UpdateRecord(Instructor updateInstructor)
        {
            if (updateInstructor == null)
                return false;

            if (!CheckExists(updateInstructor.Id, Table.INSTRUCTOR))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.UPDATEINSTRUCTOR;
                cmd.Parameters.AddWithValue(Constants.FNAME, updateInstructor.FirstName);
                cmd.Parameters.AddWithValue(Constants.LNAME, updateInstructor.LastName);
                cmd.Parameters.AddWithValue(Constants.EMAIL, updateInstructor.Email);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool UpdateRecord(Location newLoc)
        /// <summary>
        ///  Returns true if we are able to update a record in the database that has the same id as the object passed in.
        /// </summary>
        /// <param name="updateLoc">
        /// The location you want to update.
        /// </param>
        /// <returns></returns>
        public bool UpdateRecord(Location updateLoc)
        {
            if (updateLoc == null)
                return false;

            if (!CheckExists(updateLoc.Id, Table.LOCATION) || CheckPreExistingName(updateLoc.Name, updateLoc.Id, Table.LOCATION))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.UPDATELOCATION;
                cmd.Parameters.AddWithValue(Constants.NAME, updateLoc.Name);
                cmd.Parameters.AddWithValue(Constants.CAPACITY, updateLoc.Capacity);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool UpdateRecord(Session sess)
        /// <summary>
        ///  Returns true if we are able to update a record in the database that has the same id as the object passed in.
        /// </summary>
        /// <param name="sess">
        /// The session being updated.
        /// </param>
        /// <returns></returns>
        public bool UpdateRecord(Session sess)
        {
            if (sess == null)
                return false;

            if (!CheckExists(sess.Id, Table.SESSION) || CheckPreExistingName(sess.Name, sess.Id, Table.SESSION))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.UPDATESESSION;
                cmd.Parameters.AddWithValue(Constants.NAME, sess.Name);
                cmd.Parameters.AddWithValue(Constants.INSTID, sess.InstId);
                cmd.Parameters.AddWithValue(Constants.LOCID, sess.LocId);
                cmd.Parameters.AddWithValue(Constants.DESC, sess.Description);
                cmd.Parameters.AddWithValue(Constants.WEEK, sess.Week);
                cmd.Parameters.AddWithValue(Constants.ID, sess.Id);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool UpdateRecord(Student stu)
        /// <summary>
        ///  Returns true if we are able to update a record in the database that has the same id as the object passed in.
        /// </summary>
        /// <param name="stu">
        /// The student being updated.
        /// </param>
        /// <returns></returns>
        public bool UpdateRecord(Student stu)
        {
            if (stu == null)
                return false;

            if (!CheckExists(stu.Id, Table.STUDENT))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    Connection = _connection
                };

                cmd.CommandText = Constants.UPDATESTUDENT;
                cmd.Parameters.AddWithValue(Constants.ID, stu.Id);
                cmd.Parameters.AddWithValue(Constants.FNAME, stu.FirstName);
                cmd.Parameters.AddWithValue(Constants.LNAME, stu.LastName);
                cmd.Parameters.AddWithValue(Constants.EMAIL, stu.Email);


                _connection.Open();
                using (cmd)
                {
                    cmd.ExecuteNonQuery();
                }

                _connection.Close();
                return true;
            }

            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // int CheckNumOpenSeats(Session session)
        /// <summary>
        /// Get the number of open seats in the given session.
        /// </summary>
        /// <param name="session">The session you are checking</param>
        /// <returns>
        /// The number of open seats in the session. If the session's id is invalid, returns 0.
        /// </returns>
        public int CheckNumOpenSeats(Session session)
        {
            if (!(CheckExists(session.Id, Table.SESSION) && CheckExists(session.LocId, Table.LOCATION)))
                return 0;

            try
            {
                _connection.Open();

                // We need to lock the records we are reading in the event another person tries to register for the same class at the same time.
                var chkNumSeatsTransaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    var cmdNumReservations = new MySqlCommand
                    {
                        CommandText = Constants.GETTOTALRESERVATIONS,
                        Connection = _connection,
                        Transaction = chkNumSeatsTransaction
                    };

                    var cmdGetLocCapacity = new MySqlCommand
                    {
                        CommandText = Constants.GETLOCCAPACITY,
                        Connection = _connection,
                        Transaction = chkNumSeatsTransaction
                    };

                    cmdNumReservations.Parameters.AddWithValue(Constants.SESSID, session.Id);
                    cmdGetLocCapacity.Parameters.AddWithValue(Constants.LOCID, session.LocId);

                    int numReservations = 0;
                    int capacity = 0;

                    using (var capacityReader = cmdGetLocCapacity.ExecuteReader())
                    {
                        capacityReader.Read();
                        if(capacityReader.HasRows)
                            capacity = Convert.ToInt32(capacityReader[0].ToString());
                    }

                    using (var rsvpReader = cmdNumReservations.ExecuteReader())
                    {
                        rsvpReader.Read();
                        if (rsvpReader.HasRows)
                            numReservations = Convert.ToInt32(rsvpReader[0].ToString());
                    }

                    chkNumSeatsTransaction.Commit();
                    _connection.Close();

                    return (capacity - numReservations);
                }
                catch (Exception err)
                {
                    try
                    {
                        chkNumSeatsTransaction.Rollback();
                        ErrorLogger.AddError(err);
                        return 0;
                    }
                    catch (Exception rollerr)
                    {
                        ErrorLogger.AddError(rollerr);
                        return 0;
                    }

                }
            }
            catch(Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return 0;
            }
        }
        // bool AddRegistration(int stuId, int sessId, int locId)
        /// <summary>
        /// Creates a registration record if the session isn't full.
        /// </summary>
        /// <param name="stuId">The student id requesting the reservation.</param>
        /// <param name="sessId">The session that we're trying to reserve.</param>
        /// <param name="locId">The location id of where the session is held.</param>
        /// <returns>
        /// True if reservation succeeds, false otherwise.
        /// </returns>
        public bool AddRegistration(int stuId, int sessId, int locId)
        {
            var chkSession = new Session(sessId, locId);

            if (CheckNumOpenSeats(chkSession) == MINSEATSAVAILABLE)
                return false;

            try
            {
                _connection.Open();
                var registerTransaction = _connection.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {

                    var cmd = new MySqlCommand
                    {
                        CommandText = Constants.ADDRESERVATION,
                        Connection = _connection,
                        Transaction = registerTransaction
                    };

                    cmd.Parameters.AddWithValue(Constants.STUID, stuId);
                    cmd.Parameters.AddWithValue(Constants.SESSID, sessId);


                    cmd.ExecuteNonQuery();
                    registerTransaction.Commit();
                    _connection.Close();

                    return true;
                }

                catch (Exception err)
                {
                    try
                    {
                        registerTransaction.Rollback();
                        ErrorLogger.AddError(err);
                        return false;
                    }
                    catch (Exception rollbackerr)
                    {
                        ErrorLogger.AddError(rollbackerr);
                        return false;
                    }

                }
            }
            catch(Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // DataTable FetchAll(Table table)
        /// <summary>
        /// Fetches an entire table from the database.
        /// </summary>
        /// <param name="table">The table you want to pull from</param>
        /// <returns>
        /// An entire database table as a DataTable if the query succeeds. Returns null otherwise.
        /// </returns>
        public DataTable FetchAll(Table table,int week = 0)
        {
            try
            {
                var cmd = new MySqlCommand
                {
                    CommandText = (week == 0
                                    ? Constants.SELECTTABLE.Replace("@Table",table.ToString())
                                    : Constants.SELECTSESSIONSINWEEK.Replace("@Week", week.ToString())
                                    ),
                    Connection = _connection
                };

                _connection.Open();

                var record = new DataTable();
                using (var reader = new MySqlDataAdapter(cmd))
                {
                    reader.Fill(record);
                }

                _connection.Close();
                return record;
            }
            catch (Exception err)
            {
                // If something went wrong, make sure we don't allow further record manipulation.
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return null;
            }
        }
        // bool DeleteRegistration(int stuId, int sessId)
        /// <summary>
        /// Deletes a reservation if it exists.
        /// </summary>
        /// <param name="stuId">The student id that is canceling.</param>
        /// <param name="sessId">The session the student is canceling.</param>
        /// <returns>
        /// True if deletion is succesful. Returns false if the query was unsuccesful or invalid Id number were passed in.
        /// </returns>
        public bool DeleteRegistration(int stuId, int sessId)
        {
            if (!CheckExists(stuId, Table.STUDENT) || !CheckExists(sessId, Table.SESSION))
                return false;

            try
            {
                var cmd = new MySqlCommand
                {
                    CommandText = Constants.DELRESERVATION,
                    Connection = _connection
                };

                cmd.Parameters.AddWithValue(Constants.STUID, stuId);
                cmd.Parameters.AddWithValue(Constants.SESSID, sessId);

                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception err)
            {
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        }

        // bool RegisterStudent(string hashkey)
        /// <summary>
        /// Registers a new student; transfers their record from REG_QUEUE into STUDENT.
        /// </summary>
        /// <param name="hashkey">The hashed student email to register.</param>
        /// <returns>
        /// True if registration was succesful. False otherwise.
        /// </returns>
        public bool RegisterStudent(string hashkey)
        {
            try
            {
                var cmd = new MySqlCommand
                {
                    CommandText = Constants.SELECTREGRECORD,
                    Connection = _connection
                };



                cmd.Parameters.AddWithValue(Constants.HASH, hashkey);

                _connection.Open();

                var MySqlTransaction = _connection.BeginTransaction();

                Student newStudent =null;

                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        newStudent = new Student(null, Convert.ToInt32(reader[Constants.STU_ID]), reader[Constants.STU_FNAME].ToString(), reader[Constants.STU_LNAME].ToString(),
                                                            reader[Constants.STU_EMAIL].ToString());
                    }
                }
                _connection.Close();

                if(InsertRecord(newStudent))    // We don't want to delete the record from REG_QUEUE if we couldn't insert it into STUDENT
                {
                    DeleteRecord(newStudent.Id, Table.REG_QUEUE);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception err)
            {
                // If something went wrong, make sure we don't allow further record manipulation.
                ErrorLogger.AddError(err);
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
                return false;
            }
        } 
    }
}