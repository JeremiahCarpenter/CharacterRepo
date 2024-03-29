USE [master]
GO
/****** Object:  Database [CharStubs]    Script Date: 5/7/2019 9:42:44 AM ******/
/*CREATE DATABASE [CharStubs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CharStubs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CharStubs.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CharStubs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\CharStubs_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
*/
ALTER DATABASE [CharStubs] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CharStubs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CharStubs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CharStubs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CharStubs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CharStubs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CharStubs] SET ARITHABORT OFF 
GO
ALTER DATABASE [CharStubs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CharStubs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CharStubs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CharStubs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CharStubs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CharStubs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CharStubs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CharStubs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CharStubs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CharStubs] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CharStubs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CharStubs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CharStubs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CharStubs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CharStubs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CharStubs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CharStubs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CharStubs] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CharStubs] SET  MULTI_USER 
GO
ALTER DATABASE [CharStubs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CharStubs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CharStubs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CharStubs] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CharStubs] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CharStubs]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[SeriesID_FK] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Character](
	[CharacterID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Class] [nvarchar](50) NOT NULL,
	[AC] [int] NOT NULL,
	[Strength] [int] NOT NULL,
	[Dexterity] [int] NOT NULL,
	[Constitution] [int] NOT NULL,
	[Intelligence] [int] NOT NULL,
	[Wisdom] [int] NOT NULL,
	[Charisma] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[SeriesID_FK] [int] NOT NULL,
 CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED 
(
	[CharacterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](50) NOT NULL,
	[ClassDiceValue] [int] NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTrace]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTrace](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](500) NULL,
	[Trace] [nvarchar](max) NULL,
	[TimeOfError] [datetime] NULL,
 CONSTRAINT [PK_LogTrace] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Series]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Series](
	[SeriesID] [int] IDENTITY(1,1) NOT NULL,
	[SeriesTitle] [nvarchar](50) NOT NULL,
	[AuthorID_FK] [int] NOT NULL,
 CONSTRAINT [PK_Series] PRIMARY KEY CLUSTERED 
(
	[SeriesID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuggestedCharacter]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuggestedCharacter](
	[SuggestedCharacterID] [int] IDENTITY(1,1) NOT NULL,
	[SuggestedCharacterName] [nvarchar](50) NOT NULL,
	[SuggestedCharacterSeries] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SuggestedCharacter] PRIMARY KEY CLUSTERED 
(
	[SuggestedCharacterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[EmailAddress] [nvarchar](50) NOT NULL,
	[RoleID_FK] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserCharacter]    Script Date: 5/7/2019 9:42:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCharacter](
	[UserCharacterID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Class] [nvarchar](50) NOT NULL,
	[ClassLevel] [int] NOT NULL,
	[HitPoints] [int] NOT NULL,
	[AC] [int] NOT NULL,
	[Strength] [int] NOT NULL,
	[Dexterity] [int] NOT NULL,
	[Constitution] [int] NOT NULL,
	[Intelligence] [int] NOT NULL,
	[Wisdom] [int] NOT NULL,
	[Charisma] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[SeriesID_FK] [int] NOT NULL,
	[UserID_FK] [int] NOT NULL,
 CONSTRAINT [PK_UserCharacter] PRIMARY KEY CLUSTERED 
(
	[UserCharacterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorID], [Name]) VALUES (1, N'Robert Jordan')
INSERT [dbo].[Author] ([AuthorID], [Name]) VALUES (2, N'Stephen R. Donaldson')
INSERT [dbo].[Author] ([AuthorID], [Name]) VALUES (3, N'Terry Brooks')
INSERT [dbo].[Author] ([AuthorID], [Name]) VALUES (4, N'Piers Anthony')
INSERT [dbo].[Author] ([AuthorID], [Name]) VALUES (5, N'Terry Prichard')
INSERT [dbo].[Author] ([AuthorID], [Name]) VALUES (10, N'Anne McCaffery')
INSERT [dbo].[Author] ([AuthorID], [Name]) VALUES (1008, N'Test Author')
SET IDENTITY_INSERT [dbo].[Author] OFF
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (1, N'The Eye of the World', 1)
INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (2, N'The Great Hunt', 1)
INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (3, N'The Dragon Reborn', 1)
INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (4, N'The Shadow Rising', 1)
INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (5, N'The Fires of Heaven', 1)
INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (7, N'The Sword of Shannara', 3)
INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (8, N'Lord of Chaos', 1)
INSERT [dbo].[Book] ([BookID], [Title], [SeriesID_FK]) VALUES (9, N'A Crown of Swords', 1)
SET IDENTITY_INSERT [dbo].[Book] OFF
SET IDENTITY_INSERT [dbo].[Character] ON 

INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (1, N'Rand al''Thor', N'Fighter', 17, 15, 14, 15, 14, 12, 15, N'The Dragon Reborn from the Wheel of Time series once upon a time in a land far away.
Rand was raised Tam al''Thor in a sleepy little town called Edmonds Field.  He was actually the son of a couple of adopted Aiel from the three fold land also known as the waste.  He is the reincarnation of Lewis Theron Tellamon and is therefore given the moniker the Dragon Reborn, since Lewis Theron was know as the Dragon.  He is a fighter in his build, but is also able to use "magic"  His special abilities include the ability to teleport anywhere once he has been in one place long enough.  He acts as magic user that is equivalent to 3/4 of his fighter level with his special teleport ablility only coming into play when his level reaches 11.
', 1)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (2, N'Perrin Aybara', N'Fighter', 18, 18, 13, 17, 14, 15, 16, N'A companion of the Dragon Reborn and a childhood friend', 1)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (3, N'Matrim Cauthon', N'Rogue', 17, 14, 17, 14, 15, 12, 17, N'A trickster and childhood friend of Rand al''Thor', 1)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (4, N'Bannor', N'Fighter', 19, 18, 17, 18, 15, 15, 14, N'A fomer member of the Bloodguard. One of the Haruchai people', 2)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (5, N'Hile Troy', N'Fighter', 16, 14, 14, 14, 17, 16, 16, N'Summoned from the real world to fight evil Lord Foul''s army', 2)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (6, N'Allanon', N'Wizard', 15, 13, 14, 17, 18, 16, 18, N'A member of a powerful brotherhood of Druids, the last of his kind', 3)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (7, N'Shea Ohmsford', N'Fighter', 15, 14, 16, 14, 14, 14, 15, N'An adopted son of the Ohmsford family. A half-Elf who is the last descendant of Jerle Shannara and the only one alive who is capable of wielding the Sword of Shannara', 3)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (8, N'Flick Ohmsford', N'Fighter', 15, 14, 15, 14, 14, 15, 13, N'Shea Ohmsford''s adopted brother and companion', 3)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (9, N'Stile', N'Wizard', 15, 14, 18, 14, 17, 14, 15, N'A wizard from a world split by a magic curtain into a science domain and a magic domain. He must sing his spells', 4)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (10, N'Nynaeve al''Meara', N'Cleric', 14, 13, 15, 17, 15, 14, 12, N'An Aes Sedai of the Yellow Ajah', 1)
INSERT [dbo].[Character] ([CharacterID], [Name], [Class], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK]) VALUES (24, N'Test Character', N'Rogue', 18, 16, 16, 16, 16, 16, 16, N'This is a test character that I''ve created in order to show how creating a character will go', 4)
SET IDENTITY_INSERT [dbo].[Character] OFF
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([ClassID], [ClassName], [ClassDiceValue]) VALUES (1, N'Fighter', 10)
INSERT [dbo].[Class] ([ClassID], [ClassName], [ClassDiceValue]) VALUES (2, N'Wizard', 6)
INSERT [dbo].[Class] ([ClassID], [ClassName], [ClassDiceValue]) VALUES (3, N'Cleric', 6)
INSERT [dbo].[Class] ([ClassID], [ClassName], [ClassDiceValue]) VALUES (4, N'Rogue', 8)
INSERT [dbo].[Class] ([ClassID], [ClassName], [ClassDiceValue]) VALUES (5, N'Druid', 8)
INSERT [dbo].[Class] ([ClassID], [ClassName], [ClassDiceValue]) VALUES (6, N'Ranger', 8)
SET IDENTITY_INSERT [dbo].[Class] OFF
SET IDENTITY_INSERT [dbo].[LogTrace] ON 

INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (1, N'The controller for path ''/role'' was not found or does not implement IController.', N'   at System.Web.Mvc.DefaultControllerFactory.GetControllerInstance(RequestContext requestContext, Type controllerType)
   at System.Web.Mvc.DefaultControllerFactory.CreateController(RequestContext requestContext, String controllerName)
   at System.Web.Mvc.MvcHandler.ProcessRequestInit(HttpContextBase httpContext, IController& controller, IControllerFactory& factory)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContext httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', CAST(N'2019-05-02T15:03:17.703' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (2, N'The controller for path ''/role/'' was not found or does not implement IController.', N'   at System.Web.Mvc.DefaultControllerFactory.GetControllerInstance(RequestContext requestContext, Type controllerType)
   at System.Web.Mvc.DefaultControllerFactory.CreateController(RequestContext requestContext, String controllerName)
   at System.Web.Mvc.MvcHandler.ProcessRequestInit(HttpContextBase httpContext, IController& controller, IControllerFactory& factory)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContext httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', CAST(N'2019-05-02T15:41:30.260' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (3, N'The controller for path ''/role'' was not found or does not implement IController.', N'   at System.Web.Mvc.DefaultControllerFactory.GetControllerInstance(RequestContext requestContext, Type controllerType)
   at System.Web.Mvc.DefaultControllerFactory.CreateController(RequestContext requestContext, String controllerName)
   at System.Web.Mvc.MvcHandler.ProcessRequestInit(HttpContextBase httpContext, IController& controller, IControllerFactory& factory)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContext httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', CAST(N'2019-05-02T15:46:29.063' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (4, N'The parameters dictionary contains a null entry for parameter ''id'' of non-nullable type ''System.Int32'' for method ''System.Web.Mvc.ActionResult Edit(Int32)'' in ''CharacterRepo.Controllers.BookController''. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters', N'   at System.Web.Mvc.ActionDescriptor.ExtractParameterFromDictionary(ParameterInfo parameterInfo, IDictionary`2 parameters, MethodInfo methodInfo)
   at System.Web.Mvc.ReflectedActionDescriptor.Execute(ControllerContext controllerContext, IDictionary`2 parameters)
   at System.Web.Mvc.ControllerActionInvoker.InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary`2 parameters)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c.<BeginInvokeSynchronousActionMethod>b__9_0(IAsyncResult asyncResult, ActionInvocation innerInvokeState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`2.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethod(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<InvokeActionMethodFilterAsynchronouslyRecursive>b__11_0()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.AsyncInvocationWithFilters.<>c__DisplayClass11_1.<InvokeActionMethodFilterAsynchronouslyRecursive>b__2()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass7_0.<BeginInvokeActionMethodWithFilters>b__1(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeActionMethodWithFilters(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass3_6.<BeginInvokeAction>b__3()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.<>c__DisplayClass3_1.<BeginInvokeAction>b__5(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResult`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Async.AsyncControllerActionInvoker.EndInvokeAction(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<>c.<BeginExecuteCore>b__152_1(IAsyncResult asyncResult, ExecuteCoreState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecuteCore(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.<>c.<BeginExecute>b__151_2(IAsyncResult asyncResult, Controller controller)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.Controller.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.Controller.System.Web.Mvc.Async.IAsyncController.EndExecute(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.<>c.<BeginProcessRequest>b__20_1(IAsyncResult asyncResult, ProcessRequestState innerState)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncVoid`1.CallEndDelegate(IAsyncResult asyncResult)
   at System.Web.Mvc.Async.AsyncResultWrapper.WrappedAsyncResultBase`1.End()
   at System.Web.Mvc.MvcHandler.EndProcessRequest(IAsyncResult asyncResult)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.EndProcessRequest(IAsyncResult result)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', CAST(N'2019-05-02T15:49:19.800' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (5, N'Procedure or function ''SP_CREATE_SERIES'' expects parameter ''@parm_SeriesTitle'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DataAccessLayer.ContextDAL.AddSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\DataAccessLayer\ContextDAL.cs:line 978
   at BusinessLayer.BLLContext.NewSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\BusinessLayer\BLLContext.cs:line 344
   at CharacterRepo.Controllers.SeriesController.Create(NewSeriesAndAuthor seriesAndAuthor) in C:\Users\Onshore\source\repos\CharacterRepo\CharacterRepo\Controllers\SeriesController.cs:line 69', CAST(N'2019-05-02T22:16:58.210' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (6, N'Procedure or function ''SP_CREATE_SERIES'' expects parameter ''@parm_SeriesTitle'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DataAccessLayer.ContextDAL.AddSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\DataAccessLayer\ContextDAL.cs:line 978
   at BusinessLayer.BLLContext.NewSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\BusinessLayer\BLLContext.cs:line 344
   at CharacterRepo.Controllers.SeriesController.Create(NewSeriesAndAuthor seriesAndAuthor) in C:\Users\Onshore\source\repos\CharacterRepo\CharacterRepo\Controllers\SeriesController.cs:line 69', CAST(N'2019-05-02T22:27:02.630' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (7, N'Procedure or function ''SP_CREATE_SERIES'' expects parameter ''@parm_SeriesTitle'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DataAccessLayer.ContextDAL.AddSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\DataAccessLayer\ContextDAL.cs:line 978
   at BusinessLayer.BLLContext.NewSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\BusinessLayer\BLLContext.cs:line 344
   at CharacterRepo.Controllers.SeriesController.Create(NewSeriesAndAuthor seriesAndAuthor) in C:\Users\Onshore\source\repos\CharacterRepo\CharacterRepo\Controllers\SeriesController.cs:line 69', CAST(N'2019-05-02T22:46:55.183' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (8, N'Procedure or function ''SP_CREATE_SERIES'' expects parameter ''@parm_SeriesTitle'', which was not supplied.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DataAccessLayer.ContextDAL.AddSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\DataAccessLayer\ContextDAL.cs:line 978
   at BusinessLayer.BLLContext.NewSeries(String _seriesTitle, Int32 _authorID_FK) in C:\Users\Onshore\source\repos\CharacterRepo\BusinessLayer\BLLContext.cs:line 344
   at CharacterRepo.Controllers.SeriesController.Create(NewSeriesAndAuthor seriesAndAuthor) in C:\Users\Onshore\source\repos\CharacterRepo\CharacterRepo\Controllers\SeriesController.cs:line 69', CAST(N'2019-05-03T08:20:44.020' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (1008, N'The controller for path ''/Edit/1045'' was not found or does not implement IController.', N'   at System.Web.Mvc.DefaultControllerFactory.GetControllerInstance(RequestContext requestContext, Type controllerType)
   at System.Web.Mvc.DefaultControllerFactory.CreateController(RequestContext requestContext, String controllerName)
   at System.Web.Mvc.MvcHandler.ProcessRequestInit(HttpContextBase httpContext, IController& controller, IControllerFactory& factory)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContext httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', CAST(N'2019-05-04T23:49:35.693' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (1009, N'The controller for path ''/edit/1045'' was not found or does not implement IController.', N'   at System.Web.Mvc.DefaultControllerFactory.GetControllerInstance(RequestContext requestContext, Type controllerType)
   at System.Web.Mvc.DefaultControllerFactory.CreateController(RequestContext requestContext, String controllerName)
   at System.Web.Mvc.MvcHandler.ProcessRequestInit(HttpContextBase httpContext, IController& controller, IControllerFactory& factory)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContextBase httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.BeginProcessRequest(HttpContext httpContext, AsyncCallback callback, Object state)
   at System.Web.Mvc.MvcHandler.System.Web.IHttpAsyncHandler.BeginProcessRequest(HttpContext context, AsyncCallback cb, Object extraData)
   at System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   at System.Web.HttpApplication.ExecuteStepImpl(IExecutionStep step)
   at System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)', CAST(N'2019-05-04T23:55:46.437' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (1010, N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Character_Series". The conflict occurred in database "CharStubs", table "dbo.Series", column ''SeriesID''.
The statement has been terminated.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DataAccessLayer.ContextDAL.AddCharacter(String _name, String _class, Int32 _ac, Int32 _str, Int32 _dex, Int32 _con, Int32 _intel, Int32 _wis, Int32 _char, String _desc, Int32 _Sid) in C:\Users\Onshore\source\repos\CharacterRepo\DataAccessLayer\ContextDAL.cs:line 538
   at BusinessLayer.BLLContext.NewCharacter(String _name, String _class, Int32 _ac, Int32 _str, Int32 _dex, Int32 _con, Int32 _intel, Int32 _wis, Int32 _char, String _desc, Int32 _Sid) in C:\Users\Onshore\source\repos\CharacterRepo\BusinessLayer\BLLContext.cs:line 190
   at CharacterRepo.Controllers.CharacterController.Create(CharacterBO character) in C:\Users\Onshore\source\repos\CharacterRepo\CharacterRepo\Controllers\CharacterController.cs:line 78', CAST(N'2019-05-06T10:57:19.933' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (1011, N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Character_Series". The conflict occurred in database "CharStubs", table "dbo.Series", column ''SeriesID''.
The statement has been terminated.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DataAccessLayer.ContextDAL.AddCharacter(String _name, String _class, Int32 _ac, Int32 _str, Int32 _dex, Int32 _con, Int32 _intel, Int32 _wis, Int32 _char, String _desc, Int32 _Sid) in C:\Users\Onshore\source\repos\CharacterRepo\DataAccessLayer\ContextDAL.cs:line 538
   at BusinessLayer.BLLContext.NewCharacter(String _name, String _class, Int32 _ac, Int32 _str, Int32 _dex, Int32 _con, Int32 _intel, Int32 _wis, Int32 _char, String _desc, Int32 _Sid) in C:\Users\Onshore\source\repos\CharacterRepo\BusinessLayer\BLLContext.cs:line 190
   at CharacterRepo.Controllers.CharacterController.Create(CharacterBO character) in C:\Users\Onshore\source\repos\CharacterRepo\CharacterRepo\Controllers\CharacterController.cs:line 78', CAST(N'2019-05-06T10:57:40.220' AS DateTime))
INSERT [dbo].[LogTrace] ([LogID], [Message], [Trace], [TimeOfError]) VALUES (1012, N'The INSERT statement conflicted with the FOREIGN KEY constraint "FK_Character_Series". The conflict occurred in database "CharStubs", table "dbo.Series", column ''SeriesID''.
The statement has been terminated.', N'   at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection, Action`1 wrapCloseInAction)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj, Boolean callerHasConnectionLock, Boolean asyncClose)
   at System.Data.SqlClient.TdsParser.TryRun(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj, Boolean& dataReady)
   at System.Data.SqlClient.SqlCommand.FinishExecuteReader(SqlDataReader ds, RunBehavior runBehavior, String resetOptionsString, Boolean isInternal, Boolean forDescribeParameterEncryption, Boolean shouldCacheForAlwaysEncrypted)
   at System.Data.SqlClient.SqlCommand.RunExecuteReaderTds(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, Boolean async, Int32 timeout, Task& task, Boolean asyncWrite, Boolean inRetry, SqlDataReader ds, Boolean describeParameterEncryptionRequest)
   at System.Data.SqlClient.SqlCommand.RunExecuteReader(CommandBehavior cmdBehavior, RunBehavior runBehavior, Boolean returnStream, String method, TaskCompletionSource`1 completion, Int32 timeout, Task& task, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(TaskCompletionSource`1 completion, String methodName, Boolean sendToPipe, Int32 timeout, Boolean& usedCache, Boolean asyncWrite, Boolean inRetry)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()
   at DataAccessLayer.ContextDAL.AddCharacter(String _name, String _class, Int32 _ac, Int32 _str, Int32 _dex, Int32 _con, Int32 _intel, Int32 _wis, Int32 _char, String _desc, Int32 _Sid) in C:\Users\Onshore\source\repos\CharacterRepo\DataAccessLayer\ContextDAL.cs:line 538
   at BusinessLayer.BLLContext.NewCharacter(String _name, String _class, Int32 _ac, Int32 _str, Int32 _dex, Int32 _con, Int32 _intel, Int32 _wis, Int32 _char, String _desc, Int32 _Sid) in C:\Users\Onshore\source\repos\CharacterRepo\BusinessLayer\BLLContext.cs:line 190
   at CharacterRepo.Controllers.CharacterController.Create(CharacterBO character) in C:\Users\Onshore\source\repos\CharacterRepo\CharacterRepo\Controllers\CharacterController.cs:line 78', CAST(N'2019-05-06T11:02:08.577' AS DateTime))
SET IDENTITY_INSERT [dbo].[LogTrace] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [Role]) VALUES (1, N'User')
INSERT [dbo].[Role] ([RoleID], [Role]) VALUES (2, N'Moderator')
INSERT [dbo].[Role] ([RoleID], [Role]) VALUES (3, N'Administrator')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Series] ON 

INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (1, N'The Wheel of Time', 1)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (2, N'The Chronicles Of Thomas Covenant', 2)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (3, N'The Sword of Shannara Trilogy', 3)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (4, N'Apprentice Adept Series', 4)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (5, N'The Heritage of Shannara', 3)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (7, N'Xanthy', 4)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (12, N'The Second Apprentice Adept Series', 4)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (13, N'The Dragon Riders of Pern', 10)
INSERT [dbo].[Series] ([SeriesID], [SeriesTitle], [AuthorID_FK]) VALUES (1009, N'Test Series', 1008)
SET IDENTITY_INSERT [dbo].[Series] OFF
SET IDENTITY_INSERT [dbo].[SuggestedCharacter] ON 

INSERT [dbo].[SuggestedCharacter] ([SuggestedCharacterID], [SuggestedCharacterName], [SuggestedCharacterSeries]) VALUES (1, N'Mennon Leah', N'The Sword of Shannara')
SET IDENTITY_INSERT [dbo].[SuggestedCharacter] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (2, N'Jerry', N'Parker', N'jerryparker', N'hellojerry', N'jerry@yahoo.com', 3)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (3, N'Jack', N'Parker', N'jackparker', N'hellojack', N'jack@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (4, N'Mandy', N'Hudson', N'mandyhudson', N'hellomandy', N'mandy@yahoo.com', 2)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (5, N'Matt', N'Mercer', N'mattmercer', N'hellomatt', N'matt@yahoo.com', 2)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (6, N'Stacy', N'Dutton', N'stacydutton', N'hellostacy', N'stacy@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (7, N'Keith', N'Pirkle', N'keithpirkle', N'hellokeith', N'keith@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (8, N'Tony', N'Slack', N'tonyslack', N'hellotony', N'tony@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (9, N'Jerry', N'Parker', N'parkerjerry', N'hellojerry', N'jerry1@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (10, N'Matt', N'Mercer', N'matty', N'himatt', N'matt@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (11, N'Mandy', N'Hudson', N'hudsonmandy', N'hellomandy', N'mandy1@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (15, N'John', N'Hopkins', N'johnhopkins', N'hellojohn', N'john@yahoo.com', 1)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (16, N'Anthony', N'Hopkins', N'anthopkins', N'helloant', N'ant@yahoo.com', 2)
INSERT [dbo].[User] ([UserID], [FirstName], [LastName], [UserName], [Password], [EmailAddress], [RoleID_FK]) VALUES (29, N'1', N'1', N'1', N'1', N'1', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserCharacter] ON 

INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (7, N'Rand al''Thor', N'Fighter', 7, 70, 16, 15, 14, 15, 14, 12, 15, N'The Dragon Reborn from the Wheel of Time series', 1, 6)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (8, N'Perrin Aybara', N'Fighter', 9, 90, 17, 18, 13, 17, 14, 15, 16, N'A companion of the Dragon Reborn and a childhood friend', 1, 7)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (9, N'Perrin Aybara', N'Fighter', 11, 110, 17, 18, 13, 17, 14, 15, 16, N'A companion of the Dragon Reborn and a childhood friend', 1, 8)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (11, N'Matrim Cauthon', N'Rogue', 10, 80, 16, 14, 17, 14, 15, 12, 17, N'A trickster and childhood friend of Rand al''Thor', 1, 11)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (12, N'Matrim Cauthon', N'Rogue', 14, 112, 18, 14, 17, 14, 15, 12, 17, N'A trickster and childhood friend of Rand al''Thor', 1, 10)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (14, N'Bannor', N'Fighter', 8, 80, 18, 18, 17, 18, 15, 15, 14, N'A fomer member of the Bloodguard. One of the Haruchai people', 2, 6)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (15, N'Allanon', N'Wizard', 11, 66, 17, 13, 14, 17, 18, 16, 18, N'A member of a powerful brotherhood of Druids, the last of his kind', 3, 7)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (16, N'Nynaeve al''Meara', N'Cleric', 12, 72, 16, 13, 15, 17, 15, 14, 12, N'An Aes Sedai of the Yellow Ajah', 1, 9)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (19, N'Tammy', N'Fighter', 10, 100, 18, 10, 14, 15, 14, 15, 10, N'Check', 1, 8)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (21, N'Rand al''Thor', N'Fighter', 7, 70, 17, 15, 14, 15, 14, 12, 15, N'The Dragon Reborn from the Wheel of Time series once upon a time in a land far away.Rand was raised Tam al''Thor in a sleepy little town called Edmonds Field.  He was actually the son of a couple of adopted Aiel from the three fold land also known as the waste.  He is the reincarnation of Lewis Theron Tellamon and is therefore given the moniker the Dragon Reborn, since Lewis Theron was know as the Dragon.  He is a fighter in his build, but is also able to use "magic"  His special abilities include the ability to teleport anywhere once he has been in one place long enough.  He acts as magic user that is equivalent to 3/4 of his fighter level with his special teleport ablility only coming into play when his level reaches 11.', 1, 9)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (27, N'Shea Ohmsford', N'Fighter', 10, 100, 15, 14, 16, 14, 14, 14, 15, N'An adopted son of the Ohmsford family. A half-Elf who is the last descendant of Jerle Shannara and the only one alive who is capable of wielding the Sword of Shannara', 3, 9)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (29, N'Perrin Aybara', N'Fighter', 7, 70, 18, 18, 13, 17, 14, 15, 16, N'A companion of the Dragon Reborn and a childhood friend', 1, 9)
INSERT [dbo].[UserCharacter] ([UserCharacterID], [Name], [Class], [ClassLevel], [HitPoints], [AC], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [Description], [SeriesID_FK], [UserID_FK]) VALUES (1045, N'Rand al''Thor', N'Fighter', 15, 150, 17, 17, 16, 17, 16, 14, 17, N'The Dragon Reborn from the Wheel of Time series once upon a time in a land far away.
Rand was raised Tam al''Thor in a sleepy little town called Edmonds Field.  He was actually the son of a couple of adopted Aiel from the three fold land also known as the waste.  He is the reincarnation of Lewis Theron Tellamon and is therefore given the moniker the Dragon Reborn, since Lewis Theron was know as the Dragon.  He is a fighter in his build, but is also able to use "magic"  His special abilities include the ability to teleport anywhere once he has been in one place long enough.  He acts as magic user that is equivalent to 3/4 of his fighter level with his special teleport ablility only coming into play when his level reaches 11.
', 1, 2)
SET IDENTITY_INSERT [dbo].[UserCharacter] OFF
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Series] FOREIGN KEY([SeriesID_FK])
REFERENCES [dbo].[Series] ([SeriesID])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_Series]
GO
ALTER TABLE [dbo].[Character]  WITH CHECK ADD  CONSTRAINT [FK_Character_Series] FOREIGN KEY([SeriesID_FK])
REFERENCES [dbo].[Series] ([SeriesID])
GO
ALTER TABLE [dbo].[Character] CHECK CONSTRAINT [FK_Character_Series]
GO
ALTER TABLE [dbo].[Series]  WITH CHECK ADD  CONSTRAINT [FK_Series_Author] FOREIGN KEY([AuthorID_FK])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Series] CHECK CONSTRAINT [FK_Series_Author]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID_FK])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserCharacter]  WITH CHECK ADD  CONSTRAINT [FK_UserCharacter_Series] FOREIGN KEY([SeriesID_FK])
REFERENCES [dbo].[Series] ([SeriesID])
GO
ALTER TABLE [dbo].[UserCharacter] CHECK CONSTRAINT [FK_UserCharacter_Series]
GO
ALTER TABLE [dbo].[UserCharacter]  WITH CHECK ADD  CONSTRAINT [FK_UserCharacter_User] FOREIGN KEY([UserID_FK])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[UserCharacter] CHECK CONSTRAINT [FK_UserCharacter_User]
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_AUTHOR]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/3/2019
-- Description:	Insert a new Author into the Author table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_AUTHOR]
	-- Add the parameters for the stored procedure here	
	@parm_Name nvarchar(100),
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Author]	
		([Name])	
	VALUES		
		(@parm_Name)

	SELECT @ID = @@IDENTITY
		
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_BOOK]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/3/2019
-- Description:	Insert a new Book into the Book table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_BOOK]
	-- Add the parameters for the stored procedure here	
	@parm_Title nvarchar(50),
	@parm_SeriesID_FK int,
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Book]	
		([Title],
		[SeriesID_FK])
	VALUES		
		(@parm_Title,
		@parm_SeriesID_FK)

	SELECT @ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/2/2019
-- Description:	Insert a new Character into the Character table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_CHARACTER]
	-- Add the parameters for the stored procedure here
	@parm_Name nvarchar(50),
	@parm_Class nvarchar(50),
	@parm_AC int,
	@parm_Strength int,
	@parm_Dexterity int,
	@parm_Constitution int,
	@parm_Intelligence int,
	@parm_Wisdom int,
	@parm_Charisma int,
	@parm_Description nvarchar(max),
	@parm_SeriesID_FK int,	
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Character]
		([Name],
		[Class],
		[AC],
		[Strength],
		[Dexterity],
		[Constitution],
		[Intelligence],
		[Wisdom],
		[Charisma],
		[Description],
		[SeriesID_FK])		
	VALUES
		(@parm_Name,
		@parm_Class,
		@parm_AC,
		@parm_Strength,
		@parm_Dexterity,
		@parm_Constitution,
		@parm_Intelligence,
		@parm_Wisdom,
		@parm_Charisma,
		@parm_Description,
		@parm_SeriesID_FK)
		

	SELECT @ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_CLASS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/3/2019
-- Description:	Insert a new Class into the Class table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_CLASS]
	-- Add the parameters for the stored procedure here	
	@parm_ClassName nvarchar(50),
	@parm_ClassDiceValue int,
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Class]	
		([ClassName],
		[ClassDiceValue])
	VALUES		
		(@parm_ClassName,
		@parm_ClassDiceValue)

	SELECT @ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_LOGITEM]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 5/02/19
-- Description:	Procedure to Log Errors from an application
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_LOGITEM] 
	-- Add the parameters for the stored procedure here
	@parm_Message nvarchar(500),
	@parm_Stacktrace nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[LogTrace]
		([Message],
		[Trace],
		[TimeOfError])
	VALUES
		(@parm_Message,
		@parm_Stacktrace,
		GETDATE())
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_SERIES]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/3/2019
-- Description:	Insert a new Series into the Series table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_SERIES]
	-- Add the parameters for the stored procedure here
	@parm_SeriesTitle nvarchar(50),
	@parm_AuthorID_FK int,
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Series]	
		([SeriesTitle],
		[AuthorID_FK])
	VALUES		
		(@parm_SeriesTitle,
		@parm_AuthorID_FK)

	SELECT @ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_SUGGESTED_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/3/2019
-- Description:	Insert a new SuggestedCharacter into the SuggestedCharacter table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_SUGGESTED_CHARACTER]
	-- Add the parameters for the stored procedure here	
	@parm_SuggestedCharacterName nvarchar(50),
	@parm_SuggestedCharacterSeries nvarchar(50),
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[SuggestedCharacter]	
		([SuggestedCharacterName],
		[SuggestedCharacterSeries])
	VALUES		
		(@parm_SuggestedCharacterName,
		@parm_SuggestedCharacterSeries)

	SELECT @ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_USER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/3/2019
-- Description:	Insert a new User into the User table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_USER]
	-- Add the parameters for the stored procedure here	
	@parm_FirstName nvarchar(50),
	@parm_LastName nvarchar(50),
	@parm_UserName nvarchar(50),
	@parm_Password nvarchar(50),
	@parm_EmailAddress nvarchar(50),
	@parm_RoleID_FK int,
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[User]	
		([FirstName],
		[LastName],
		[UserName],
		[Password],
		[EmailAddress],
		[RoleID_FK])
	VALUES		
		(@parm_FirstName,
		@parm_LastName,
		@parm_UserName,
		@parm_Password,
		@parm_EmailAddress,
		@parm_RoleID_FK)

	SELECT @ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SP_CREATE_USER_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/2/2019
-- Description:	Insert a new UserCharacter into the UserCharacter table
-- =============================================
CREATE PROCEDURE [dbo].[SP_CREATE_USER_CHARACTER]
	-- Add the parameters for the stored procedure here
	@parm_Name nvarchar(50),
	@parm_Class nvarchar(50),
	@parm_ClassLevel int,
	@parm_HitPoints int,
	@parm_AC int,
	@parm_Strength int,
	@parm_Dexterity int,
	@parm_Constitution int,
	@parm_Intelligence int,
	@parm_Wisdom int,
	@parm_Charisma int,
	@parm_Description nvarchar(max),
	@parm_SeriesID_FK int,	
	@parm_UserID_FK int,
	@ID int OUTPUT

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[UserCharacter]
		([Name],
		[Class],
		[ClassLevel],
		[HitPoints],
		[AC],
		[Strength],
		[Dexterity],
		[Constitution],
		[Intelligence],
		[Wisdom],
		[Charisma],
		[Description],
		[SeriesID_FK],		
		[UserID_FK])
	VALUES
		(@parm_Name,
		@parm_Class,
		@parm_ClassLevel,
		@parm_HitPoints,
		@parm_AC,
		@parm_Strength,
		@parm_Dexterity,
		@parm_Constitution,
		@parm_Intelligence,
		@parm_Wisdom,
		@parm_Charisma,
		@parm_Description,
		@parm_SeriesID_FK,		
		@parm_UserID_FK)
	SELECT
		@ID = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_AUTHOR]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to delete an Author from the Author table
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_AUTHOR] 
	-- Add the parameters for the stored procedure here
	@parm_AuthorID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		[dbo].[Author]
      WHERE
		[AuthorID] = @parm_AuthorID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_BOOK]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to delete a Book from the Book table
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_BOOK] 
	-- Add the parameters for the stored procedure here
	@parm_BookID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		[dbo].[Book]
      WHERE
		[BookID] = @parm_BookID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to delete a Character from the Character table
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_CHARACTER] 
	-- Add the parameters for the stored procedure here
	@parm_CharacterID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		[dbo].[Character]
      WHERE
		[CharacterID] = @parm_CharacterID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_SUGGESTED_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to delete a SuggestedCharacter from the SuggestedCharacter table
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_SUGGESTED_CHARACTER] 
	-- Add the parameters for the stored procedure here
	@parm_SuggestedCharacterID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		[dbo].[SuggestedCharacter]
      WHERE
		[SuggestedCharacterID] = @parm_SuggestedCharacterID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_USER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to delete a User from the User table
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_USER] 
	-- Add the parameters for the stored procedure here
	@parm_UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		[dbo].[UserCharacter]
	WHERE
		[UserID_FK] = @parm_UserID;

	DELETE FROM
		[dbo].[User]
    WHERE
		[UserID] = @parm_UserID
	

END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_USER_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to delete a UserCharacter from the UserCharacter table
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_USER_CHARACTER] 
	-- Add the parameters for the stored procedure here
	@parm_UserCharacterID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		[dbo].[UserCharacter]
      WHERE
		[UserCharacterID] = @parm_UserCharacterID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_USER_CHARACTER_BY_USERID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to delete a UserCharacter from the UserCharacter table
-- =============================================
CREATE PROCEDURE [dbo].[SP_DELETE_USER_CHARACTER_BY_USERID] 
	-- Add the parameters for the stored procedure here
	@parm_UserID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM
		[dbo].[UserCharacter]
      WHERE
		[UserID_FK] = @parm_UserID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_AUTHOR_BY_AUTHORID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/7/2019
-- Description:	Procedure to Select an Author from the Author Table by AuthorID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_AUTHOR_BY_AUTHORID] 
	-- Add the parameters for the stored procedure here
	@parm_AuthorID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[AuthorID],
		[Name]		
    FROM 
		[dbo].[Author]
	WHERE
		[AuthorID] = @parm_AuthorID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_AUTHOR_BY_NAME]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/20/2019
-- Description:	Procedure to Select an Author from the Author Table by Name
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_AUTHOR_BY_NAME] 
	-- Add the parameters for the stored procedure here
	@parm_Name nvarchar(100)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [AuthorID],
       [Name]       
	FROM
	   [dbo].[Author]
	WHERE
	   [Name] = @parm_Name
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_BOOK_BY_BOOKID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to Select a Books from the Book Table by BookID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_BOOK_BY_BOOKID] 
	-- Add the parameters for the stored procedure here
	@parm_BookID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[BookID],
		[Title],
		[SeriesID_FK]
    FROM 
		[dbo].[Book]
	WHERE
		[BookID] = @parm_BookID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_BOOK_BY_TITLE]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/20/2019
-- Description:	Procedure to Select an Author from the Author Table by Name
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_BOOK_BY_TITLE] 
	-- Add the parameters for the stored procedure here
	@parm_Title nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [BookID],
       [Title],
	   [SeriesID_FK]      
	FROM
	   [dbo].[Book]
	WHERE
	   [Title] = @parm_Title
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_CHARACTER_BY_CHARACTERID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/7/2019
-- Description:	Procedure to Select a Character from the Character Table by CharacterID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_CHARACTER_BY_CHARACTERID] 
	-- Add the parameters for the stored procedure here
	@parm_CharacterID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [CharacterID],
       [Name],
       [Class],
	   [AC],
       [Strength],
       [Dexterity],
       [Constitution],
       [Intelligence],
       [Wisdom],
       [Charisma],
       [Description],
       [SeriesID_FK]	
    FROM 
		[dbo].[Character]
	WHERE
		[CharacterID] = @parm_CharacterID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_CLASS_BY_CLASSID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/7/2019
-- Description:	Procedure to Select a Class from the Class Table by ClassID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_CLASS_BY_CLASSID] 
	-- Add the parameters for the stored procedure here
	@parm_ClassID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	   [ClassID],
       [ClassName],
       [ClassDiceValue]
	FROM 
       [dbo].[Class]
	WHERE
		[ClassID] = @parm_ClassID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_CLASS_BY_CLASSNAME]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/16/2019
-- Description:	Procedure to Select a Class from the Class Table by ClassName
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_CLASS_BY_CLASSNAME] 
	-- Add the parameters for the stored procedure here
	@parm_ClassName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	   [ClassID],
       [ClassName],
       [ClassDiceValue]
	FROM 
       [dbo].[Class]
	WHERE
		[ClassName] = @parm_ClassName
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_ROLE_BY_ROLEID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/18/2019
-- Description:	Procedure to Select a Role from the Role Table by RoleID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_ROLE_BY_ROLEID] 
	-- Add the parameters for the stored procedure here
	@parm_RoleID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[RoleID],
		[Role]		
    FROM 
		[dbo].[Role]
	WHERE
		[RoleID] = @parm_RoleID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_S_CHARACTER_BY_S_CHARACTERID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/7/2019
-- Description:	Procedure to Select a SuggestedCharacter from the SuggestedCharacter Table by SuggestedCharacterID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_S_CHARACTER_BY_S_CHARACTERID] 
	-- Add the parameters for the stored procedure here
	@parm_SuggestedCharacterID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [SuggestedCharacterID],
	   [SuggestedCharacterName],
	   [SuggestedCharacterSeries]
    FROM 
	   [dbo].[SuggestedCharacter]
	WHERE
	   [SuggestedCharacterID] = @parm_SuggestedCharacterID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_SERIES_BY_SERIESID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/7/2019
-- Description:	Procedure to Select a Series from the Series Table by SeriesID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_SERIES_BY_SERIESID] 
	-- Add the parameters for the stored procedure here
	@parm_SeriesID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [SeriesID],
       [SeriesTitle],
       [AuthorID_FK]
	FROM
	   [dbo].[Series]
	WHERE
	   [SeriesID] = @parm_SeriesID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_SERIES_BY_SERIESTITLE]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/20/2019
-- Description:	Procedure to Select a Series from the Series Table by SeriesID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_SERIES_BY_SERIESTITLE] 
	-- Add the parameters for the stored procedure here
	@parm_SeriesTitle nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [SeriesID],
       [SeriesTitle],
       [AuthorID_FK]
	FROM
	   [dbo].[Series]
	WHERE
	   [SeriesTitle] = @parm_SeriesTitle
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_USER_BY_USERID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/7/2019
-- Description:	Procedure to Select a User from the User Table by UserID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_USER_BY_USERID] 
	-- Add the parameters for the stored procedure here
	@parm_UserID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [UserID],
       [FirstName],
       [LastName],
       [UserName],
       [Password],
       [EmailAddress],
       [RoleID_FK]
    FROM
	   [dbo].[User]
	WHERE
	   [UserID] = @parm_UserID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_USER_BY_USERNAME]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/16/2019
-- Description:	Procedure to Select a User from the User Table by UserID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_USER_BY_USERNAME] 
	-- Add the parameters for the stored procedure here
	@parm_Username nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [UserID],
       [FirstName],
       [LastName],
       [UserName],
       [Password],
       [EmailAddress],
       [RoleID_FK]
    FROM
	   [dbo].[User]
	WHERE
	   [Username] = @parm_Username
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_A_USER_CHARACTER_BY_USER_CHARACTERID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/7/2019
-- Description:	Procedure to Select a UserCharacters from the UserCharacter Table By UserCharacterID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_A_USER_CHARACTER_BY_USER_CHARACTERID] 
	-- Add the parameters for the stored procedure here
	@parm_UserCharacterID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[UserCharacterID],
		[Name],
		[Class],
		[ClassLevel],
		[HitPoints],
		[AC],
		[Strength],
		[Dexterity],
		[Constitution],
		[Intelligence],
		[Wisdom],
		[Charisma],
		[Description],
		[SeriesID_FK],		
		[UserID_FK]
	FROM
		[dbo].[UserCharacter]
	WHERE
		[UserCharacterID] = @parm_UserCharacterID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_AUTHORS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Select all Authors from the Author Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_AUTHORS] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	   [AuthorID],
       [Name]
    FROM 
	   [dbo].[Author]
	ORDER BY
	   [Name]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_BOOKS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to Select all Books from the Book Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_BOOKS] 
	-- Add the parameters for the stored procedure here	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[BookID],
		[Title],
		[SeriesID_FK]
    FROM 
		[dbo].[Book]
	ORDER BY
	    [Title]
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_BOOKS_BY_SERIES_ID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to Select all Books from the Book Table By SeriesID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_BOOKS_BY_SERIES_ID] 
	-- Add the parameters for the stored procedure here
	@parm_SeriesID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[BookID],
		[Title],
		[SeriesID_FK]
    FROM 
		[dbo].[Book]
	WHERE
		[SeriesID_FK] = @parm_SeriesID
	ORDER BY
	    [Title]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_CHARACTERS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Select all Characters from the Character Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_CHARACTERS]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [CharacterID],
       [Name],
       [Class],
	   [AC],
       [Strength],
       [Dexterity],
       [Constitution],
       [Intelligence],
       [Wisdom],
       [Charisma],
       [Description],
       [SeriesID_FK]       
    FROM
	   [dbo].[Character]
	ORDER BY
	   [Name]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_CLASSES]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Select all Classes from the Class Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_CLASSES]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	   [ClassID],
       [ClassName],
       [ClassDiceValue]
	FROM 
       [dbo].[Class]
	ORDER BY
	   [ClassName]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_ROLES]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/23/2019
-- Description:	Select all Roles from the Role Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_ROLES] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	   [RoleID],
       [Role]
    FROM 
	   [dbo].[Role]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_SERIES]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Select all Series from the Series Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_SERIES]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [SeriesID],
       [SeriesTitle],
       [AuthorID_FK]
	FROM
	   [dbo].[Series]
	ORDER BY
	   [SeriesTitle]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_SUGGESTED_CHARACTERS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to Select all Books from the Book Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_SUGGESTED_CHARACTERS] 
	-- Add the parameters for the stored procedure here	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[SuggestedCharacterID],
		[SuggestedCharacterName],
		[SuggestedCharacterSeries]
    FROM 
		[dbo].[SuggestedCharacter]
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_USER_CHARACTERS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to Select all UserCharacters from the UserCharacter Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_USER_CHARACTERS]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[UserCharacterID],
		[Name],
		[Class],
		[ClassLevel],
		[HitPoints],
		[AC],
		[Strength],
		[Dexterity],
		[Constitution],
		[Intelligence],
		[Wisdom],
		[Charisma],
		[Description],
		[SeriesID_FK],		
		[UserID_FK]
	FROM
		[dbo].[UserCharacter]
	ORDER BY
	    [Name]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_USER_CHARACTERS_BY_USERID]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to Select all UserCharacters from the UserCharacter Table By UserID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_USER_CHARACTERS_BY_USERID] 
	-- Add the parameters for the stored procedure here
	@parm_UserID int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[UserCharacterID],
		[Name],
		[Class],
		[ClassLevel],
		[HitPoints],
		[AC],
		[Strength],
		[Dexterity],
		[Constitution],
		[Intelligence],
		[Wisdom],
		[Charisma],
		[Description],
		[SeriesID_FK],		
		[UserID_FK]
	FROM
		[dbo].[UserCharacter]
	WHERE
		[UserID_FK] = @parm_UserID
	ORDER BY
	    [Name]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_USER_CHARACTERS_BY_USERNAME]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/17/2019
-- Description:	Procedure to Select all UserCharacters from the UserCharacter Table By UserID
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_USER_CHARACTERS_BY_USERNAME] 
	-- Add the parameters for the stored procedure here
	@parm_UserName nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		[UserCharacterID],
		[Name],
		[Class],
		[ClassLevel],
		[HitPoints],
		[AC],
		[Strength],
		[Dexterity],
		[Constitution],
		[Intelligence],
		[Wisdom],
		[Charisma],
		[Description],
		[SeriesID_FK],		
		[UserID_FK]
	FROM
		[dbo].[UserCharacter]
	INNER JOIN
	    [dbo].[User]
	ON 
	    UserID_FK = UserID
	WHERE
		[UserName] = @parm_UserName
END
GO
/****** Object:  StoredProcedure [dbo].[SP_SELECT_ALL_USERS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Select all Users from the Users Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_SELECT_ALL_USERS] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	   [UserID],
       [FirstName],
       [LastName],
       [UserName],
       [Password],
       [EmailAddress],
       [RoleID_FK]
  FROM
	   [dbo].[User]
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_AUTHOR]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to update an Author in the Author table
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_AUTHOR]
	-- Add the parameters for the stored procedure here	
	@parm_AuthorID int,
	@parm_Name nvarchar(50)
	

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Author]	
	SET
		[Name] = @parm_Name
		
	WHERE
		[AuthorID] = @parm_AuthorID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_BOOK]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/6/2019
-- Description:	Procedure to update a Book in the Book table
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_BOOK] 
	-- Add the parameters for the stored procedure here
	@parm_BookID int,
	@parm_Title nvarchar(50),
	@parm_SeriesID_FK int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Book]
	SET 
		[Title] = @parm_Title,
        [SeriesID_FK] = @parm_SeriesID_FK
    WHERE 
		[BookID] = @parm_BookID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to Update A Character in the Character Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_CHARACTER] 
	-- Add the parameters for the stored procedure here
	@parm_CharacterID int,
	@parm_Name nvarchar(50),
	@parm_Class nvarchar(50),
	@parm_AC int,
	@parm_Strength int,
	@parm_Dexterity int,
	@parm_Constitution int,
	@parm_Intelligence int,
	@parm_Wisdom int,
	@parm_Charisma int,
	@parm_Description nvarchar(max),
	@parm_SeriesID_FK int
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Character]
	SET	
		[Name] = @parm_Name,
		[Class] = @parm_Class,
		[AC] = @parm_AC,
		[Strength] = @parm_Strength,
		[Dexterity] = @parm_Dexterity,
		[Constitution] = @parm_Constitution,
		[Intelligence] = @parm_Intelligence,
		[Wisdom] = @parm_Wisdom,
		[Charisma] = @parm_Charisma,
		[Description] = @parm_Description,
		[SeriesID_FK] = @parm_SeriesID_FK		
	Where
	    [CharacterID] = @parm_CharacterID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_CLASS]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to update a Class in the Class table
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_CLASS]
	-- Add the parameters for the stored procedure here	
	@parm_ClassID int,
	@parm_ClassName nvarchar(50),
	@parm_ClassDiceValue int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Class]	
	SET
		[ClassName] = @parm_ClassName,
		[ClassDiceValue] = @parm_ClassDiceValue
	WHERE
		[ClassID] = @parm_ClassID
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_SERIES]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to update a Series in the Series Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_SERIES]
	-- Add the parameters for the stored procedure here
	@parm_SeriesID int,
	@parm_SeriesTitle nvarchar(50),
	@parm_AuthorID_FK int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[Series]
   SET 
	   [SeriesTitle] = @parm_SeriesTitle,
       [AuthorID_FK] = @parm_AuthorID_FK
   Where
	   [SeriesID] = @parm_SeriesID
	   
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_USER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to update a User in the User table
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_USER]
	-- Add the parameters for the stored procedure here
	@parm_UserID int,
	@parm_FirstName nvarchar(50),
	@parm_LastName nvarchar(50),
	@parm_UserName nvarchar(50),
	@parm_Password nvarchar(50),
	@parm_EmailAddress nvarchar(50),
	@parm_RoleID_FK int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE 
	   [dbo].[User]
   SET 
	   [FirstName] = @parm_FirstName,
       [LastName] = @parm_LastName,
       [UserName] = @parm_UserName,
       [Password] = @parm_Password,
       [EmailAddress] = @parm_EmailAddress,
       [RoleID_FK] = @parm_RoleID_FK
 WHERE 
	   [UserID] = @parm_UserID
	
END
GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_USER_CHARACTER]    Script Date: 5/7/2019 9:42:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jerry Parker
-- Create date: 4/4/2019
-- Description:	Procedure to Update A UserCharacter in the UserCharacter Table
-- =============================================
CREATE PROCEDURE [dbo].[SP_UPDATE_USER_CHARACTER] 
	-- Add the parameters for the stored procedure here
	@parm_UserCharacterID int,
	@parm_Name nvarchar(50),
	@parm_Class nvarchar(50),
	@parm_ClassLevel int,
	@parm_HitPoints int,
	@parm_AC int,
	@parm_Strength int,
	@parm_Dexterity int,
	@parm_Constitution int,
	@parm_Intelligence int,
	@parm_Wisdom int,
	@parm_Charisma int,
	@parm_Description nvarchar(max),
	@parm_SeriesID_FK int,	
	@parm_UserID_FK int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [dbo].[UserCharacter]
	SET	
		[Name] = @parm_Name,
		[Class] = @parm_Class,
		[ClassLevel] = @parm_ClassLevel,
		[HitPoints] = @parm_HitPoints,
		[AC] = @parm_AC,
		[Strength] = @parm_Strength,
		[Dexterity] = @parm_Dexterity,
		[Constitution] = @parm_Constitution,
		[Intelligence] = @parm_Intelligence,
		[Wisdom] = @parm_Wisdom,
		[Charisma] = @parm_Charisma,
		[Description] = @parm_Description,
		[SeriesID_FK] = @parm_SeriesID_FK,		
		[UserID_FK] = @parm_UserID_FK
	Where
		[UserCharacterID] = @parm_UserCharacterID
END
GO
USE [master]
GO
ALTER DATABASE [CharStubs] SET  READ_WRITE 
GO
