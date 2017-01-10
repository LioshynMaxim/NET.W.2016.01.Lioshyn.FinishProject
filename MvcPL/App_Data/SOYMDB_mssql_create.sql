CREATE TABLE [User] (
	id int NOT NULL,
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
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Role] (
	id int NOT NULL,
	RoleName varchar(20),
  CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [User_Role] (
	idUser int NOT NULL,
	idRole int NOT NULL
)
GO
CREATE TABLE [Comment] (
	id int NOT NULL,
	CommentUser varchar(150),
	idUser int NOT NULL,
  CONSTRAINT [PK_COMMENT] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Phone] (
	id int NOT NULL,
	PhoneNumber varchar(13),
	idUser int(13) NOT NULL,
  CONSTRAINT [PK_PHONE] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Mail] (
	id int NOT NULL,
	Email varchar(70) UNIQUE,
	idUser int NOT NULL,
  CONSTRAINT [PK_MAIL] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Pupil] (
	id int NOT NULL,
	School varchar(10),
	NumberSchool int,
	ClassNumber int,
	ClassLetter varchar(5),
	SchoolTeacherSurname varchar(25),
	idUser int NOT NULL,
	idTeacher int,
  CONSTRAINT [PK_PUPIL] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Teacher] (
	id int NOT NULL,
	WorkPlace varchar(50),
	groupNumber int,
	courseNumber int,
	ClassRoomBSU int,
	idUser int NOT NULL,
  CONSTRAINT [PK_TEACHER] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Parent] (
	id int NOT NULL,
	PlaceOfWork varchar(50),
	idUser int NOT NULL,
  CONSTRAINT [PK_PARENT] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Pupil_Parent] (
	idPupil bigint,
	idPerent bigint
)
GO
CREATE TABLE [ClassRoom] (
	id int NOT NULL,
	Name varchar(100),
	Room int,
	Time time,
	idPupil int,
  CONSTRAINT [PK_CLASSROOM] PRIMARY KEY CLUSTERED
  (
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Teacher_ClassRoom] (
	idTeacher int NOT NULL,
	idClassRoom int NOT NULL
)
GO
CREATE TABLE [Pupil_ClassRoom] (
	idPupil int NOT NULL,
	idClassRoom int NOT NULL
)
GO
CREATE TABLE [requisition] (
	id int NOT NULL,
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
  [id] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO


ALTER TABLE [User_Role] WITH CHECK ADD CONSTRAINT [User_Role_fk0] FOREIGN KEY ([idUser]) REFERENCES [User]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [User_Role] CHECK CONSTRAINT [User_Role_fk0]
GO
ALTER TABLE [User_Role] WITH CHECK ADD CONSTRAINT [User_Role_fk1] FOREIGN KEY ([idRole]) REFERENCES [Role]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [User_Role] CHECK CONSTRAINT [User_Role_fk1]
GO

ALTER TABLE [Comment] WITH CHECK ADD CONSTRAINT [Comment_fk0] FOREIGN KEY ([idUser]) REFERENCES [User]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Comment] CHECK CONSTRAINT [Comment_fk0]
GO

ALTER TABLE [Phone] WITH CHECK ADD CONSTRAINT [Phone_fk0] FOREIGN KEY ([idUser]) REFERENCES [User]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Phone] CHECK CONSTRAINT [Phone_fk0]
GO

ALTER TABLE [Mail] WITH CHECK ADD CONSTRAINT [Mail_fk0] FOREIGN KEY ([idUser]) REFERENCES [User]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Mail] CHECK CONSTRAINT [Mail_fk0]
GO

ALTER TABLE [Pupil] WITH CHECK ADD CONSTRAINT [Pupil_fk0] FOREIGN KEY ([idUser]) REFERENCES [User]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil] CHECK CONSTRAINT [Pupil_fk0]
GO
ALTER TABLE [Pupil] WITH CHECK ADD CONSTRAINT [Pupil_fk1] FOREIGN KEY ([idTeacher]) REFERENCES [Teacher]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil] CHECK CONSTRAINT [Pupil_fk1]
GO

ALTER TABLE [Teacher] WITH CHECK ADD CONSTRAINT [Teacher_fk0] FOREIGN KEY ([idUser]) REFERENCES [User]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Teacher] CHECK CONSTRAINT [Teacher_fk0]
GO

ALTER TABLE [Parent] WITH CHECK ADD CONSTRAINT [Parent_fk0] FOREIGN KEY ([idUser]) REFERENCES [User]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Parent] CHECK CONSTRAINT [Parent_fk0]
GO

ALTER TABLE [Pupil_Parent] WITH CHECK ADD CONSTRAINT [Pupil_Parent_fk0] FOREIGN KEY ([idPupil]) REFERENCES [Pupil]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_Parent] CHECK CONSTRAINT [Pupil_Parent_fk0]
GO
ALTER TABLE [Pupil_Parent] WITH CHECK ADD CONSTRAINT [Pupil_Parent_fk1] FOREIGN KEY ([idPerent]) REFERENCES [Parent]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_Parent] CHECK CONSTRAINT [Pupil_Parent_fk1]
GO


ALTER TABLE [Teacher_ClassRoom] WITH CHECK ADD CONSTRAINT [Teacher_ClassRoom_fk0] FOREIGN KEY ([idTeacher]) REFERENCES [Teacher]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Teacher_ClassRoom] CHECK CONSTRAINT [Teacher_ClassRoom_fk0]
GO
ALTER TABLE [Teacher_ClassRoom] WITH CHECK ADD CONSTRAINT [Teacher_ClassRoom_fk1] FOREIGN KEY ([idClassRoom]) REFERENCES [ClassRoom]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Teacher_ClassRoom] CHECK CONSTRAINT [Teacher_ClassRoom_fk1]
GO

ALTER TABLE [Pupil_ClassRoom] WITH CHECK ADD CONSTRAINT [Pupil_ClassRoom_fk0] FOREIGN KEY ([idPupil]) REFERENCES [Pupil]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_ClassRoom] CHECK CONSTRAINT [Pupil_ClassRoom_fk0]
GO
ALTER TABLE [Pupil_ClassRoom] WITH CHECK ADD CONSTRAINT [Pupil_ClassRoom_fk1] FOREIGN KEY ([idClassRoom]) REFERENCES [ClassRoom]([id])
ON UPDATE CASCADE
GO
ALTER TABLE [Pupil_ClassRoom] CHECK CONSTRAINT [Pupil_ClassRoom_fk1]
GO


