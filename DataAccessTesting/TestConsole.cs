using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataAccessTesting
{
    public class TestConsole
    {
        static void Main(string[] args)
        {
            // using (DataAccessLayer.ContextDAL ctx = new DataAccessLayer.ContextDAL())
            using (BusinessLayer.BLLContext ctx = new BusinessLayer.BLLContext())
            {

                // Define the connection string for using (DataAccessLayer...Context
                // ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["CharStubsConnection"];
                // ctx.ConnectionString = cs.ConnectionString;

                #region Select By ID Test BLL
                //// Get an Author object by AuthorID
                //AuthorBO r = ctx.GetAuthor(1);
                //Console.WriteLine($"{r.AuthorID} {r.Name}");
                //Console.ReadLine();

                //// Get a Book object by BookID
                //BookBO r = ctx.GetBook(1);
                //Console.WriteLine($"{r.BookID} {r.Title} {r.SeriesID_FK}");
                //Console.ReadLine();

                //// Get a Character object by CharacterID
                //CharacterBO r = ctx.GetCharacter(1);
                //Console.WriteLine($"{r.CharacterID} {r.Name} {r.Class} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r. Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK}");
                //Console.ReadLine();

                //// Get a Class object by ClassID
                //ClassBO r = ctx.GetClass(1);
                //Console.WriteLine($"{r.ClassID} {r.ClassName} {r.ClassDiceValue}");
                //Console.ReadLine();

                //// Get a Class object by ClassName
                //ClassBO r = ctx.GetClassByClassName("bard");  
                //if (r != null)
                //{
                //    Console.WriteLine($"{r.ClassID} {r.ClassName} {r.ClassDiceValue}");
                //    Console.ReadLine(); 
                //}

                //// Get a Suggested Character object by SuggestedCharacterID
                //SuggestedCharacterBO r = ctx.GetSuggested(1);
                //Console.WriteLine($"{r.SuggestedCharacterID} {r.SuggestedCharacterName} {r.SuggestedCharacterSeries}");
                //Console.ReadLine();

                //// Get a Role object by RoleID
                //RoleBO r = ctx.GetRoleByID(1);
                //Console.WriteLine($"{r.RoleID} {r.Role}");
                //Console.ReadLine();

                //// Get a User object by UserID
                //UserBO r = ctx.GetUser(2);
                //Console.WriteLine($"{r.UserID} {r.FirstName} {r.LastName} {r.UserName} {r.Password} {r.EmailAddress} {r.RoleID_FK}");
                //Console.ReadLine();

                //// get a User Character object by UserCharacterID
                //UserCharacterBO r = ctx.GetUserCharacter(2);
                //Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");
                //Console.ReadLine();
                #endregion

                #region Select By Name BLL

                //// Get a Series object by SeriesTitle
                //SeriesBO r = ctx.GetSeriesBySeriesTitle("The Chronicles of Thomas Covenant");
                //if (r != null)
                //{
                //    Console.WriteLine($"{r.SeriesID} {r.SeriesTitle} {r.AuthorID_FK}");
                //    Console.ReadLine();
                //}

                // Get an Author object by Name
                AuthorBO r = ctx.GetAuthorByName("Robert Jordan");
                if (r != null)
                {
                    Console.WriteLine($"{r.AuthorID} {r.Name}");
                    Console.ReadLine();
                }

                #endregion

                #region Select "All" By BLL

                //// Get a list of all UserCharacter Objects by UserName BLL
                //foreach (UserCharacterBO r in ctx.GetAllUserCharactersByUserName("parkerjerry"))
                //{
                //    Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");
                //}
                //Console.ReadLine();

                //// Get a list of all UserCharacter Objects by UserName DAL
                //foreach (UserCharacterBO r in ctx.GetAllUserCharactersByUserID(26))
                //{
                //    Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");
                //}
                //Console.ReadLine();

                #endregion

                #region Select All

                //// Get a list of all UserCharacter Objects
                //foreach (BusinessLayer.UserCharacterBO r in ctx.GetAllUserCharacters())
                //{
                //    Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");
                //}
                //Console.ReadLine();


                #endregion

                #region Create Test BLL


                //// Create a new Wheel of Time Book
                //Console.WriteLine("Enter a Wheel of Time book Title");
                //string title = Console.ReadLine();
                //BookBO rv = ctx.NewBook(title, 1);
                //Console.WriteLine($"{rv.BookID} {rv.Title} {rv.SeriesID_FK}");
                //Console.ReadLine();

                //// Create a new Character entry 
                //Console.WriteLine("Enter a Description");
                //string description = Console.ReadLine();
                //string n = "Reinhold";
                //string c = "Fighter";
                //ctx.NewCharacter(n, c, 17, 15, 14, 15, 14, 15, 14, description, 1, 1);

                //// Create a new Class
                //ClassBO rv = ctx.NewClass("Ranger", 8);
                //Console.WriteLine($"{rv.ClassID} {rv.ClassName} {rv.ClassDiceValue}");
                //Console.ReadLine();

                //// Create a new Series
                //// SeriesBO rv = ctx.NewSeries("Ranger", 8);
                //Console.WriteLine($"{rv.SeriesID} {rv.SeriesTitle} {rv.AuthorID_FK}");
                //Console.ReadLine();

                //// Create a new User
                //UserBO rv = ctx.NewUser("Mark", "Anthony", "markanthony", "hellomark", "mark@yahoo.com", 1);
                //Console.WriteLine($"{rv.FirstName} {rv.LastName} {rv.UserName} {rv.Password} {rv.EmailAddress} {rv.RoleID_FK}");
                //Console.ReadLine();

                //// Create a new UserCharacter entry 
                //Console.WriteLine("Enter a Description");
                //string description = Console.ReadLine();
                //string n = "Reinhold";
                //string c = "Fighter";
                //ctx.NewUserCharacter(n, c, 11, 110,17, 15, 14, 15, 14, 15, 14, description, 1, 1, 9);



                #endregion

                #region Create Methods Test code
                //// Create a new UserCharacter entry and retrieve the newly created ID
                //Console.WriteLine("Enter a Description");
                //string description = Console.ReadLine();
                //string n = "Timmy";
                //string c = "Fighter";
                //int x = ctx.AddUserCharacter(n, c,8,80,17, 15, 14, 15, 14, 15, 14, description, 1, 1,9);
                //Console.WriteLine(x);
                //Console.ReadLine();


                //// Create a new Character entry and retrieve the newly created ID
                //Console.WriteLine("Enter a Description");
                //string description = Console.ReadLine();
                //string n = "Reinhold";
                //string c = "Fighter";
                //int x = ctx.AddCharacter(n, c, 17, 15, 14, 15, 14, 15, 14, description, 1, 1);
                //Console.WriteLine(x);
                //Console.ReadLine();

                //// Create a new Wheel of Time Book
                //Console.WriteLine("Enter a Wheel of Time book Title");
                //string title = Console.ReadLine();
                //int rv = ctx.AddBook(title, 1);
                //Console.WriteLine(rv);
                //Console.ReadLine();

                //// Create a new Class
                //Console.WriteLine("Enter a new Class");
                //string className = Console.ReadLine();
                //int rv = ctx.AddClass(className, 8);
                //Console.WriteLine(rv);
                //Console.ReadLine();


                //// Create a new Series authored by Terry Brooks
                //Console.WriteLine("Enter a new Series Title");
                //string seriesTitle = Console.ReadLine();
                //int rv = ctx.AddSeries(seriesTitle, 3);
                //Console.WriteLine(rv);
                //Console.ReadLine();

                //// Create a new Suggested Character
                //Console.WriteLine("Enter a new Character Name");
                //string charName = Console.ReadLine();
                //Console.WriteLine("Enter the series the character appears in");
                //string seriesTitle = Console.ReadLine();
                //int rv = ctx.AddSuggestedCharacter(charName, seriesTitle);
                //Console.WriteLine(rv);
                //Console.ReadLine();

                //// Create a new User
                //Console.WriteLine("Enter your First Name");
                //string firstName = Console.ReadLine();
                //Console.WriteLine("Enter your Last Name");
                //string lastName = Console.ReadLine();
                //Console.WriteLine("Enter a username");
                //string userName = Console.ReadLine();
                //Console.WriteLine("Enter a password");
                //string password = Console.ReadLine();
                //Console.WriteLine("Enter your email address");
                //string emailAddress = Console.ReadLine();
                //int rv = ctx.AddUser(firstName, lastName, userName, password, emailAddress, 1);
                //Console.WriteLine(rv);
                //Console.ReadLine();

                //ctx.AddAuthor(_name);
                #endregion

                #region Select Methods Test code

                //// Get a list of all Author objects
                //foreach (DataAccessLayer.AuthorDO r in ctx.GetAuthorDOs())
                //{
                //    Console.WriteLine($"{r.AuthorID} {r.Name} ");
                //}



                //// Get a list of all Character Objects
                //foreach (DataAccessLayer.CharacterDO r in ctx.GetCharacterDOs())
                //{
                //    Console.WriteLine($"{r.CharacterID} {r.Name} {r.Class} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK}");
                //}



                //// Get a list of all UserCharacter Objects
                //foreach (DataAccessLayer.UserCharacterDO r in ctx.GetUserCharacterDOs())
                //{
                //    Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");
                //}
                //Console.ReadLine();




                //// Get a list of all UserCharacter Objects by UserID
                //foreach (DataAccessLayer.UserCharacterDO r in ctx.GetUserCharacterDOsByUserID(9))
                //{
                //    Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");
                //}
                //Console.ReadLine();

                //// Get a list of all UserCharacter Objects by UserName DAL
                //foreach (DataAccessLayer.UserCharacterDO r in ctx.GetUserCharacterDOsByUserName("jerryparker"))
                //{
                //    Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");
                //}
                //Console.ReadLine();



                //// Get a UserCharacter object by UserCharacterID
                //DataAccessLayer.UserCharacterDO r = ctx.GetUserCharacterDOByID(19);
                //    Console.WriteLine($"{r.UserCharacterID} {r.Name} {r.Class} {r.ClassLevel} {r.HitPoints} {r.AC} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK} {r.UserID_FK}");

                //Console.ReadLine();



                //// Get a list of all Book objects
                //foreach (DataAccessLayer.BookDO r in ctx.GetBookDOs())
                //{
                //    Console.WriteLine($"{r.BookID} {r.Title} {r.SeriesID_FK}");
                //}
                //Console.ReadLine();



                //// Get a Book object by BookID
                //DataAccessLayer.BookDO r = ctx.GetBookDOByID(3);                 
                //Console.WriteLine($"{r.BookID} {r.Title} {r.SeriesID_FK}");
                //Console.ReadLine();



                //// Get a list of all Book objects by SeriesID
                //foreach (DataAccessLayer.BookDO r in ctx.GetBookDOsBySeriesID(3))
                //{
                //    Console.WriteLine($"{r.BookID} {r.Title} {r.SeriesID_FK}");
                //}
                //Console.ReadLine();



                //// Get a list of all Class objects
                //foreach (DataAccessLayer.ClassDO r in ctx.GetClassDOs())
                //{
                //    Console.WriteLine($"{r.ClassID} {r.ClassName} {r.ClassDiceValue}");
                //}
                //Console.ReadLine();



                //// Get a list of all Series objects
                //foreach (DataAccessLayer.SeriesDO r in ctx.GetSeriesDOs())
                //{
                //    Console.WriteLine($"{r.SeriesID} {r.SeriesTitle} {r.AuthorID_FK }");
                //}
                //Console.ReadLine();



                //// Get a list of all SuggestedCharacter objects
                //foreach (DataAccessLayer.SuggestedCharacterDO r in ctx.GetSuggestedCharacterDOs())
                //{
                //    Console.WriteLine($"{r.SuggestedCharacterID} {r.SuggestedCharacterName} {r.SuggestedCharacterSeries }");
                //}
                //Console.ReadLine();



                //// Get a list of all User objects
                //foreach (DataAccessLayer.UserDO r in ctx.GetUserDOs())
                //{
                //    Console.WriteLine($"{r.UserID} {r.FirstName} {r.LastName } {r.UserName} {r.Password} {r.EmailAddress} {r.RoleID_FK}");
                //}
                //Console.ReadLine();



                //// Get a list of all User objects
                //DataAccessLayer.UserDO r = ctx.GetUserDOByID(2);

                //Console.WriteLine($"{r.UserID} {r.FirstName} {r.LastName } {r.UserName} {r.Password} {r.EmailAddress} {r.RoleID_FK}");

                //Console.ReadLine();

                //// Get a User object by username
                //DataAccessLayer.UserDO r = ctx.GetUserDOByUsername("jerryparker");

                //if (r != null)
                //{
                //    Console.WriteLine($"{r.UserID} {r.FirstName} {r.LastName } {r.UserName} {r.Password} {r.EmailAddress} {r.RoleID_FK}"); 
                //}
                //else
                //{
                //    Console.WriteLine("Username entered doesn't exist in the database");
                //}
                //Console.ReadLine();

                //// Get a Class object by ClassName
                //DataAccessLayer.ClassDO r = ctx.GetClassDOByClassName("Sorcerer");

                //if (r != null)
                //{
                //    Console.WriteLine($"{r.ClassID} {r.ClassName} {r.ClassDiceValue }");
                //}
                //else
                //{
                //    Console.WriteLine("Class name entered doesn't exist in the database");
                //}
                //Console.ReadLine();




                //// Get a Series object by SeriesID
                //DataAccessLayer.SeriesDO r = ctx.GetSeriesDOByID(6);

                //Console.WriteLine($"{r.SeriesID} {r.SeriesTitle} {r.AuthorID_FK }");

                //Console.ReadLine();



                //// Get a Character object by CharacterID
                //DataAccessLayer.CharacterDO r = ctx.GetCharacterDOByID(2);

                //Console.WriteLine($"{r.CharacterID} {r.Name} {r.Class} {r.Strength} {r.Dexterity} {r.Constitution} {r.Intelligence} {r.Wisdom} {r.Charisma} {r.Description} {r.SeriesID_FK} {r.ClassID_FK}");

                //Console.ReadLine();



                //// Get an Author object by AuthorID
                //DataAccessLayer.AuthorDO r = ctx.GetAuthorDOByID(1);

                //Console.WriteLine($"{r.AuthorID} {r.Name}");

                //Console.ReadLine();


                //// Get an Author object by AuthorID
                //DataAccessLayer.ClassDO r = ctx.GetClassDOByID(2);

                //Console.WriteLine($"{r.ClassID} {r.ClassName} {r.ClassDiceValue}");

                //Console.ReadLine();

                #endregion

                #region Delete Methods Test Code
                // ctx.DeleteCharacter(12);



                #endregion

                #region Update Methods Test Code

                // ctx.UpdateAuthor(1, "Robert Rockstar Jordan");

                // ctx.UpdateBook(1, "The Eye of the World", 1);

                // ctx.UpdateCharacter(12,"Tammy", "Fighter", 21, 10, 14, 15, 14, 15, 10, "Test", 1, 1);

                // ctx.UpdateClass(5, "Druid", 8);

                // ctx.UpdateSeries(1, "The Wheel of Time", 1);

                // ctx.UpdateUser(10, "Matt", "Mercer", "matty", "himatt", "matt@yahoo.com", 1);

                // ctx.UpdateUserCharacter(19, "Tammy", "Fighter",10,100,18, 10, 14, 15, 14, 15, 10, "Check", 1, 1, 8);

                #endregion
            }
        }
    }
}
