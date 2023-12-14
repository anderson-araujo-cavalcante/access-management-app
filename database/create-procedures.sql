USE AleffGroup
GO

DROP PROCEDURE if exists [dbo].[proc_users_insert_into]
GO
CREATE PROCEDURE proc_users_insert_into @name VARCHAR(100), @login VARCHAR(50), @senha VARCHAR(50),@is_admin BIT
AS
BEGIN       
   INSERT INTO Users 
   (Name, Login, Senha,IsAdmin)
   VALUES
   (@name, @login, @senha, @is_admin);
END;
GO

DROP PROCEDURE if exists [dbo].[proc_users_selectby_name]
GO
CREATE PROCEDURE proc_users_selectby_name @name VARCHAR(100)
AS
BEGIN       
   SELECT
	UserId, Name, Login, Senha, IsAdmin
   FROM Users 
   WHERE Name like '%' + @name + '%';
END;
GO