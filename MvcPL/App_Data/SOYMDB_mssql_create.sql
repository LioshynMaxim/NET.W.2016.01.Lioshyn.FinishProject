CREATE TABLE [User] (
	Id int IDENTITY (1, 1) NOT NULL,
	Name varchar(12),
	Surname varchar(25),
	Patronymic varchar(20),
	BirthDay date,
	City varchar(20),
	District varchar(20),
	Street varchar(30),
	Housing int,
	Hous int,
	Flat int,
	Postcode int,
	login nvarchar(100) NOT NULL UNIQUE,
	password nvarchar(100) NOT NULL UNIQUE,
  CONSTRAINT [PK_USER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Role] (
	Id int IDENTITY (1, 1) NOT NULL,
	RoleName varchar(20),
  CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [User_Role] (
	IdUser int NOT NULL,
	IdRole int NOT NULL
)
GO
CREATE TABLE [Comment] (
	Id int IDENTITY (1, 1) NOT NULL,
	CommentUser varchar(150),
	IdUser int NOT NULL,
  CONSTRAINT [PK_COMMENT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Phone] (
	Id int IDENTITY (1, 1) NOT NULL,
	PhoneNumber varchar(13),
	IdUser int(13) NOT NULL,
  CONSTRAINT [PK_PHONE] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Mail] (
	Id int IDENTITY (1, 1) NOT NULL,
	Email varchar(70) UNIQUE,
	IdUser int NOT NULL,
  CONSTRAINT [PK_MAIL] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Pupil] (
	Id int IDENTITY (1, 1) NOT NULL,
	School varchar(10),
	NumberSchool int,
	ClassNumber int,
	ClassLetter varchar(5),
	SchoolTeacherSurname varchar(25),
	IdUser int NOT NULL,
	IdTeacher int,
  CONSTRAINT [PK_PUPIL] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Teacher] (
	Id int IDENTITY (1, 1) NOT NULL,
	WorkPlace varchar(50),
	GroupNumber int,
	CourseNumber int,
	ClassRoomBSU int,
	IdUser int NOT NULL,
  CONSTRAINT [PK_TEACHER] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Parent] (
	Id int IDENTITY (1, 1) NOT NULL,
	PlaceOfWork varchar(50),
	IdUser int NOT NULL,
  CONSTRAINT [PK_PARENT] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Pupil_Parent] (
	IdPupil bigint,
	IdPerent bigint
)
GO
CREATE TABLE [ClassRoom] (
	Id int IDENTITY (1, 1) NOT NULL,
	Name varchar(100),
	Room int,
	Time time,
	IdPupil int,
  CONSTRAINT [PK_CLASSROOM] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Teacher_ClassRoom] (
	IdTeacher int NOT NULL,
	IdClassRoom int NOT NULL
)
GO
CREATE TABLE [Pupil_ClassRoom] (
	IdPupil int NOT NULL,
	IdClassRoom int NOT NULL
)
GO
CREATE TABLE [Requisition] (
	Id int IDENTITY (1, 1) NOT NULL,
	Name varchar(12),
	Surname varchar(25),
	Patronymic varchar(20),
	BirthDay date,
	City varchar(20),
	District varchar(20),
	Street varchar(30),
	Housing int,
	Hous int,
	Flat int,
	Postcode int,
  CONSTRAINT [PK_REQUISITION] PRIMARY KEY CLUSTERED
  (
  [Id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO


ALTER TABLE [User_Role] WITH CHECK ADD CONSTRAINT [User_Role_fk0] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [User_Role] CHECK CONSTRAINT [User_Role_fk0]
GO
ALTER TABLE [User_Role] WITH CHECK ADD CONSTRAINT [User_Role_fk1] FOREIGN KEY ([IdRole]) REFERENCES [Role]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [User_Role] CHECK CONSTRAINT [User_Role_fk1]
GO

ALTER TABLE [Comment] WITH CHECK ADD CONSTRAINT [Comment_fk0] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Comment] CHECK CONSTRAINT [Comment_fk0]
GO

ALTER TABLE [Phone] WITH CHECK ADD CONSTRAINT [Phone_fk0] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Phone] CHECK CONSTRAINT [Phone_fk0]
GO

ALTER TABLE [Mail] WITH CHECK ADD CONSTRAINT [Mail_fk0] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Mail] CHECK CONSTRAINT [Mail_fk0]
GO

ALTER TABLE [Pupil] WITH CHECK ADD CONSTRAINT [Pupil_fk0] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil] CHECK CONSTRAINT [Pupil_fk0]
GO
ALTER TABLE [Pupil] WITH CHECK ADD CONSTRAINT [Pupil_fk1] FOREIGN KEY ([IdTeacher]) REFERENCES [Teacher]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil] CHECK CONSTRAINT [Pupil_fk1]
GO

ALTER TABLE [Teacher] WITH CHECK ADD CONSTRAINT [Teacher_fk0] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Teacher] CHECK CONSTRAINT [Teacher_fk0]
GO

ALTER TABLE [Parent] WITH CHECK ADD CONSTRAINT [Parent_fk0] FOREIGN KEY ([IdUser]) REFERENCES [User]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Parent] CHECK CONSTRAINT [Parent_fk0]
GO

ALTER TABLE [Pupil_Parent] WITH CHECK ADD CONSTRAINT [Pupil_Parent_fk0] FOREIGN KEY ([IdPupil]) REFERENCES [Pupil]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_Parent] CHECK CONSTRAINT [Pupil_Parent_fk0]
GO
ALTER TABLE [Pupil_Parent] WITH CHECK ADD CONSTRAINT [Pupil_Parent_fk1] FOREIGN KEY ([IdPerent]) REFERENCES [Parent]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_Parent] CHECK CONSTRAINT [Pupil_Parent_fk1]
GO


ALTER TABLE [Teacher_ClassRoom] WITH CHECK ADD CONSTRAINT [Teacher_ClassRoom_fk0] FOREIGN KEY ([IdTeacher]) REFERENCES [Teacher]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Teacher_ClassRoom] CHECK CONSTRAINT [Teacher_ClassRoom_fk0]
GO
ALTER TABLE [Teacher_ClassRoom] WITH CHECK ADD CONSTRAINT [Teacher_ClassRoom_fk1] FOREIGN KEY ([IdClassRoom]) REFERENCES [ClassRoom]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Teacher_ClassRoom] CHECK CONSTRAINT [Teacher_ClassRoom_fk1]
GO

ALTER TABLE [Pupil_ClassRoom] WITH CHECK ADD CONSTRAINT [Pupil_ClassRoom_fk0] FOREIGN KEY ([IdPupil]) REFERENCES [Pupil]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_ClassRoom] CHECK CONSTRAINT [Pupil_ClassRoom_fk0]
GO
ALTER TABLE [Pupil_ClassRoom] WITH CHECK ADD CONSTRAINT [Pupil_ClassRoom_fk1] FOREIGN KEY ([IdClassRoom]) REFERENCES [ClassRoom]([Id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_ClassRoom] CHECK CONSTRAINT [Pupil_ClassRoom_fk1]
GO


