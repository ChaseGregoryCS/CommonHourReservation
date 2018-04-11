namespace CHR
{
    public static class Constants
    {

        //==================================================
        // PARAMETER LABEL INDEXES
        //==================================================

        public const int INST_ID_INDEX = 0;
        public const int INST_EMAIL_INDEX = 1;
        public const int INST_FNAME_INDEX = 2;
        public const int INST_LNAME_INDEX = 3;
       

        public const int LOC_ID_INDEX = 0;
        public const int LOC_NAME_INDEX = 1;
        public const int LOC_CAP_INDEX = 2;

        public const int RES_STUID_INDEX = 0;
        public const int RES_SESSID_INDEX = 1;

        public const int SESS_NAME_INDEX = 0;
        public const int SESS_INSTID_INDEX = 1;
        public const int SESS_LOCID_INDEX = 2;
        public const int SESS_DESC_INDEX = 3;

        public const int STU_ID_INDEX = 0;
        public const int STU_EMAIL_INDEX = 1;
        public const int STU_FNAME_INDEX = 2;
        public const int STU_LNAME_INDEX = 3;
        

        //==================================================
        // SQL QUERY CONSTANTS //Querries Modified CTG 04/21/16
        //==================================================

        // GENERAL READS

        public const string SELECTTABLE = "SELECT * FROM @Table";
        public const string SELECTSESSIONSINWEEK = "Select * FROM SESSION WHERE Week = @Week";
        public const string SELECTRECORD = "SELECT * FROM @Table WHERE ID = @ID";

        public const string SELECTREGRECORD = "SELECT ID,Email,FirstName,LastName FROM REG_QUEUE WHERE email_hash = @hash";

        public const string CHECKEXISTS = "SELECT * FROM @Table WHERE ID = @ID";
        public const string CHECKEXISTINGNAME = "SELECT * FROM @Table WHERE Name = @Name AND Id != @ID";

        public const string GETREGISTEREDSESS = "SELECT * FROM SESSION WHERE ID IN (SELECT S_ID FROM RESERVATION WHERE Student_Id = @ID)";

        public const string GETTOTALRESERVATIONS = "SELECT COUNT(r_ID) FROM RESERVATION WHERE s_ID = @SessId";
        public const string GETLOCCAPACITY = "SELECT Capacity FROM LOCATION WHERE Id = @LocId";

        // INSERTS/DELETES

        public const string INSERTINSTRUCTOR = "INSERT INTO INSTRUCTOR(EMAIL,FIRSTNAME,LASTNAME) VALUES(@Email,@FirstName,@LastName)";
        public const string INSERTLOCATION = "INSERT INTO LOCATION(NAME,CAPACITY) VALUES(@Name,@Capacity)";
        public const string INSERTSTUDENT = "INSERT INTO STUDENTS(ID,FIRSTNAME,LASTNAME,EMAIL) VALUES(@Id,@FirstName,@LastName,@Email)";
        public const string INSERTSESSION = "INSERT INTO SESSION(NAME,DESCRIPTION,l_ID,Instructor_ID,Week) VALUES(@Name,@Description,@LocId,@InstId,@Week)";
        public const string INSERTRESERVATION = "INSERT INTO RESERVATION(Student_ID,s_ID) VALUES(@StuId,@SessId)";


        public const string DELETERECORD = "DELETE FROM @Table WHERE ID = @ID";

        public const string ADDRESERVATION = "INSERT INTO RESERVATION(Student_ID,s_ID) VALUES(@StuId,@SessId)";
        public const string DELRESERVATION = "DELETE FROM RESERVATION WHERE Student_ID = @StuId AND s_ID = @SessId";

        // UPDATES

        public const string UPDATEINSTRUCTOR = "UPDATE INSTRUCTOR " +
                                              "SET FIRSTNAME = @FirstName, LASTNAME = @LastName, EMAIL = @Email " +
                                              "WHERE ID = @Id";
        public const string UPDATELOCATION = "UPDATE LOCATION " +
                                              "SET NAME = @Name, Capacity = @Capacity " +
                                              "WHERE ID = @Id";
        public const string UPDATESESSION = "UPDATE SESSION " +
                                              "SET NAME = @Name, Instructor_ID = @InstId, l_ID = @LocId, DESCRIPTION = @Description, WEEK = @Week " +
                                              "WHERE ID = @Id";
        public const string UPDATESTUDENT = "UPDATE STUDENT " +
                                              "SET FIRSTNAME = @FirstName, LASTNAME = @LastName, EMAIL = @Email " +
                                              "WHERE ID = @Id";
        public const string UPDATEINSTRUCTORFNAME = "UPDATE instructor " +
                                                    "SET F_Name = @fName, Email = @Email " +
                                                    "WHERE instructor_ID = @Id";
        public const string UPDATEINSTRUCTORLNAME = "UPDATE instructor " +
                                                    "SET L_Name = @lName, Email = @Email " +
                                                    "WHERE instructor_ID = @Id";     

        // COLUMN LABELS

        public const string STU_ID = "Id";
        public const string STU_EMAIL = "Email";
        public const string STU_FNAME = "FirstName";
        public const string STU_LNAME = "LastName";

        //==================================================
        // SQL PARAMETER CONSTANTS
        //==================================================

        public const string ID = "@ID";
        public const string NAME = "@Name";
        public const string TABLE = "@Table";
        public const string EMAIL = "@Email";
        public const string CAPACITY = "@Capacity";
        public const string STUID = "@StuId";
        public const string SESSID = "@SessId";
        public const string INSTID = "@InstId";
        public const string LOCID = "@LocId";
        public const string DESC = "@Description";
        public const string WEEK = "@Week";
        public const string FNAME = "@FirstName";
        public const string LNAME = "@LastName";
        public const string HASH = "@hash";
    }


}