-- Create the Library database if it doesn't exist
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'LibraryDB')
BEGIN
    CREATE DATABASE [LibraryDB];
END
GO

USE [LibraryDB];
GO

-- Create Genres table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Genres]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Genres] (
        [GenreID] INT NOT NULL PRIMARY KEY,
        [GenreName] NVARCHAR(100) NOT NULL,
        [Description] NVARCHAR(500) NULL
    );
END
GO

-- Create Books table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Books]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Books] (
        [BookID] INT NOT NULL PRIMARY KEY,
        [Title] NVARCHAR(200) NOT NULL,
        [GenreID] INT NOT NULL,
        [Author] NVARCHAR(100) NOT NULL,
        [PageCount] INT NOT NULL
    );
END
GO

-- Insert sample genres if the table is empty
IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].[Genres])
BEGIN
    INSERT INTO [dbo].[Genres] ([GenreID], [GenreName], [Description])
    VALUES 
        (1, 'Fiction', 'Imaginative works not presented as fact'),
        (2, 'Non-Fiction', 'Factual content based on real events'),
        (3, 'Fantasy', 'Fiction with magical or supernatural elements');
END
GO

-- Insert sample books if the table is empty
IF NOT EXISTS (SELECT TOP 1 * FROM [dbo].[Books])
BEGIN
    INSERT INTO [dbo].[Books] ([BookID], [Title], [GenreID], [Author], [PageCount])
    VALUES 
        (1, 'To Kill a Mockingbird', 1, 'Harper Lee', 281),
        (2, 'The Hobbit', 3, 'J.R.R. Tolkien', 310);
END
GO 