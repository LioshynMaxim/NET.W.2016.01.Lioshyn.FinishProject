-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Comment_fk0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_Comment_fk0];
GO
IF OBJECT_ID(N'[dbo].[FK_Mail_fk0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mails] DROP CONSTRAINT [FK_Mail_fk0];
GO
IF OBJECT_ID(N'[dbo].[FK_Parent_fk0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parents] DROP CONSTRAINT [FK_Parent_fk0];
GO
IF OBJECT_ID(N'[dbo].[FK_Pupil_ClassRoom_ClassRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pupil_ClassRoom] DROP CONSTRAINT [FK_Pupil_ClassRoom_ClassRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_Pupil_ClassRoom_Pupil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pupil_ClassRoom] DROP CONSTRAINT [FK_Pupil_ClassRoom_Pupil];
GO
IF OBJECT_ID(N'[dbo].[FK_Pupil_fk0]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pupils] DROP CONSTRAINT [FK_Pupil_fk0];
GO
IF OBJECT_ID(N'[dbo].[FK_Pupil_fk1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pupils] DROP CONSTRAINT [FK_Pupil_fk1];
GO
IF OBJECT_ID(N'[dbo].[FK_Pupil_Parent_Parent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pupil_Parent] DROP CONSTRAINT [FK_Pupil_Parent_Parent];
GO
IF OBJECT_ID(N'[dbo].[FK_Pupil_Parent_Pupil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pupil_Parent] DROP CONSTRAINT [FK_Pupil_Parent_Pupil];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_ClassRoom_ClassRoom]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teacher_ClassRoom] DROP CONSTRAINT [FK_Teacher_ClassRoom_ClassRoom];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_ClassRoom_Teacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teacher_ClassRoom] DROP CONSTRAINT [FK_Teacher_ClassRoom_Teacher];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Role] DROP CONSTRAINT [FK_User_Role_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Role_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User_Role] DROP CONSTRAINT [FK_User_Role_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClassRooms]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassRooms];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO
IF OBJECT_ID(N'[dbo].[Mails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mails];
GO
IF OBJECT_ID(N'[dbo].[Parents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parents];
GO
IF OBJECT_ID(N'[dbo].[Pupil_ClassRoom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pupil_ClassRoom];
GO
IF OBJECT_ID(N'[dbo].[Pupil_Parent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pupil_Parent];
GO
IF OBJECT_ID(N'[dbo].[Pupils]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pupils];
GO
IF OBJECT_ID(N'[dbo].[Requisitions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requisitions];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Teacher_ClassRoom]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teacher_ClassRoom];
GO
IF OBJECT_ID(N'[dbo].[Teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teachers];
GO
IF OBJECT_ID(N'[dbo].[User_Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User_Role];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClassRooms'
CREATE TABLE [dbo].[ClassRooms] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NULL,
    [Room] int  NULL,
    [Time] time  NULL,
    [IdPupil] int  NULL
);
GO

-- Creating table 'Comments'
CREATE TABLE [dbo].[Comments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CommentUser] varchar(150)  NULL,
    [IdUser] int  NOT NULL,
    [IdUserTo] int  NULL
);
GO

-- Creating table 'Mails'
CREATE TABLE [dbo].[Mails] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] varchar(70)  NULL,
    [IdUser] int  NOT NULL
);
GO

-- Creating table 'Parents'
CREATE TABLE [dbo].[Parents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlaceOfWork] varchar(50)  NULL,
    [IdUser] int  NOT NULL
);
GO

-- Creating table 'Pupils'
CREATE TABLE [dbo].[Pupils] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [School] varchar(10)  NULL,
    [NumberSchool] int  NULL,
    [ClassNumber] int  NULL,
    [ClassLetter] varchar(5)  NULL,
    [SchoolTeacherSurname] varchar(25)  NULL,
    [IdUser] int  NOT NULL,
    [IdTeacher] int  NULL
);
GO

-- Creating table 'Requisitions'
CREATE TABLE [dbo].[Requisitions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(12)  NULL,
    [Surname] varchar(25)  NULL,
    [Patronymic] varchar(20)  NULL,
    [BirthDay] datetime  NULL,
    [City] varchar(20)  NULL,
    [District] varchar(20)  NULL,
    [Street] varchar(30)  NULL,
    [Housing] int  NULL,
    [Hous] int  NULL,
    [Flat] int  NULL,
    [Postcode] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(20)  NULL
);
GO

-- Creating table 'Teachers'
CREATE TABLE [dbo].[Teachers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WorkPlace] varchar(50)  NULL,
    [GroupNumber] int  NULL,
    [CourseNumber] int  NULL,
    [ClassRoomBsu] int  NULL,
    [IdUser] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(12)  NULL,
    [Surname] varchar(25)  NULL,
    [Patronymic] varchar(20)  NULL,
    [BirthDay] datetime  NULL,
    [City] varchar(20)  NULL,
    [District] varchar(20)  NULL,
    [Street] varchar(30)  NULL,
    [Housing] int  NULL,
    [Hous] int  NULL,
    [Flat] int  NULL,
    [Postcode] int  NULL,
    [Login] nvarchar(100)  NOT NULL,
    [Password] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Pupil_ClassRoom'
CREATE TABLE [dbo].[Pupil_ClassRoom] (
    [ClassRooms_Id] int  NOT NULL,
    [Pupils_Id] int  NOT NULL
);
GO

-- Creating table 'Pupil_Parent'
CREATE TABLE [dbo].[Pupil_Parent] (
    [Parents_Id] int  NOT NULL,
    [Pupils_Id] int  NOT NULL
);
GO

-- Creating table 'Teacher_ClassRoom'
CREATE TABLE [dbo].[Teacher_ClassRoom] (
    [ClassRooms_Id] int  NOT NULL,
    [Teachers_Id] int  NOT NULL
);
GO

-- Creating table 'User_Role'
CREATE TABLE [dbo].[User_Role] (
    [Roles_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClassRooms'
ALTER TABLE [dbo].[ClassRooms]
ADD CONSTRAINT [PK_ClassRooms]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [PK_Comments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Mails'
ALTER TABLE [dbo].[Mails]
ADD CONSTRAINT [PK_Mails]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [PK_Parents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pupils'
ALTER TABLE [dbo].[Pupils]
ADD CONSTRAINT [PK_Pupils]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Requisitions'
ALTER TABLE [dbo].[Requisitions]
ADD CONSTRAINT [PK_Requisitions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ClassRooms_Id], [Pupils_Id] in table 'Pupil_ClassRoom'
ALTER TABLE [dbo].[Pupil_ClassRoom]
ADD CONSTRAINT [PK_Pupil_ClassRoom]
    PRIMARY KEY CLUSTERED ([ClassRooms_Id], [Pupils_Id] ASC);
GO

-- Creating primary key on [Parents_Id], [Pupils_Id] in table 'Pupil_Parent'
ALTER TABLE [dbo].[Pupil_Parent]
ADD CONSTRAINT [PK_Pupil_Parent]
    PRIMARY KEY CLUSTERED ([Parents_Id], [Pupils_Id] ASC);
GO

-- Creating primary key on [ClassRooms_Id], [Teachers_Id] in table 'Teacher_ClassRoom'
ALTER TABLE [dbo].[Teacher_ClassRoom]
ADD CONSTRAINT [PK_Teacher_ClassRoom]
    PRIMARY KEY CLUSTERED ([ClassRooms_Id], [Teachers_Id] ASC);
GO

-- Creating primary key on [Roles_Id], [Users_Id] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [PK_User_Role]
    PRIMARY KEY CLUSTERED ([Roles_Id], [Users_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdUser] in table 'Comments'
ALTER TABLE [dbo].[Comments]
ADD CONSTRAINT [FK_Comment_fk0]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Comment_fk0'
CREATE INDEX [IX_FK_Comment_fk0]
ON [dbo].[Comments]
    ([IdUser]);
GO

-- Creating foreign key on [IdUser] in table 'Mails'
ALTER TABLE [dbo].[Mails]
ADD CONSTRAINT [FK_Mail_fk0]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mail_fk0'
CREATE INDEX [IX_FK_Mail_fk0]
ON [dbo].[Mails]
    ([IdUser]);
GO

-- Creating foreign key on [IdUser] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [FK_Parent_fk0]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Parent_fk0'
CREATE INDEX [IX_FK_Parent_fk0]
ON [dbo].[Parents]
    ([IdUser]);
GO

-- Creating foreign key on [IdUser] in table 'Pupils'
ALTER TABLE [dbo].[Pupils]
ADD CONSTRAINT [FK_Pupil_fk0]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pupil_fk0'
CREATE INDEX [IX_FK_Pupil_fk0]
ON [dbo].[Pupils]
    ([IdUser]);
GO

-- Creating foreign key on [IdTeacher] in table 'Pupils'
ALTER TABLE [dbo].[Pupils]
ADD CONSTRAINT [FK_Pupil_fk1]
    FOREIGN KEY ([IdTeacher])
    REFERENCES [dbo].[Teachers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pupil_fk1'
CREATE INDEX [IX_FK_Pupil_fk1]
ON [dbo].[Pupils]
    ([IdTeacher]);
GO

-- Creating foreign key on [ClassRooms_Id] in table 'Pupil_ClassRoom'
ALTER TABLE [dbo].[Pupil_ClassRoom]
ADD CONSTRAINT [FK_Pupil_ClassRoom_ClassRooms]
    FOREIGN KEY ([ClassRooms_Id])
    REFERENCES [dbo].[ClassRooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pupils_Id] in table 'Pupil_ClassRoom'
ALTER TABLE [dbo].[Pupil_ClassRoom]
ADD CONSTRAINT [FK_Pupil_ClassRoom_Pupils]
    FOREIGN KEY ([Pupils_Id])
    REFERENCES [dbo].[Pupils]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pupil_ClassRoom_Pupils'
CREATE INDEX [IX_FK_Pupil_ClassRoom_Pupils]
ON [dbo].[Pupil_ClassRoom]
    ([Pupils_Id]);
GO

-- Creating foreign key on [Parents_Id] in table 'Pupil_Parent'
ALTER TABLE [dbo].[Pupil_Parent]
ADD CONSTRAINT [FK_Pupil_Parent_Parents]
    FOREIGN KEY ([Parents_Id])
    REFERENCES [dbo].[Parents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pupils_Id] in table 'Pupil_Parent'
ALTER TABLE [dbo].[Pupil_Parent]
ADD CONSTRAINT [FK_Pupil_Parent_Pupils]
    FOREIGN KEY ([Pupils_Id])
    REFERENCES [dbo].[Pupils]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Pupil_Parent_Pupils'
CREATE INDEX [IX_FK_Pupil_Parent_Pupils]
ON [dbo].[Pupil_Parent]
    ([Pupils_Id]);
GO

-- Creating foreign key on [ClassRooms_Id] in table 'Teacher_ClassRoom'
ALTER TABLE [dbo].[Teacher_ClassRoom]
ADD CONSTRAINT [FK_Teacher_ClassRoom_ClassRooms]
    FOREIGN KEY ([ClassRooms_Id])
    REFERENCES [dbo].[ClassRooms]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teachers_Id] in table 'Teacher_ClassRoom'
ALTER TABLE [dbo].[Teacher_ClassRoom]
ADD CONSTRAINT [FK_Teacher_ClassRoom_Teachers]
    FOREIGN KEY ([Teachers_Id])
    REFERENCES [dbo].[Teachers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Teacher_ClassRoom_Teachers'
CREATE INDEX [IX_FK_Teacher_ClassRoom_Teachers]
ON [dbo].[Teacher_ClassRoom]
    ([Teachers_Id]);
GO

-- Creating foreign key on [Roles_Id] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [FK_User_Role_Roles]
    FOREIGN KEY ([Roles_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'User_Role'
ALTER TABLE [dbo].[User_Role]
ADD CONSTRAINT [FK_User_Role_Users]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Role_Users'
CREATE INDEX [IX_FK_User_Role_Users]
ON [dbo].[User_Role]
    ([Users_Id]);
GO

-- Creating foreign key on [IdUser] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [FK_TeacherUser]
    FOREIGN KEY ([IdUser])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherUser'
CREATE INDEX [IX_FK_TeacherUser]
ON [dbo].[Teachers]
    ([IdUser]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------