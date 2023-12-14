﻿CREATE DATABASE AleffGroup;

CREATE TABLE Users (
    UserId INT IDENTITY(1, 1),
    Name VARCHAR(100) NOT NULL,
    Login VARCHAR(50) NOT NULL,
	Senha VARCHAR(50) NOT NULL,
	IsAdmin BIT DEFAULT 0,
    CONSTRAINT PK_User PRIMARY KEY (UserId)
) ;

CREATE TABLE LogsAccess (
    LogAcessoId INT IDENTITY(1, 1),
	UserId INT NOT NULL,
    DateTimeAccess DATETIME NOT NULL,
    AdressIp VARCHAR(50) NOT NULL,
    CONSTRAINT PK_LogsAccess PRIMARY KEY (LogAcessoId),
    CONSTRAINT FK_LogsAccess_Users_UserId FOREIGN KEY (UserId) REFERENCES Users (UserId) ON DELETE CASCADE
);