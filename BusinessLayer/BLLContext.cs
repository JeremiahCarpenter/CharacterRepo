using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BLLContext : IDisposable
    {
        private ContextDAL dataContext = new ContextDAL();

        public BLLContext()
        {
            ConnectionStringSettings connstring = ConfigurationManager.ConnectionStrings["CharStubsConnection"];
            if (connstring == null)
            {
                throw new Exception("The Business Logic Layer expects a ConnectionString entry in your config file");
            }

            dataContext.ConnectionString = connstring.ConnectionString;
        }

        #region Simple Dispose

        public void Dispose()
        {
            dataContext.Dispose();
        }

        #endregion


        #region  Author

        public AuthorBO GetAuthor(int _authorID)
        {
            // Instaniate a new Data Layer object using a Data Layer method 
            AuthorDO retval = dataContext.GetAuthorDOByID(_authorID);
            if (retval == null) return null;
            return new AuthorBO(retval);
        }

        public AuthorBO GetAuthorByName(string _name)
        {
            // Instaniate a new Data Layer object using a Data Layer method 
            AuthorDO retval = dataContext.GetAuthorDOByName(_name);
            if (retval == null) return null;
            return new AuthorBO(retval);
        }

        public List<AuthorBO> GetAllAuthors()
        {
            List<AuthorBO> rv = new List<AuthorBO>();
            List<AuthorDO> list = dataContext.GetAuthorDOs();
            foreach (AuthorDO item in list)
            {
                rv.Add(new AuthorBO(item));
            }
            return rv;
        }

        public AuthorBO NewAuthor(string _name)
        {
            // Get the ID returned from the new entry
            int _authorID = dataContext.AddAuthor(_name);

            // Create a new Business Layer Object and define it
            AuthorBO rval = new AuthorBO();
            rval.AuthorID = _authorID;
            rval.Name = _name;

            // Return the new object
            return rval;
        }

        //public void NewAuthor(string _name)
        //{
        //    dataContext.AddAuthor(_name);
        //}

        public void UpdateAuthor(int _authorID, string _name)
        {
            dataContext.UpdateAuthor(_authorID, _name);
        }

        public void UpdateAuthor(AuthorBO author)
        {
            dataContext.UpdateAuthor(author.AuthorID, author.Name);
        }

        public void DeleteAuthor(int authorID)
        {
            dataContext.DeleteAuthor(authorID);
        }

        public void DeleteAuthor(AuthorBO author)
        {
            DeleteAuthor(author.AuthorID);
        }

        #endregion

        #region Book
        public BookBO GetBook(int _bookID)
        {
            BookDO retval = dataContext.GetBookDOByID(_bookID);
            if (retval == null) return null;
            return new BookBO(retval);
        }

        public BookBO GetBookByTitle(string _title)
        {
            BookDO retval = dataContext.GetBookDOByTitle(_title);
            if (retval == null) return null;
            return new BookBO(retval);
        }

        public List<BookBO> GetAllBooks()
        {
            List<BookBO> rv = new List<BookBO>();
            List<BookDO> list = dataContext.GetBookDOs();
            foreach (BookDO item in list)
            {
                rv.Add(new BookBO(item));
            }
            return rv;
        }

        public BookBO NewBook(string _title, int _seriesID_FK)
        {
            int _bookID = dataContext.AddBook(_title, _seriesID_FK);
            BookBO rval = new BookBO();
            rval.BookID = _bookID;
            rval.Title = _title;
            rval.SeriesID_FK = _seriesID_FK;
            return rval;
        }

        //public void NewBook(string _title, int _seriesID_FK)
        //{
        //    dataContext.AddBook( _title,  _seriesID_FK);
        //}

        public void UpdateBook(int _bookID, string _title, int _seriesID_FK)
        {
            dataContext.UpdateBook(_bookID, _title, _seriesID_FK);
        }

        public void UpdateBook(BookBO book)
        {
            dataContext.UpdateBook(book.BookID, book.Title, book.SeriesID_FK);
        }

        public void DeleteBook(int bookID)
        {
            dataContext.DeleteBook(bookID);
        }

        public void DeleteBook(BookBO book)
        {
            DeleteBook(book.BookID);
        }

        #endregion

        #region Character
        public CharacterBO GetCharacter(int _characterID)
        {
            CharacterDO retval = dataContext.GetCharacterDOByID(_characterID);
            if (retval == null) return null;
            return new CharacterBO(retval);
        }

        public List<CharacterBO> GetAllCharacters()
        {
            List<CharacterBO> rv = new List<CharacterBO>();
            List<CharacterDO> list = dataContext.GetCharacterDOs();
            foreach (CharacterDO item in list)
            {
                rv.Add(new CharacterBO(item));
            }
            return rv;
        }

        public CharacterBO NewCharacter(string _name, string _class, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid)
        {
            int _characterID = dataContext.AddCharacter(_name, _class, _ac, _str, _dex, _con, _intel, _wis, _char, _desc, _Sid);
            CharacterBO rval = new CharacterBO();
            rval.CharacterID = _characterID;
            rval.Name = _name;
            rval.Class = _class;
            rval.AC = _ac;
            rval.Strength = _str;
            rval.Dexterity = _dex;
            rval.Constitution = _con;
            rval.Intelligence = _intel;
            rval.Wisdom = _wis;
            rval.Charisma = _char;
            rval.Description = _desc;
            rval.SeriesID_FK = _Sid;            
            return rval;
        }
        //public void NewCharacter(string _name, string _class, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid)
        //{
        //    dataContext.AddCharacter( _name,  _class,  _ac,  _str,  _dex,  _con,  _intel,  _wis,  _char,  _desc,  _Sid);
        //}
        public void NewCharacter(CharacterBO character)
        {
            dataContext.AddCharacter(character.Name, character.Class, character.AC, character.Strength, character.Dexterity, character.Constitution, character.Intelligence, character.Wisdom, character.Charisma, character.Description, character.SeriesID_FK);
        }


        public void UpdateCharacter(int _characterID, string _name, string _class, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid, int _Cid)
        {
            dataContext.UpdateCharacter(_characterID, _name, _class, _ac, _str, _dex, _con, _intel, _wis, _char, _desc, _Sid);
        }

        public void UpdateCharacter(CharacterBO character)
        {
            dataContext.UpdateCharacter(character.CharacterID, character.Name, character.Class, character.AC, character.Strength, character.Dexterity, character.Constitution, character.Intelligence, character.Wisdom, character.Charisma, character.Description, character.SeriesID_FK);
        }

        public void DeleteCharacter(int characterID)
        {
            dataContext.DeleteCharacter(characterID);
        }

        public void DeleteCharacter(CharacterBO character)
        {
            DeleteCharacter(character.CharacterID);
        }

        #endregion

        #region Class

        public ClassBO GetClass(int _classID)
        {
            ClassDO retval = dataContext.GetClassDOByID(_classID);
            if (retval == null) return null;
            return new ClassBO(retval);
        }

        public ClassBO GetClassByClassName(string _className)
        {
            ClassDO retval = dataContext.GetClassDOByClassName(_className);
            if (retval == null) return null;
            return new ClassBO(retval);
        }

        public List<ClassBO> GetAllClasses()
        {
            List<ClassBO> rv = new List<ClassBO>();
            List<ClassDO> list = dataContext.GetClassDOs();
            foreach (ClassDO item in list)
            {
                rv.Add(new ClassBO(item));
            }
            return rv;
        }

        public ClassBO NewClass(string _className, int _classDiceValue)
        {
            int _classID = dataContext.AddClass(_className, _classDiceValue);
            ClassBO rval = new ClassBO();
            rval.ClassID = _classID;
            rval.ClassName = _className;
            rval.ClassDiceValue = _classDiceValue;
            return rval;
        }

        //public void NewClass(string _className, int _classDiceValue)
        //{
        //    dataContext.AddClass( _className,  _classDiceValue);
        //}

        public void UpdateClass(int _classID, string _className, int _classDiceValue)
        {
            dataContext.UpdateClass(_classID, _className, _classDiceValue);
        }

        public void UpdateClass(ClassBO _class)
        {
            dataContext.UpdateClass(_class.ClassID, _class.ClassName, _class.ClassDiceValue);
        }

        public void DeleteClass(int classID)
        {
            dataContext.DeleteClass(classID);
        }

        public void DeleteClass(ClassBO _class)
        {
            DeleteClass(_class.ClassID);
        }

        #endregion

        #region Role

        public List<RoleBO> GetAllRoles()
        {
            List<RoleBO> rv = new List<RoleBO>();
            List<RoleDO> list = dataContext.GetRoleDOs();
            foreach (RoleDO item in list)
            {
                rv.Add(new RoleBO(item));
            }
            return rv;
        }

        public RoleBO GetRoleByID(int _roleID)
        {
            // Instaniate a new Data Layer object using a Data Layer method 
            RoleDO retval = dataContext.GetRoleDOByID(_roleID);
            if (retval == null) return null;
            return new RoleBO(retval);
        }
        #endregion

        #region Series

        public SeriesBO GetSeries(int _seriesID)
        {
            SeriesDO retval = dataContext.GetSeriesDOByID(_seriesID);
            if (retval == null) return null;
            return new SeriesBO(retval);
        }

        public SeriesBO GetSeriesBySeriesTitle(string _seriesTitle)
        {
            SeriesDO retval = dataContext.GetSeriesDOBySeriesTitle(_seriesTitle);
            if (retval == null) return null;
            return new SeriesBO(retval);
        }

        public List<SeriesBO> GetAllSeries()
        {
            List<SeriesBO> rv = new List<SeriesBO>();
            List<SeriesDO> list = dataContext.GetSeriesDOs();
            foreach (SeriesDO item in list)
            {
                rv.Add(new SeriesBO(item));
            }
            return rv;
        }

        public SeriesBO NewSeries(string _seriesTitle, int _authorID_FK)
        {
            int _seriesID = dataContext.AddSeries(_seriesTitle, _authorID_FK);
            SeriesBO rval = new SeriesBO();
            rval.SeriesID = _seriesID;
            rval.SeriesTitle = _seriesTitle;
            rval.AuthorID_FK = _authorID_FK;
            return rval;
        }

        //public void NewSeries(string _seriesTitle, int _authorID_FK)
        //{
        //    dataContext.AddSeries( _seriesTitle,  _authorID_FK);
        //}

        public void UpdateSeries(int _seriesID, string _seriesTitle, int _authorID_FK)
        {
            dataContext.UpdateSeries(_seriesID, _seriesTitle, _authorID_FK);
        }

        public void UpdateSeries(SeriesBO series)
        {
            dataContext.UpdateSeries(series.SeriesID, series.SeriesTitle, series.AuthorID_FK);
        }

        public void DeleteSeries(int seriesID)
        {
            dataContext.DeleteSeries(seriesID);
        }

        public void DeleteSeries(SeriesBO series)
        {
            DeleteSeries(series.SeriesID);
        }

        #endregion

        #region Suggested Character

        public SuggestedCharacterBO GetSuggestedCharacter(int _suggestedID)
        {
            SuggestedCharacterDO retval = dataContext.GetSuggestedCharacterDOByID(_suggestedID);
            if (retval == null) return null;
            return new SuggestedCharacterBO(retval);
        }

        public List<SuggestedCharacterBO> GetAllSuggestedCharacters()
        {
            List<SuggestedCharacterBO> rv = new List<SuggestedCharacterBO>();
            List<SuggestedCharacterDO> list = dataContext.GetSuggestedCharacterDOs();
            foreach (SuggestedCharacterDO item in list)
            {
                rv.Add(new SuggestedCharacterBO(item));
            }
            return rv;
        }

        public SuggestedCharacterBO NewSuggestedCharacter(string _suggestedCharacterName, string _suggestedCharacterSeries)
        {
            int _suggestCharID = dataContext.AddSuggestedCharacter(_suggestedCharacterName, _suggestedCharacterSeries);
            SuggestedCharacterBO rval = new SuggestedCharacterBO();
            rval.SuggestedCharacterID = _suggestCharID;
            rval.SuggestedCharacterName = _suggestedCharacterName;
            rval.SuggestedCharacterSeries = _suggestedCharacterSeries;
            return rval;
        }

        //public void NewSuggestedCharacter(string _suggestedCharacterName, string _suggestedCharacterSeries)
        //{
        //    dataContext.AddSuggestedCharacter( _suggestedCharacterName,  _suggestedCharacterSeries);
        //}

        public void DeleteSuggestedCharacter(int sugCharID)
        {
            dataContext.DeleteSuggestedCharacter(sugCharID);
        }

        public void DeleteSuggestedCharacter(SuggestedCharacterBO sugChar)
        {
            DeleteSuggestedCharacter(sugChar.SuggestedCharacterID);
        }

        #endregion

        #region User

        public UserBO GetUserByID(int _userID)
        {
            UserDO retval = dataContext.GetUserDOByID(_userID);
            if (retval == null) return null;
            return new UserBO(retval);
        }

        public UserBO GetUserByUsername(string username)
        {
            UserDO retval = dataContext.GetUserDOByUsername(username);
            if (retval == null) return null;
            return new UserBO(retval);
        }

        public List<UserBO> GetAllUsers()
        {
            List<UserBO> rv = new List<UserBO>();
            List<UserDO> list = dataContext.GetUserDOs();
            foreach (UserDO item in list)
            {
                rv.Add(new UserBO(item));
            }
            return rv;
        }
        //public UserBO NewUser(string _firstName, string _lastName, string _userName, string _password, string _emailAddress, int _roleID_FK)
        //{
        //    int _userID = dataContext.AddUser(_firstName, _lastName, _userName, _password, _emailAddress, _roleID_FK);
        //    UserBO rval = new UserBO();
        //    rval.UserID = _userID;
        //    rval.FirstName = _firstName;
        //    rval.LastName = _lastName;
        //    rval.UserName = _userName;
        //    rval.Password = _password;
        //    rval.EmailAddress = _emailAddress;
        //    rval.RoleID_FK = _roleID_FK;
        //    return rval;
        //}

        public void NewUser(string _firstName, string _lastName, string _userName, string _password, string _emailAddress, int _roleID_FK)
        {
            dataContext.AddUser(_firstName, _lastName, _userName, _password, _emailAddress, _roleID_FK);
        }

        public void NewUser(UserBO userbo)
        {            
            NewUser(userbo.FirstName, userbo.LastName, userbo.UserName, userbo.Password, userbo.EmailAddress, userbo.RoleID_FK);
        }

        public void UpdateUser(int _userID, string _firstName, string _lastName, string _userName, string _password, string _emailAddress, int _roleID_FK)
        {
            dataContext.UpdateUser(_userID, _firstName, _lastName, _userName, _password, _emailAddress, _roleID_FK);
        }

        public void UpdateUser(UserBO user)
        {            
            UpdateUser(user.UserID, user.FirstName, user.LastName, user.UserName, user.Password, user.EmailAddress, user.RoleID_FK);
        }

        public void DeleteUser(int userID)
        {
            dataContext.DeleteUser(userID);
        }

        public void DeleteUser(UserBO user)
        {
            DeleteUser(user.UserID);
        }

        #endregion

        #region User Character

        public UserCharacterBO GetUserCharacter(int _userCharacterID)
        {            
            UserCharacterDO retval = dataContext.GetUserCharacterDOByID(_userCharacterID);
            if (retval == null) return null;
            return new UserCharacterBO(retval);
        }

        public List<UserCharacterBO> GetAllUserCharacters()
        {
            List<UserCharacterBO> rv = new List<UserCharacterBO>();
            List<UserCharacterDO> list = dataContext.GetUserCharacterDOs();
            foreach (UserCharacterDO item in list)
            {
                rv.Add(new UserCharacterBO(item));
            }
            return rv;
        }

        public List<UserCharacterBO> GetAllUserCharactersByUserName(string username)
        {
            List<UserCharacterBO> rv = new List<UserCharacterBO>();
            List<UserCharacterDO> list = dataContext.GetUserCharacterDOsByUserName(username);
            foreach (UserCharacterDO item in list)
            {
                rv.Add(new UserCharacterBO(item));
            }
            return rv;
        }

        public List<UserCharacterBO> GetAllUserCharactersByUserID(int UserID)
        {
            List<UserCharacterBO> rv = new List<UserCharacterBO>();
            List<UserCharacterDO> list = dataContext.GetUserCharacterDOsByUserID(UserID);
            foreach (UserCharacterDO item in list)
            {
                rv.Add(new UserCharacterBO(item));
            }
            return rv;
        }

        public int NewUserCharacter( CharacterTransition character,  int userID)
        {
            // Get data from the class of the character to use in calculations
            ClassDO _class = dataContext.GetClassDOByClassName(character.Class);

            // Calculate hit points for the new personal character
            int hp = (character.ClassLevel * _class.ClassDiceValue);

            // Adjust the stats for the new personal character based on character level
            int StatMod(int stat)
            {
                if (character.ClassLevel >= 15)
                {
                    stat = stat + 2;
                    if (stat <= 25)
                    {
                        return stat; 
                    }
                    return 25;
                }
                else if (character.ClassLevel >= 10)
                {
                    stat = stat + 1;
                    if (stat <= 25)
                    {
                        return stat; 
                    }
                    return 25;
                }
                return stat;
            }

            // Add the new personal character to the database and retrieve the id in order to display the new character
            var rv = dataContext.AddUserCharacter(character.Name, character.Class, character.ClassLevel, hp, character.AC, StatMod(character.Strength), StatMod(character.Dexterity), StatMod(character.Constitution), StatMod(character.Intelligence), StatMod(character.Wisdom), StatMod(character.Charisma), character.Description, character.SeriesID_FK, userID);

            return rv;
        }

        public UserCharacterBO NewUserCharacter(string _name, string _class, int _classLvl, int _hp, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid, int _Uid)
        {
            int _characterID = dataContext.AddUserCharacter(_name, _class, _classLvl, _hp, _ac, _str, _dex, _con, _intel, _wis, _char, _desc, _Sid, _Uid);
            UserCharacterBO rval = new UserCharacterBO();
            rval.UserCharacterID = _characterID;
            rval.Name = _name;
            rval.Class = _class;
            rval.ClassLevel = _classLvl;
            rval.HitPoints = _hp;
            rval.AC = _ac;
            rval.Strength = _str;
            rval.Dexterity = _dex;
            rval.Constitution = _con;
            rval.Intelligence = _intel;
            rval.Wisdom = _wis;
            rval.Charisma = _char;
            rval.Description = _desc;
            rval.SeriesID_FK = _Sid;           
            rval.UserID_FK = _Uid;
            return rval;
        }

        //public void NewUserCharacter(string _name, string _class, int _classLvl, int _hp, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid, int _Uid)
        //{
        //    dataContext.AddUserCharacter( _name,  _class,  _classLvl,  _hp,  _ac,  _str,  _dex,  _con,  _intel,  _wis,  _char,  _desc,  _Sid,  _Uid);
        //}

        public void UpdateUserCharacter(int _userCharID, string _name, string _class, int _classLvl, int _hp, int _ac, int _str, int _dex, int _con, int _intel, int _wis, int _char, string _desc, int _Sid, int _Uid)
        {
            dataContext.UpdateUserCharacter(_userCharID, _name, _class, _classLvl, _hp, _ac, _str, _dex, _con, _intel, _wis, _char, _desc, _Sid, _Uid);
        }

        public void UpdateUserCharacter(UserCharacterBO uChar)
        {
            dataContext.UpdateUserCharacter(uChar.UserCharacterID, uChar.Name, uChar.Class, uChar.ClassLevel, uChar.HitPoints, uChar.AC, uChar.Strength, uChar.Dexterity, uChar.Constitution, uChar.Intelligence, uChar.Wisdom, uChar.Charisma, uChar.Description, uChar.SeriesID_FK, uChar.UserID_FK);
        }

        public void DeleteUserCharacter(int useCharID)
        {
            dataContext.DeleteUserCharacter(useCharID);
        }       

        public void DeleteUserCharacter(UserCharacterBO useChar)
        {
            DeleteUserCharacter(useChar.UserCharacterID);
        }

        public void DeleteUserCharacterByUserID(int userID)
        {
            dataContext.DeleteUserCharacter(userID);
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

        //        dataContext.Dispose();
        //        disposedValue = true;
        //    }
        //}

        //// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //~BLLContext()
        //{
        //    //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //    Dispose(false);
        //    throw new Exception("The BLLContext was not Disposed Properly. You should either use it within C# Using Construct, or call Dispose on the instance before it goes out of scope.");
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
