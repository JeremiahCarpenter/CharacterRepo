using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ContextDAL : IDisposable
    {
        #region Connection
        public string ConnectionString
        {
            get { return conn.ConnectionString; }
            set { conn.ConnectionString = value; }
        }

        private SqlConnection conn = new SqlConnection();

        // checks for a connection and opens a connection only if there isn't one
        private void EnsureConnected()
        {

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            else if (conn.State == System.Data.ConnectionState.Broken)
            {
                // if the connection is broken, then throw an exception
                throw (new Exception("The SqlConnection is broken"));
            }
        }
        #endregion

        #region Simple dispose
        public void Dispose()
        {
            conn.Dispose();
        }

        #endregion


        #region Author Table Crud

        // Add an Author to the Author table in the database and retrieve the ID for the new Author
        public int AddAuthor(string _name)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_AUTHOR", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_Name", _name);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                // Return the newly created ID for the database entry
                return Convert.ToInt32(command.Parameters["@ID"].Value);
            }

        }

        // Get a list of all Authors from the Author table in the database
        public List<AuthorDO> GetAuthorDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<AuthorDO> _listAuthorDOs = new List<AuthorDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_AUTHORS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        AuthorDO _authorDO = new AuthorDO();

                        // Object property = database cell data
                        _authorDO.AuthorID = (int)reader["AuthorID"];
                        _authorDO.Name = (string)reader["Name"];

                        // Add the object to the list
                        _listAuthorDOs.Add(_authorDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listAuthorDOs;
        }

        // Get an Author by ID from the Author table in the database
        public AuthorDO GetAuthorDOByID(int _authorID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();           
           
            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_AUTHOR_BY_AUTHORID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_AuthorID", _authorID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        AuthorDO _authorDO = new AuthorDO();

                        // Object property = database cell data
                        _authorDO.AuthorID = (int)reader["AuthorID"];
                        _authorDO.Name = (string)reader["Name"];

                        reader.Close();
                        return _authorDO;
                    }
                }
            }
            // Return the object
            return null;
        }

        // Get an Author by Author Name from the Author table in the database
        public AuthorDO GetAuthorDOByName(string _name)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_AUTHOR_BY_NAME", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_Name", _name);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        AuthorDO _authorDO = new AuthorDO();

                        // Object property = database cell data
                        _authorDO.AuthorID = (int)reader["AuthorID"];
                        _authorDO.Name = (string)reader["Name"];

                        if (reader.Read())
                        {
                            throw new Exception($"Found multiple records of the Name {_name} in the database");
                        }
                        return _authorDO;
                    }
                }               
            }
            // Return a default value
            return null;
        }

        // Delete an Author
        public void DeleteAuthor(int _authorID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_AUTHOR", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_AuthorID", _authorID);

                command.ExecuteNonQuery();
            }
        }

        // Update an Author
        public void UpdateAuthor(int _authorID, string _name)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_UPDATE_AUTHOR", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_AuthorID", _authorID);
                command.Parameters.AddWithValue("@parm_Name", _name);

                // Execute the Command                    
                command.ExecuteNonQuery();
            }

        }

        #endregion

        #region Book Table CRUD

        // Add a Book to the Book table in the database and retrieve the ID for the new Book
        public int AddBook(string _title, int _seriesID_FK)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_BOOK", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_Title", _title);
                command.Parameters.AddWithValue("@parm_SeriesID_FK", _seriesID_FK);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                // Return the newly created ID for the database entry
                return Convert.ToInt32(command.Parameters["@ID"].Value);
            }

        }

        // Get a list of all Books from the Book table in the database
        public List<BookDO> GetBookDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<BookDO> _listBookDOs = new List<BookDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_BOOKS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        BookDO _bookDO = new BookDO();

                        // Object property = database cell data
                        _bookDO.BookID = (int)reader["BookID"];
                        _bookDO.Title = (string)reader["Title"];
                        _bookDO.SeriesID_FK = (int)reader["SeriesID_FK"];

                        // Add the object to the list
                        _listBookDOs.Add(_bookDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listBookDOs;
        }

        //// Get the Book related to the BookID from the Book table in the database
        //public List<BookDO> GetBookDOs(int _bookID)
        //{
        //    // Check for a connection to the database and open a connection if none exists
        //    EnsureConnected();

        //    // Create a list of objects to poplulate with table data 
        //    List<BookDO> _listBookDOs = new List<BookDO>();

        //    // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
        //    using (SqlCommand command = new SqlCommand("SP_SELECT_A_BOOK_BY_BOOKID", conn))
        //    {
        //        // Define the CommandType
        //        command.CommandType = System.Data.CommandType.StoredProcedure;

        //        // Add Parameters for the Command
        //        command.Parameters.AddWithValue("@parm_BookID", _bookID);

        //        // Execute the Command
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            // Create a loop to cycle through the items in database
        //            while (reader.Read())
        //            {
        //                // Create an object to define using values from the database
        //                BookDO _bookDO = new BookDO();

        //                // Object property = database cell data
        //                _bookDO.BookID = (int)reader["BookID"];
        //                _bookDO.Title = (string)reader["Title"];
        //                _bookDO.SeriesID_FK = (int)reader["SeriesID_FK"];

        //                // Add the object to the list
        //                _listBookDOs.Add(_bookDO);
        //            }
        //            reader.Close();
        //        }
        //    }
        //    // Return the list
        //    return _listBookDOs;
        //}


        // Get the Book related to the BookID from the Book table in the database
        public BookDO GetBookDOByID(int _bookID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_BOOK_BY_BOOKID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_BookID", _bookID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        BookDO _bookDO = new BookDO();

                        // Object property = database cell data
                        _bookDO.BookID = (int)reader["BookID"];
                        _bookDO.Title = (string)reader["Title"];
                        _bookDO.SeriesID_FK = (int)reader["SeriesID_FK"];

                        reader.Close();
                        return _bookDO; 
                    }
                }
            }
            // Return the object
            return null;
        }

        public BookDO GetBookDOByTitle(string _title)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_BOOK_BY_TITLE", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_Title", _title);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        BookDO _bookDO = new BookDO();

                        // Object property = database cell data
                        _bookDO.BookID = (int)reader["BookID"];
                        _bookDO.Title = (string)reader["Title"];
                        _bookDO.SeriesID_FK = (int)reader["SeriesID_FK"];

                        reader.Close();
                        return _bookDO;
                    }
                }
            }
            // Return the object
            return null;
        }

        // Get a list of all Books by SeriesID from the Book table in the database
        public List<BookDO> GetBookDOsBySeriesID(int _seriesID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<BookDO> _listBookDOs = new List<BookDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_BOOKS_BY_SERIES_ID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SeriesID", _seriesID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        BookDO _bookDO = new BookDO();

                        // Object property = database cell data
                        _bookDO.BookID = (int)reader["BookID"];
                        _bookDO.Title = (string)reader["Title"];
                        _bookDO.SeriesID_FK = (int)reader["SeriesID_FK"];

                        // Add the object to the list
                        _listBookDOs.Add(_bookDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listBookDOs;
        }

        // Delete a Book
        public void DeleteBook(int _bookID)
        {

            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_BOOK", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_BookID", _bookID);

                command.ExecuteNonQuery();
            }
        }

        // Update a Book
        public void UpdateBook(int _bookID, string _title, int _seriesID_FK)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_UPDATE_BOOK", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_BookID", _bookID);
                command.Parameters.AddWithValue("@parm_Title", _title);
                command.Parameters.AddWithValue("@parm_SeriesID_FK", _seriesID_FK);

                // Execute the Command                    
                command.ExecuteNonQuery();
            }

        }


        #endregion

        #region Character Table Crud

        // Add a Character to the Character table in the database and retrieve the ID for the new Character
        public int AddCharacter(string _name, string _class, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_Name", _name);
                command.Parameters.AddWithValue("@parm_Class", _class);
                command.Parameters.AddWithValue("@parm_AC", _ac);
                command.Parameters.AddWithValue("@parm_Strength", _str);
                command.Parameters.AddWithValue("@parm_Dexterity", _dex);
                command.Parameters.AddWithValue("@parm_Constitution", _con);
                command.Parameters.AddWithValue("@parm_Intelligence", _intel);
                command.Parameters.AddWithValue("@parm_Wisdom", _wis);
                command.Parameters.AddWithValue("@parm_Charisma", _char);
                command.Parameters.AddWithValue("@parm_Description", _desc);
                command.Parameters.AddWithValue("@parm_SeriesID_FK", _Sid);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                // Return the newly created ID for the database entry
                return Convert.ToInt32(command.Parameters["@ID"].Value);
            }

        }

        // Get a list of all Characters from the Character table in the database
        public List<CharacterDO> GetCharacterDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<CharacterDO> _listCharacterDOs = new List<CharacterDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_CHARACTERS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        CharacterDO _characterDO = new CharacterDO();

                        // Object property = database cell data
                        _characterDO.CharacterID = (int)reader["CharacterID"];
                        _characterDO.Name = (string)reader["Name"];
                        _characterDO.Class = (string)reader["Class"];
                        _characterDO.AC = (int)reader["AC"];
                        _characterDO.Strength = (int)reader["Strength"];
                        _characterDO.Dexterity = (int)reader["Dexterity"];
                        _characterDO.Constitution = (int)reader["Constitution"];
                        _characterDO.Intelligence = (int)reader["Intelligence"];
                        _characterDO.Wisdom = (int)reader["Wisdom"];
                        _characterDO.Charisma = (int)reader["Charisma"];
                        _characterDO.Description = (string)reader["Description"];
                        _characterDO.SeriesID_FK = (int)reader["SeriesID_FK"];

                        // Add the object to the list
                        _listCharacterDOs.Add(_characterDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listCharacterDOs;
        }

        // Get a Character by ID from the Character table in the database
        public CharacterDO GetCharacterDOByID(int _characterID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_CHARACTER_BY_CHARACTERID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_CharacterID", _characterID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        CharacterDO _characterDO = new CharacterDO();

                        // Object property = database cell data
                        _characterDO.CharacterID = (int)reader["CharacterID"];
                        _characterDO.Name = (string)reader["Name"];
                        _characterDO.Class = (string)reader["Class"];
                        _characterDO.AC = (int)reader["AC"];
                        _characterDO.Strength = (int)reader["Strength"];
                        _characterDO.Dexterity = (int)reader["Dexterity"];
                        _characterDO.Constitution = (int)reader["Constitution"];
                        _characterDO.Intelligence = (int)reader["Intelligence"];
                        _characterDO.Wisdom = (int)reader["Wisdom"];
                        _characterDO.Charisma = (int)reader["Charisma"];
                        _characterDO.Description = (string)reader["Description"];
                        _characterDO.SeriesID_FK = (int)reader["SeriesID_FK"];

                        reader.Close();
                        return _characterDO; 
                    }
                }
            }
            // Return null for no object
            return null;
        }

        // Delete a Character
        public void DeleteCharacter(int _characterID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_CharacterID", _characterID);

                command.ExecuteNonQuery();
            }
        }

        // Update a Character
        public void UpdateCharacter(int _characterID, string _name, string _class, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_UPDATE_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_CharacterID", _characterID);
                command.Parameters.AddWithValue("@parm_Name", _name);
                command.Parameters.AddWithValue("@parm_Class", _class);
                command.Parameters.AddWithValue("@parm_AC", _ac);
                command.Parameters.AddWithValue("@parm_Strength", _str);
                command.Parameters.AddWithValue("@parm_Dexterity", _dex);
                command.Parameters.AddWithValue("@parm_Constitution", _con);
                command.Parameters.AddWithValue("@parm_Intelligence", _intel);
                command.Parameters.AddWithValue("@parm_Wisdom", _wis);
                command.Parameters.AddWithValue("@parm_Charisma", _char);
                command.Parameters.AddWithValue("@parm_Description", _desc);
                command.Parameters.AddWithValue("@parm_SeriesID_FK", _Sid);

                // Execute the Command                    
                command.ExecuteNonQuery();
            }

        }

        #endregion

        #region Class Table CRUD

        // Add a Class to the Class table in the database and retrieve the ID for the new Class
        public int AddClass(string _className, int _classDiceValue)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_CLASS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_ClassName", _className);
                command.Parameters.AddWithValue("@parm_ClassDiceValue", _classDiceValue);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                // Return the newly created ID for the database entry
                return Convert.ToInt32(command.Parameters["@ID"].Value);
            }

        }

        // Get a list of all Classes from the Class table in the database
        public List<ClassDO> GetClassDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<ClassDO> _listClassDOs = new List<ClassDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_CLASSES", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        ClassDO _classDO = new ClassDO();

                        // Object property = database cell data
                        _classDO.ClassID = (int)reader["ClassID"];
                        _classDO.ClassName = (string)reader["ClassName"];
                        _classDO.ClassDiceValue = (int)reader["ClassDiceValue"];

                        // Add the object to the list
                        _listClassDOs.Add(_classDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listClassDOs;
        }

        // Get a Class object from the Class table in the database by ClassID
        public ClassDO GetClassDOByID(int _classID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_CLASS_BY_CLASSID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_ClassID", _classID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {                    
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        ClassDO _classDO = new ClassDO();

                        // Object property = database cell data
                        _classDO.ClassID = (int)reader["ClassID"];
                        _classDO.ClassName = (string)reader["ClassName"];
                        _classDO.ClassDiceValue = (int)reader["ClassDiceValue"];

                        reader.Close();
                        return _classDO;
                    }
                }
            }
            // Return a default
            return null;
        }

        // Get a Class object from the Class table in the database by ClassName
        public ClassDO GetClassDOByClassName(string _className)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();           

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_CLASS_BY_CLASSNAME", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_ClassName", _className);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        ClassDO _classDO = new ClassDO();

                        // Object property = database cell data
                        _classDO.ClassID = (int)reader["ClassID"];
                        _classDO.ClassName = (string)reader["ClassName"];
                        _classDO.ClassDiceValue = (int)reader["ClassDiceValue"];
                        if (reader.Read())
                        {
                            throw new Exception($"Found multiple records of the Class Name {_className} in the database");
                        }
                        reader.Close();
                        return _classDO;
                    }
                }
            }
            // Return a default
            return null;
        }

        // Delete a Class
        public void DeleteClass(int _classID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_CLASS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_ClassID", _classID);

                command.ExecuteNonQuery();
            }
        }

        // Update a Class
        public void UpdateClass(int _classID, string _className, int _classDiceValue)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_UPDATE_CLASS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_ClassID", _classID);
                command.Parameters.AddWithValue("@parm_ClassName", _className);
                command.Parameters.AddWithValue("@parm_ClassDiceValue", _classDiceValue);

                // Execute the Command                    
                command.ExecuteNonQuery();

            }

        }

        #endregion

        #region Role Table CRUD

        // Get a list of all Authors from the Author table in the database
        public List<RoleDO> GetRoleDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<RoleDO> _listRoleDOs = new List<RoleDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_ROLES", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        RoleDO _roleDO = new RoleDO();

                        // Object property = database cell data
                        _roleDO.RoleID = (int)reader["RoleID"];
                        _roleDO.Role = (string)reader["Role"];

                        // Add the object to the list
                        _listRoleDOs.Add(_roleDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listRoleDOs;
        }

        // Get a Role by Id from the Role table in the database
        public RoleDO GetRoleDOByID(int _roleID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_ROLE_BY_ROLEID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_RoleID", _roleID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        RoleDO _roleDO = new RoleDO();

                        // Object property = database cell data
                        _roleDO.RoleID = (int)reader["RoleID"];
                        _roleDO.Role = (string)reader["Role"];

                        reader.Close();
                        return _roleDO;
                    }
                }               
            }
            // Return a default
            return null;
        }

        #endregion

        #region Series Table CRUD

        // Add a Series to the Series table in the database and retrieve the ID for the new Series
        public int AddSeries(string _seriesTitle, int _authorID_FK)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_SERIES", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SeriesTitle", _seriesTitle);
                command.Parameters.AddWithValue("@parm_AuthorID_FK", _authorID_FK);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                // Return the newly created ID for the database entry
                return Convert.ToInt32(command.Parameters["@ID"].Value);
            }

        }

        // Get a list of all Series from the Series table in the database
        public List<SeriesDO> GetSeriesDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<SeriesDO> _listSeriesDOs = new List<SeriesDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_SERIES", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        SeriesDO _seriesDO = new SeriesDO();

                        // Object property = database cell data
                        _seriesDO.SeriesID = (int)reader["SeriesID"];
                        _seriesDO.SeriesTitle = (string)reader["SeriesTitle"];
                        _seriesDO.AuthorID_FK = (int)reader["AuthorID_FK"];

                        // Add the object to the list
                        _listSeriesDOs.Add(_seriesDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listSeriesDOs;
        }

        // Get a Series by ID from the Series table in the database
        public SeriesDO GetSeriesDOByID(int _seriesID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();           

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_SERIES_BY_SERIESID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SeriesID", _seriesID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        SeriesDO _seriesDO = new SeriesDO();

                        // Object property = database cell data
                        _seriesDO.SeriesID = (int)reader["SeriesID"];
                        _seriesDO.SeriesTitle = (string)reader["SeriesTitle"];
                        _seriesDO.AuthorID_FK = (int)reader["AuthorID_FK"];

                        reader.Close();
                        return _seriesDO;
                    }
                }
            }
            // Return a default
            return null;
        }

        // Get a Series by SeriesTitle from the Series table in the database
        public SeriesDO GetSeriesDOBySeriesTitle(string _seriesTitle)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();
            
            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_SERIES_BY_SERIESTITLE", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SeriesTitle", _seriesTitle);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        SeriesDO _seriesDO = new SeriesDO();

                        // Object property = database cell data
                        _seriesDO.SeriesID = (int)reader["SeriesID"];
                        _seriesDO.SeriesTitle = (string)reader["SeriesTitle"];
                        _seriesDO.AuthorID_FK = (int)reader["AuthorID_FK"];

                        if (reader.Read())
                        {
                            throw new Exception($"Found multiple records of the SeriesTitle {_seriesTitle} in the database");
                        }
                        // reader.Close();
                        return _seriesDO;
                    }
                }                
            }
            // Return default value
            return null;
        }

        // Delete a Series
        public void DeleteSeries(int _seriesID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_SERIES", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SeriesID", _seriesID);

                command.ExecuteNonQuery();
            }
        }

        // Update a Series
        public void UpdateSeries(int _seriesID, string _seriesTitle, int _authorID_FK)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_UPDATE_SERIES", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SeriesID", _seriesID);
                command.Parameters.AddWithValue("@parm_SeriesTitle", _seriesTitle);
                command.Parameters.AddWithValue("@parm_AuthorID_FK", _authorID_FK);

                // Execute the Command                    
                command.ExecuteNonQuery();

            }

        }

        #endregion

        #region Suggested Character CRUD

        // Add a SuggestedCharacter to the SuggestedCharacter table in the database and retrieve the ID for the new SuggestedCharacter
        public int AddSuggestedCharacter(string _suggestedCharacterName, string _suggestedCharacterSeries)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_SUGGESTED_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SuggestedCharacterName", _suggestedCharacterName);
                command.Parameters.AddWithValue("@parm_SuggestedCharacterSeries", _suggestedCharacterSeries);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                // Return the newly created ID for the database entry
                return Convert.ToInt32(command.Parameters["@ID"].Value);
            }

        }

        // Get a list of all SuggestedCharacters from the SuggestedCharacter table in the database
        public List<SuggestedCharacterDO> GetSuggestedCharacterDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<SuggestedCharacterDO> _listSuggestedCharacterDOs = new List<SuggestedCharacterDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_SUGGESTED_CHARACTERS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        SuggestedCharacterDO _suggestedCharacteraDO = new SuggestedCharacterDO();

                        // Object property = database cell data
                        _suggestedCharacteraDO.SuggestedCharacterID = (int)reader["SuggestedCharacterID"];
                        _suggestedCharacteraDO.SuggestedCharacterName = (string)reader["SuggestedCharacterName"];
                        _suggestedCharacteraDO.SuggestedCharacterSeries = (string)reader["SuggestedCharacterSeries"];

                        // Add the object to the list
                        _listSuggestedCharacterDOs.Add(_suggestedCharacteraDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listSuggestedCharacterDOs;
        }

        // Get a SuggestedCharacters by ID from the SuggestedCharacter table in the database
        public SuggestedCharacterDO GetSuggestedCharacterDOByID(int _suggestedCharacterID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_S_CHARACTER_BY_S_CHARACTERID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SuggestedCharacterID", _suggestedCharacterID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        SuggestedCharacterDO _suggestedCharacteraDO = new SuggestedCharacterDO();

                        // Object property = database cell data
                        _suggestedCharacteraDO.SuggestedCharacterID = (int)reader["SuggestedCharacterID"];
                        _suggestedCharacteraDO.SuggestedCharacterName = (string)reader["SuggestedCharacterName"];
                        _suggestedCharacteraDO.SuggestedCharacterSeries = (string)reader["SuggestedCharacterSeries"];

                        reader.Close();
                        return _suggestedCharacteraDO;
                    }
                }
            }
            // Return a default
            return null;
        }

        // Delete a SuggestedCharacter
        public void DeleteSuggestedCharacter(int _suggestedCharacterID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_SUGGESTED_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_SuggestedCharacterID", _suggestedCharacterID);

                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region User Table CRUD

        // Add an User to the User table in the database and retrieve the ID for the new User
        public int AddUser(string _firstName, string _LastName, string _userName, string _password, string _emailAddress, int _roleID_FK)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_USER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_FirstName", _firstName);
                command.Parameters.AddWithValue("@parm_LastName", _LastName);
                command.Parameters.AddWithValue("@parm_UserName", _userName);
                command.Parameters.AddWithValue("@parm_Password", _password);
                command.Parameters.AddWithValue("@parm_EmailAddress", _emailAddress);
                command.Parameters.AddWithValue("@parm_RoleID_FK", _roleID_FK);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                // Return the newly created ID for the database entry
                return Convert.ToInt32(command.Parameters["@ID"].Value);
            }

        }

        // Get a list of all Users from the User table in the database
        public List<UserDO> GetUserDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<UserDO> _listUserDOs = new List<UserDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_USERS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        UserDO _userDO = new UserDO();

                        // Object property = database cell data
                        _userDO.UserID = (int)reader["UserID"];
                        _userDO.FirstName = (string)reader["FirstName"];
                        _userDO.LastName = (string)reader["LastName"];
                        _userDO.UserName = (string)reader["Username"];
                        _userDO.Password = (string)reader["Password"];
                        _userDO.EmailAddress = (string)reader["EmailAddress"];
                        _userDO.RoleID_FK = (int)reader["RoleID_FK"];

                        // Add the object to the list
                        _listUserDOs.Add(_userDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listUserDOs;
        }

        // Get a User by UserID from the User table in the database
        public UserDO GetUserDOByID(int _userID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_USER_BY_USERID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserID", _userID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        UserDO _userDO = new UserDO();

                        // Object property = database cell data
                        _userDO.UserID = (int)reader["UserID"];
                        _userDO.FirstName = (string)reader["FirstName"];
                        _userDO.LastName = (string)reader["LastName"];
                        _userDO.UserName = (string)reader["Username"];
                        _userDO.Password = (string)reader["Password"];
                        _userDO.EmailAddress = (string)reader["EmailAddress"];
                        _userDO.RoleID_FK = (int)reader["RoleID_FK"];

                        reader.Close();
                        return _userDO;
                    }
                }
            }
            // Return a default
            return null;
        }

        // Get a User by Username from the User table in the database
        public UserDO GetUserDOByUsername(string _username)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_USER_BY_USERNAME", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_Username", _username);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        UserDO _userDO = new UserDO();

                        // Object property = database cell data
                        _userDO.UserID = (int)reader["UserID"];
                        _userDO.FirstName = (string)reader["FirstName"];
                        _userDO.LastName = (string)reader["LastName"];
                        _userDO.UserName = (string)reader["Username"];
                        _userDO.Password = (string)reader["Password"];
                        _userDO.EmailAddress = (string)reader["EmailAddress"];
                        _userDO.RoleID_FK = (int)reader["RoleID_FK"];
                        if (reader.Read())
                        {
                            throw new Exception($"Found multiple records of the username {_username} in the database");
                        }
                        // reader.Close();
                        return _userDO;
                    }
                }
            }
            // return a default
            return null;
        }

        // Delete a User
        public void DeleteUser(int _userID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_USER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserID", _userID);

                command.ExecuteNonQuery();
            }
        }

        // Update a User in the User table
        public void UpdateUser(int _userID, string _firstName, string _LastName, string _userName, string _password, string _emailAddress, int _roleID_FK)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_UPDATE_USER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserID", _userID);
                command.Parameters.AddWithValue("@parm_FirstName", _firstName);
                command.Parameters.AddWithValue("@parm_LastName", _LastName);
                command.Parameters.AddWithValue("@parm_UserName", _userName);
                command.Parameters.AddWithValue("@parm_Password", _password);
                command.Parameters.AddWithValue("@parm_EmailAddress", _emailAddress);
                command.Parameters.AddWithValue("@parm_RoleID_FK", _roleID_FK);

                // Execute the Command                    
                command.ExecuteNonQuery();

            }
        }

        #endregion

        #region UserCharacter Table CRUD

        // Add a UserCharacter to the UserCharacter table in the database and retrieve the ID for the new UserCharacter
        public int AddUserCharacter(string _name, string _class, int _cl, int _hp, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid, int _Uid)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_CREATE_USER_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_Name", _name);
                command.Parameters.AddWithValue("@parm_Class", _class);
                command.Parameters.AddWithValue("@parm_ClassLevel", _cl);
                command.Parameters.AddWithValue("@parm_HitPoints", _hp);
                command.Parameters.AddWithValue("@parm_AC", _ac);
                command.Parameters.AddWithValue("@parm_Strength", _str);
                command.Parameters.AddWithValue("@parm_Dexterity", _dex);
                command.Parameters.AddWithValue("@parm_Constitution", _con);
                command.Parameters.AddWithValue("@parm_Intelligence", _intel);
                command.Parameters.AddWithValue("@parm_Wisdom", _wis);
                command.Parameters.AddWithValue("@parm_Charisma", _char);
                command.Parameters.AddWithValue("@parm_Description", _desc);
                command.Parameters.AddWithValue("@parm_SeriesID_FK", _Sid);
                command.Parameters.AddWithValue("@parm_UserID_FK", _Uid);

                // Add a Parameter for the return value of the ID
                command.Parameters.AddWithValue("@ID", 0);
                command.Parameters["@ID"].Direction = System.Data.ParameterDirection.InputOutput;

                // Execute the Command                    
                command.ExecuteNonQuery();

                return Convert.ToInt32(command.Parameters["@ID"].Value);

            }
            // conn.Close();
        }

        // Get a list of all UserCharacters from the UserCharacter table in the database
        public List<UserCharacterDO> GetUserCharacterDOs()
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<UserCharacterDO> _listUserCharacterDOs = new List<UserCharacterDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_USER_CHARACTERS", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        UserCharacterDO _userCharacterDO = new UserCharacterDO();

                        // Object property = database cell data
                        _userCharacterDO.UserCharacterID = (int)reader["UserCharacterID"];
                        _userCharacterDO.Name = (string)reader["Name"];
                        _userCharacterDO.Class = (string)reader["Class"];
                        _userCharacterDO.ClassLevel = (int)reader["ClassLevel"];
                        _userCharacterDO.HitPoints = (int)reader["HitPoints"];
                        _userCharacterDO.AC = (int)reader["AC"];
                        _userCharacterDO.Strength = (int)reader["Strength"];
                        _userCharacterDO.Dexterity = (int)reader["Dexterity"];
                        _userCharacterDO.Constitution = (int)reader["Constitution"];
                        _userCharacterDO.Intelligence = (int)reader["Intelligence"];
                        _userCharacterDO.Wisdom = (int)reader["Wisdom"];
                        _userCharacterDO.Charisma = (int)reader["Charisma"];
                        _userCharacterDO.Description = (string)reader["Description"];
                        _userCharacterDO.SeriesID_FK = (int)reader["SeriesID_FK"];
                        _userCharacterDO.UserID_FK = (int)reader["UserID_FK"];


                        // Add the object to the list
                        _listUserCharacterDOs.Add(_userCharacterDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listUserCharacterDOs;
        }

        // Get a list of UserCharacters by UserID from the UserCharacter table in the database
        public List<UserCharacterDO> GetUserCharacterDOsByUserID(int _userID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<UserCharacterDO> _listUserCharacterDOs = new List<UserCharacterDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_USER_CHARACTERS_BY_USERID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserID", _userID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        UserCharacterDO _userCharacterDO = new UserCharacterDO();

                        // Object property = database cell data
                        _userCharacterDO.UserCharacterID = (int)reader["UserCharacterID"];
                        _userCharacterDO.Name = (string)reader["Name"];
                        _userCharacterDO.Class = (string)reader["Class"];
                        _userCharacterDO.ClassLevel = (int)reader["ClassLevel"];
                        _userCharacterDO.HitPoints = (int)reader["HitPoints"];
                        _userCharacterDO.AC = (int)reader["AC"];
                        _userCharacterDO.Strength = (int)reader["Strength"];
                        _userCharacterDO.Dexterity = (int)reader["Dexterity"];
                        _userCharacterDO.Constitution = (int)reader["Constitution"];
                        _userCharacterDO.Intelligence = (int)reader["Intelligence"];
                        _userCharacterDO.Wisdom = (int)reader["Wisdom"];
                        _userCharacterDO.Charisma = (int)reader["Charisma"];
                        _userCharacterDO.Description = (string)reader["Description"];
                        _userCharacterDO.SeriesID_FK = (int)reader["SeriesID_FK"];
                        _userCharacterDO.UserID_FK = (int)reader["UserID_FK"];


                        // Add the object to the list
                        _listUserCharacterDOs.Add(_userCharacterDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listUserCharacterDOs;
        }

        // Get a list of UserCharacters by UserName from the UserCharacter table in the database
        public List<UserCharacterDO> GetUserCharacterDOsByUserName(string _userName)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a list of objects to poplulate with table data 
            List<UserCharacterDO> _listUserCharacterDOs = new List<UserCharacterDO>();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_ALL_USER_CHARACTERS_BY_USERNAME", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserName", _userName);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Create a loop to cycle through the items in database
                    while (reader.Read())
                    {
                        // Create an object to define using values from the database
                        UserCharacterDO _userCharacterDO = new UserCharacterDO();

                        // Object property = database cell data
                        _userCharacterDO.UserCharacterID = (int)reader["UserCharacterID"];
                        _userCharacterDO.Name = (string)reader["Name"];
                        _userCharacterDO.Class = (string)reader["Class"];
                        _userCharacterDO.ClassLevel = (int)reader["ClassLevel"];
                        _userCharacterDO.HitPoints = (int)reader["HitPoints"];
                        _userCharacterDO.AC = (int)reader["AC"];
                        _userCharacterDO.Strength = (int)reader["Strength"];
                        _userCharacterDO.Dexterity = (int)reader["Dexterity"];
                        _userCharacterDO.Constitution = (int)reader["Constitution"];
                        _userCharacterDO.Intelligence = (int)reader["Intelligence"];
                        _userCharacterDO.Wisdom = (int)reader["Wisdom"];
                        _userCharacterDO.Charisma = (int)reader["Charisma"];
                        _userCharacterDO.Description = (string)reader["Description"];
                        _userCharacterDO.SeriesID_FK = (int)reader["SeriesID_FK"];
                        _userCharacterDO.UserID_FK = (int)reader["UserID_FK"];


                        // Add the object to the list
                        _listUserCharacterDOs.Add(_userCharacterDO);
                    }
                    reader.Close();
                }
            }
            // Return the list
            return _listUserCharacterDOs;
        }

        // Get a UserCharacters by UserCharacterID from the UserCharacter table in the database
        public UserCharacterDO GetUserCharacterDOByID(int _userCharacterID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();            

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_SELECT_A_USER_CHARACTER_BY_USER_CHARACTERID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserCharacterID", _userCharacterID);

                // Execute the Command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Create an object to define using values from the database
                        UserCharacterDO _userCharacterDO = new UserCharacterDO();

                        // Object property = database cell data
                        _userCharacterDO.UserCharacterID = (int)reader["UserCharacterID"];
                        _userCharacterDO.Name = (string)reader["Name"];
                        _userCharacterDO.Class = (string)reader["Class"];
                        _userCharacterDO.ClassLevel = (int)reader["ClassLevel"];
                        _userCharacterDO.HitPoints = (int)reader["HitPoints"];
                        _userCharacterDO.AC = (int)reader["AC"];
                        _userCharacterDO.Strength = (int)reader["Strength"];
                        _userCharacterDO.Dexterity = (int)reader["Dexterity"];
                        _userCharacterDO.Constitution = (int)reader["Constitution"];
                        _userCharacterDO.Intelligence = (int)reader["Intelligence"];
                        _userCharacterDO.Wisdom = (int)reader["Wisdom"];
                        _userCharacterDO.Charisma = (int)reader["Charisma"];
                        _userCharacterDO.Description = (string)reader["Description"];
                        _userCharacterDO.SeriesID_FK = (int)reader["SeriesID_FK"];
                        _userCharacterDO.UserID_FK = (int)reader["UserID_FK"];

                        reader.Close();
                        return _userCharacterDO;
                    }
                }
            }
            // Return a default
            return null;
        }

        // Delete a UserCharacter by UserCharacterID
        public void DeleteUserCharacter(int _userCharacterID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_USER_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserCharacterID", _userCharacterID);

                command.ExecuteNonQuery();
            }
        }

        // Delete a UserCharacter by UserID
        public void DeleteUserCharacterByUserID(int _userID)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_DELETE_USER_CHARACTER_BY_USERID", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserID", _userID);

                command.ExecuteNonQuery();
            }
        }

        // Update a UserCharacter
        public void UpdateUserCharacter(int _userCharacterID, string _name, string _class, int _cl, int _hp, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid, int _Uid)
        {
            // Check for a connection to the database and open a connection if none exists
            EnsureConnected();

            // Create a SqlCommand with parameters for a Stored Procedure and the connection to the database
            using (SqlCommand command = new SqlCommand("SP_UPDATE_USER_CHARACTER", conn))
            {
                // Define the CommandType
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Add Parameters for the Command
                command.Parameters.AddWithValue("@parm_UserCharacterID", _userCharacterID);
                command.Parameters.AddWithValue("@parm_Name", _name);
                command.Parameters.AddWithValue("@parm_Class", _class);
                command.Parameters.AddWithValue("@parm_ClassLevel", _cl);
                command.Parameters.AddWithValue("@parm_HitPoints", _hp);
                command.Parameters.AddWithValue("@parm_AC", _ac);
                command.Parameters.AddWithValue("@parm_Strength", _str);
                command.Parameters.AddWithValue("@parm_Dexterity", _dex);
                command.Parameters.AddWithValue("@parm_Constitution", _con);
                command.Parameters.AddWithValue("@parm_Intelligence", _intel);
                command.Parameters.AddWithValue("@parm_Wisdom", _wis);
                command.Parameters.AddWithValue("@parm_Charisma", _char);
                command.Parameters.AddWithValue("@parm_Description", _desc);
                command.Parameters.AddWithValue("@parm_SeriesID_FK", _Sid);
                command.Parameters.AddWithValue("@parm_UserID_FK", _Uid);


                // Execute the Command                    
                command.ExecuteNonQuery();


            }
            // conn.Close();
        }


        #endregion


        #region IDisposable Support

        //private bool disposedValue = false; // To detect redundant calls

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposedValue)
        //    {
        //        if (disposing)
        //        {
        //            // TODO: dispose managed state (managed objects).
        //        }

        //        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        //        // TODO: set large fields to null.
        //        conn.Dispose();
        //        disposedValue = true;
        //    }
        //}

        //// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //~ContextDAL()
        //{
        //    // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //    Dispose(false);
        //    throw new Exception("The ContextDAL was not Disposed Properly. You should either use it within C# Using Construct, or call Dispose on the instance before it goes out of scope.");

        //}

        //// This code added to correctly implement the disposable pattern.
        //public void Dispose()
        //{
        //    // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //    Dispose(true);

        //    // TODO: uncomment the following line if the finalizer is overridden above.           

        //    GC.SuppressFinalize(this);
        //}
        #endregion


    }
}
