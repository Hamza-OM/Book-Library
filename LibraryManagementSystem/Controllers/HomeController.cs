using System;
using System.Web.Mvc;
using System.Collections.Generic;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.TotalBooks = GetTotalBooks();
            ViewBag.TotalGenres = GetTotalGenres();
            ViewBag.RecentBooks = GetRecentlyAddedBooks();
            return View();
        }

        // Get total number of books
        private int GetTotalBooks()
        {
            string query = "SELECT COUNT(*) FROM Books";
            object result = Database.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        // Get total number of genres
        private int GetTotalGenres()
        {
            string query = "SELECT COUNT(*) FROM Genres";
            object result = Database.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }

        // Get recently added books
        private List<Book> GetRecentlyAddedBooks()
        {
            List<Book> books = new List<Book>();
            string query = @"SELECT TOP 5 b.BookID, b.Title, b.GenreID, g.GenreName, 
                           b.Author, b.PageCount
                           FROM Books b 
                           LEFT JOIN Genres g ON b.GenreID = g.GenreID
                           ORDER BY b.BookID DESC";
            
            System.Data.DataTable dataTable = Database.ExecuteQuery(query);
            
            foreach (System.Data.DataRow row in dataTable.Rows)
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

        // GET: Home/About
        public ActionResult About()
        {
            return View();
        }
    }
} 