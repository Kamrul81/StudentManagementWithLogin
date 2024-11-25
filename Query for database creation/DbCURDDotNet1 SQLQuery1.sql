GO
CREATE DATABASE StudentManagementWithLogin
GO


GO
USE StudentManagementWithLogin
GO 


GO
Create table Student(
	Id int IDENTITY(1,1) NOT NULL CONSTRAINT Student_ID PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Mobile varchar(50) NOT NULL,
	Address varchar(250) NULL,
)
GO

CREATE PROCEDURE SPStudent
    @Firstname NVARCHAR(50),
    @Lastname NVARCHAR(50),
    @Email NVARCHAR(100),
    @Mobile NVARCHAR(15),
    @Address NVARCHAR(250)
AS
BEGIN
    INSERT INTO Student (FirstName, LastName, Email, Mobile, Address)
    VALUES (@Firstname, @Lastname, @Email, @Mobile, @Address);
END;
GO

Create procedure SPUpdateStudent
(
	@Id INT,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(50),
	@Mobile varchar(50),
	@Address varchar(250)
)
as
Begin
	Update Student
	set FirstName = @FirstName,
	LastName = @LastName,
	Email = @Email,
	Mobile = @Mobile,
	Address = @Address
	where Id = @Id
END
GO

Create procedure SPDeleteStudent
(
	@Id int
)
as
begin
	Delete from Student where Id = @Id
End
GO

Create procedure SPGetAllStudent
as
Begin
	select *
	from Student
	order by Id DESC
END
GO