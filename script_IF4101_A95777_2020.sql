USE [master]
GO
/****** Object:  Database [IF4101_A95777_2020]    Script Date: 15/5/2020 15:58:40 ******/
CREATE DATABASE [IF4101_A95777_2020]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IF4101_A95777_2020', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\IF4101_A95777_2020.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IF4101_A95777_2020_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\IF4101_A95777_2020_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [IF4101_A95777_2020] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IF4101_A95777_2020].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IF4101_A95777_2020] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET ARITHABORT OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IF4101_A95777_2020] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IF4101_A95777_2020] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IF4101_A95777_2020] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IF4101_A95777_2020] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET RECOVERY FULL 
GO
ALTER DATABASE [IF4101_A95777_2020] SET  MULTI_USER 
GO
ALTER DATABASE [IF4101_A95777_2020] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IF4101_A95777_2020] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IF4101_A95777_2020] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IF4101_A95777_2020] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IF4101_A95777_2020] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'IF4101_A95777_2020', N'ON'
GO
ALTER DATABASE [IF4101_A95777_2020] SET QUERY_STORE = OFF
GO
USE [IF4101_A95777_2020]
GO
/****** Object:  Table [dbo].[Major]    Script Date: 15/5/2020 15:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Major](
	[MajorId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Major] PRIMARY KEY CLUSTERED 
(
	[MajorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nationality]    Script Date: 15/5/2020 15:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nationality](
	[NationalityId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Nationality] PRIMARY KEY CLUSTERED 
(
	[NationalityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 15/5/2020 15:58:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [int] NULL,
	[Nationality] [int] NULL,
	[Major] [int] NULL,
	[Seniority] [varchar](100) NULL,
	[Interests] [varchar](100) NULL,
	[EntryDate] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Major] ON 

INSERT [dbo].[Major] ([MajorId], [Name]) VALUES (1, N'Informática')
INSERT [dbo].[Major] ([MajorId], [Name]) VALUES (2, N'Inglés')
INSERT [dbo].[Major] ([MajorId], [Name]) VALUES (3, N'Derecho')
SET IDENTITY_INSERT [dbo].[Major] OFF
SET IDENTITY_INSERT [dbo].[Nationality] ON 

INSERT [dbo].[Nationality] ([NationalityId], [Description]) VALUES (1, N'CR')
INSERT [dbo].[Nationality] ([NationalityId], [Description]) VALUES (2, N'USA')
INSERT [dbo].[Nationality] ([NationalityId], [Description]) VALUES (3, N'MEX')
SET IDENTITY_INSERT [dbo].[Nationality] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (21, N'Julian Gómez', 99, 2, 1, N'senior', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (22, N'Flor Jiménez', 10, 3, 3, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (23, N'Flor', 10, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (24, N'Flor Marin', 10, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (25, N'Juanana', 14, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (26, N'Diego', 45, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (27, N'Cantinflas', 95, 3, 3, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (28, N'Esteban', 30, 1, 2, N'senior', N'Traveling', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (29, N'Carlote', 85, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (30, N'Mariano', 10, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (31, N'Fairel', 15, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (32, N'Nestor', 29, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (33, N'Nestor', 29, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (34, N'Sutano', 50, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (35, N'Nestor', 29, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (36, N'Flor', 29, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (37, N'Florinda Mesa', 29, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (38, N'Luis', 25, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (39, N'Iván', 50, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (40, N'Marindo', 55, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (42, N'Pandolfo', 30, 1, 2, N'senior', N'Traveling', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (45, N'Flor Marin', 25, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (46, N'Lilian', 99, 1, 2, N'senior', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (47, N'Papiton', 85, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (48, N'Pinpinolo', 85, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (49, N'Roberto', 35, 1, 2, N'senior', N'Traveling', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (50, N'Pepe', 12, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (51, N'Karina', 15, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (52, N'Cindy', 56, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (53, N'Marita', 10, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (55, N'Ramon Santos', 45, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (56, N'Marlon Ramires', 20, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (57, N'Flor Marin', 25, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (58, N'Pito', 20, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (59, N'Marindo', 10, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (60, N'Samanta', 15, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (61, N'Parnildo', 10, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (62, N'Carlos Mario', 25, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (63, N'Garibaldi', 60, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (67, N'Flor Marin', 84, 1, 1, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (72, N'Hernán', 26, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (73, N'Hernán', 26, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (74, N'Hernán', 26, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (75, N'hernan', 26, 1, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (78, N'Greivin Moya', 25, 1, 1, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (79, N'Virinia Vega', 89, 1, 1, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (81, N'Kalua', 50, 1, 2, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (82, N'Pinto', 15, 1, 2, N'freshman ', N'Television', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (83, N'Hugo Sánchez', 60, 1, 1, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (84, N'Marco Jara', 50, 1, 1, N'senior', N'Reading', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (85, N'Pito', 20, 3, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (86, N'Cacan', 23, 2, 2, N'freshman ', N'Crafts', N'2020-01-01')
INSERT [dbo].[Student] ([StudentId], [Name], [Age], [Nationality], [Major], [Seniority], [Interests], [EntryDate]) VALUES (87, N'Prieto', 20, 2, 2, N'freshman ', N'Crafts', N'2020-01-01')
SET IDENTITY_INSERT [dbo].[Student] OFF
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [Major_fk] FOREIGN KEY([Major])
REFERENCES [dbo].[Major] ([MajorId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [Major_fk]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [Nationality_fk] FOREIGN KEY([Nationality])
REFERENCES [dbo].[Nationality] ([NationalityId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [Nationality_fk]
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudent]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteStudent] (@StudentId INTEGER) 
AS 
  BEGIN 
      DELETE Student 
      WHERE  StudentId = @StudentId; 
  END
GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateStudent]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateStudent] (
									   @StudentId      INTEGER, 
                                       @Name    VARCHAR(50), 
                                       @Age     INTEGER, 
                                       @Nationality   INTEGER, 
                                       @Major INTEGER,
                                       @Action  VARCHAR(10)) 
AS 
  BEGIN 
      IF @Action = 'Insert' 
        BEGIN 
            INSERT INTO 
			Student (Name,Age,Nationality,Major)
            VALUES     (@Name,@Age,@Nationality,@Major)
        END 
      IF @Action = 'Update' 
        BEGIN 
            UPDATE Student 
            SET    Name = @Name, 
                   Age = @Age,
				   Nationality = @Nationality,
				   Major = @Major
            WHERE  StudentId = @StudentId;
        END 
  END 

  
  

GO
/****** Object:  StoredProcedure [dbo].[InsertUpdateStudentAll]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUpdateStudentAll] (
									   @StudentId      INTEGER, 
                                       @Name    VARCHAR(50), 
                                       @Age     INTEGER, 
                                       @Nationality  INTEGER, 
                                       @Major INTEGER,
                                       @Action  VARCHAR(10)) 
AS 
  BEGIN 
      IF @Action = 'Insert' 
        BEGIN 
            INSERT INTO 
			Student (Name,Age,Nationality,Major)
            VALUES     (@Name,@Age,@Nationality,@Major);
        END 
      IF @Action = 'Update' 
        BEGIN 
            UPDATE Student 
            SET    Name = @Name, 
                   Age = @Age,
				   Nationality = @Nationality,
				   Major = @Major
            WHERE  StudentId = @StudentId;
        END 
  END 

  

GO
/****** Object:  StoredProcedure [dbo].[SelectMajor]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectStudent 
CREATE PROCEDURE [dbo].[SelectMajor] 
AS 
  BEGIN 
      SELECT *
      FROM   Major
	  order by MajorId; 
END 
GO
/****** Object:  StoredProcedure [dbo].[SelectNationality]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectStudent 
CREATE PROCEDURE [dbo].[SelectNationality] 
AS 
  BEGIN 
      SELECT *
      FROM   Nationality
	  order by NationalityId; 
END 
GO
/****** Object:  StoredProcedure [dbo].[SelectStudent]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectStudent 
CREATE PROCEDURE [dbo].[SelectStudent] 
AS 
  BEGIN 
     SELECT S.StudentId,
	 S.Name,
	 S.Age,
	 N.Description As NationalityName,
	 M.Name AS MajorName,
	 N.NationalityId,
	 M.MajorId,
	 S.Seniority,
	 S.EntryDate,
	 S.Interests
     FROM   Student S, Nationality N, Major M
	 WHERE S.Nationality=N.NationalityId 
	 AND S.Major= M.MajorId
	 ORDER BY StudentId DESC
END 
GO
/****** Object:  StoredProcedure [dbo].[SelectStudentAPI]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectStudent 
CREATE PROCEDURE [dbo].[SelectStudentAPI] 
AS 
  BEGIN 
     SELECT S.StudentId,
	 S.Name, 
	 S.Age,
	 N.Description As NationalityName,
	 M.Name AS MajorName,
	 N.NationalityId as Nationality, 
	 M.MajorId as Major,
	 S.Seniority,
	 S.EntryDate,
	 S.Interests
      FROM   Student S, Nationality N, Major M
	  WHERE S.Nationality=N.NationalityId 
	  AND S.Major= M.MajorId
	  ORDER BY StudentId DESC
END 
GO
/****** Object:  StoredProcedure [dbo].[SelectStudentById]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectStudentById
CREATE PROCEDURE [dbo].[SelectStudentById] (@StudentId  INTEGER) 

AS 
  BEGIN 
      SELECT S.StudentId, 
		 S.Name,
		 S.Age,
		 N.Description As NationalityName,
		 M.Name AS MajorName,
		 N.NationalityId,
		 M.MajorId,
		 S.Seniority,
		 S.EntryDate,
		 S.Interests
      FROM   Student S, Nationality N, Major M
	  WHERE S.Nationality=N.NationalityId 
	  AND S.Major= M.MajorId
	  AND StudentId=@StudentId; 
END 

GO
/****** Object:  StoredProcedure [dbo].[SelectStudentByIdAPI]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- SelectStudentById
CREATE PROCEDURE [dbo].[SelectStudentByIdAPI] (@StudentId  INTEGER) 

AS 
  BEGIN 
      SELECT S.StudentId,
	  S.Name, 
	  S.Age, 
	  N.Description As NationalityName,
	  M.Name AS MajorName,
	  N.NationalityId AS Nationality,
	  M.MajorId AS Major,
	   S.Seniority,
	 S.EntryDate,
	 S.Interests
      FROM   Student S, Nationality N, Major M
	  WHERE S.Nationality=N.NationalityId 
	  AND S.Major= M.MajorId
	  AND StudentId=@StudentId; 
END 

GO
/****** Object:  StoredProcedure [dbo].[SelectStudentByName]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectStudentByName
CREATE PROCEDURE [dbo].[SelectStudentByName] (@StudentName varchar(50)) 
AS 
  BEGIN 
      SELECT S.StudentId, 
		 S.Name,
		 S.Age,
		 N.Description As NationalityName,
		 M.Name AS MajorName,
		 N.NationalityId,
		 M.MajorId,
		 S.Seniority,
		 S.EntryDate,
		 S.Interests
      FROM  Student S, Nationality N, Major M
	  WHERE S.Nationality=N.NationalityId 
	  AND S.Major= M.MajorId
	  AND S.Name like '%'+@StudentName+'%'; 
END 

GO
/****** Object:  StoredProcedure [dbo].[SelectStudentByNameApi]    Script Date: 15/5/2020 15:58:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SelectStudentByName
Create PROCEDURE [dbo].[SelectStudentByNameApi] (@StudentName varchar(50)) 
AS 
  BEGIN 
      SELECT S.StudentId, 
		 S.Name, 
	  S.Age, 
	  N.Description As NationalityName,
	  M.Name AS MajorName,
	  N.NationalityId AS Nationality,
	  M.MajorId AS Major,
	   S.Seniority,
	 S.EntryDate,
	 S.Interests
      FROM  Student S, Nationality N, Major M
	  WHERE S.Nationality=N.NationalityId 
	  AND S.Major= M.MajorId
	  AND S.Name like '%'+@StudentName+'%'; 
END 

GO
USE [master]
GO
ALTER DATABASE [IF4101_A95777_2020] SET  READ_WRITE 
GO
