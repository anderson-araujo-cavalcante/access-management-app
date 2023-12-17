USE AleffGroup
GO

DROP PROCEDURE if exists [dbo].[proc_users_insert_into]
GO
CREATE PROCEDURE proc_users_insert_into @Name VARCHAR(100), @Login VARCHAR(50), @Senha VARCHAR(50),@IsAdmin BIT
AS
BEGIN       
   INSERT INTO Users 
   (Name, Login, Senha,IsAdmin)
   VALUES
   (@Name, @Login, @Senha, @IsAdmin);
END;
GO

DROP PROCEDURE if exists [dbo].[proc_users_selectby_name]
GO
CREATE PROCEDURE proc_users_selectby_name @Name VARCHAR(100)
AS
BEGIN       
   SELECT
	UserId, Name, Login, Senha, IsAdmin
   FROM Users 
   WHERE Name like '%' + @Name + '%';
END;
GO

DROP PROCEDURE if exists [dbo].[proc_users_selectby_login]
GO
CREATE PROCEDURE proc_users_selectby_login @Login VARCHAR(50)
AS
BEGIN       
   SELECT
	UserId, Name, Login, Senha, IsAdmin
   FROM Users 
   WHERE Login = @Login;
END;
GO