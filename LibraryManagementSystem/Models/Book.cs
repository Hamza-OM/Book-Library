using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        // Get all books
        public static List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            string query = @"SELECT b.BookID, b.Title, b.GenreID, g.GenreName, b.Author, b.PageCount
                            FROM Books b
                            LEFT JOIN Genres g ON b.GenreID = g.GenreID
                            ORDER BY b.Title";
            
            DataTable dataTable = Database.ExecuteQuery(query);
            
            foreach (DataRow row in dataTable.Rows)
            {
                books.Add(new Book
                {
                    BookID = Convert.ToInt32(row["BookID"]),
                    Title = row["Title"].ToString(),
                    GenreID = Convert.ToInt32(row["GenreID"]),
                    GenreName = row["GenreName"].ToString(),
                    Author = row["Author"].ToString(),
                    PageCount = Convert.ToInt32(row["PageCount"])
                });
            }
            
            return books;
        }
        
        // Get book by ID
        public static Book GetBookByID(int bookID)
        {
            string query = @"SELECT b.BookID, b.Title, b.GenreID, g.GenreName, b.Author, b.PageCount
                            FROM Books b
                            LEFT JOIN Genres g ON b.GenreID = g.GenreID
                            WHERE b.BookID = @BookID";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", bookID)
            };
            
            DataTable dataTable = Database.ExecuteQuery(query, parameters);
            
            if (dataTable.Rows.Count == 0)
                return null;
            
            DataRow row = dataTable.Rows[0];
            
            Book book = new Book
            {
                BookID = Convert.ToInt32(row["BookID"]),
                Title = row["Title"].ToString(),
                GenreID = Convert.ToInt32(row["GenreID"]),
                GenreName = row["GenreName"].ToString(),
                Author = row["Author"].ToString(),
                PageCount = Convert.ToInt32(row["PageCount"])
            };
            
            return book;
        }
        
        // Insert a new book
        public void Insert()
        {
            // Get the maximum BookID and increment it for the new entry
            string getMaxIDQuery = "SELECT ISNULL(MAX(BookID), 0) FROM Books";
            int maxID = Convert.ToInt32(Database.ExecuteScalar(getMaxIDQuery));
            int newID = maxID + 1;
            
            this.BookID = newID;

            string query = @"INSERT INTO Books (BookID, Title, GenreID, Author, PageCount)
                            VALUES (@BookID, @Title, @GenreID, @Author, @PageCount)";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", this.BookID),
                new SqlParameter("@Title", this.Title),
                new SqlParameter("@GenreID", this.GenreID),
                new SqlParameter("@Author", this.Author),
                new SqlParameter("@PageCount", this.PageCount)
            };
            
            Database.ExecuteNonQuery(query, parameters);
        }
        
        // Update an existing book
        public void Update()
        {
            string query = @"UPDATE Books
                            SET Title = @Title,
                                GenreID = @GenreID,
                                Author = @Author,
                                PageCount = @PageCount
                            WHERE BookID = @BookID";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", this.BookID),
                new SqlParameter("@Title", this.Title),
                new SqlParameter("@GenreID", this.GenreID),
                new SqlParameter("@Author", this.Author),
                new SqlParameter("@PageCount", this.PageCount)
            };
            
            Database.ExecuteNonQuery(query, parameters);
        }
        
        // Delete a book
        public void Delete()
        {
            string query = "DELETE FROM Books WHERE BookID = @BookID";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@BookID", this.BookID)
            };
            
            Database.ExecuteNonQuery(query, parameters);
        }
    }
} 