# Library Management System

A simple ASP.NET web application with database CRUD functionality for managing books and genres.

## Technologies Used

- ASP.NET MVC
- MS SQL Server
- HTML, CSS, JavaScript
- Bootstrap for responsive UI

## Database Setup

1. Open SQL Server Management Studio
2. Connect to your local SQL Server instance
3. Run the script in `Database/DatabaseSetup.sql` to create the database and tables

## Application Setup

1. Open the solution in Visual Studio
2. Update the connection string in `Web.config` to match your SQL Server instance
3. Build the solution
4. Run the application

## Features

- **Dashboard**: View summary of books, genres, and recently added books
- **Books Management**:
  - View all books with details
  - Add new books
  - Edit existing books
  - Delete books
  - View book details including summary
- **Genres Management**:
  - View all genres
  - Add new genres
  - Edit existing genres
  - Delete genres (only if they don't contain books)

## Usage Guide

1. **Home Page**: The dashboard shows summary statistics of your library
2. **Books**: View, search, and manage your books
3. **Genres**: Organize your books into genres

## Requirements

- Visual Studio 2019 or newer
- .NET Framework 4.7.2 or newer
- SQL Server (Express Edition is sufficient) 