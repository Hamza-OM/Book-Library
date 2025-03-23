using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public string Description { get; set; }

        // Get all genres
        public static List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();
            string query = "SELECT GenreID, GenreName, Description FROM Genres ORDER BY GenreName";
            
            DataTable dataTable = Database.ExecuteQuery(query);
            
            foreach (DataRow row in dataTable.Rows)
            {
                genres.Add(new Genre
                {
                    GenreID = Convert.ToInt32(row["GenreID"]),
                    GenreName = row["GenreName"].ToString(),
                    Description = row["Description"].ToString()
                });
            }
            
            return genres;
        }

        // Get genre by ID
        public static Genre GetGenreByID(int genreID)
        {
            string query = "SELECT GenreID, GenreName, Description FROM Genres WHERE GenreID = @GenreID";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GenreID", genreID)
            };
            
            DataTable dataTable = Database.ExecuteQuery(query, parameters);
            
            if (dataTable.Rows.Count == 0)
                return null;
            
            DataRow row = dataTable.Rows[0];
            
            Genre genre = new Genre
            {
                GenreID = Convert.ToInt32(row["GenreID"]),
                GenreName = row["GenreName"].ToString(),
                Description = row["Description"].ToString()
            };
            
            return genre;
        }

        // Insert a new genre
        public void Insert()
        {
            // Get the maximum GenreID and increment it for the new entry
            string getMaxIDQuery = "SELECT ISNULL(MAX(GenreID), 0) FROM Genres";
            int maxID = Convert.ToInt32(Database.ExecuteScalar(getMaxIDQuery));
            int newID = maxID + 1;
            
            this.GenreID = newID;

            string query = "INSERT INTO Genres (GenreID, GenreName, Description) VALUES (@GenreID, @GenreName, @Description)";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GenreID", this.GenreID),
                new SqlParameter("@GenreName", this.GenreName),
                new SqlParameter("@Description", this.Description)
            };
            
            Database.ExecuteNonQuery(query, parameters);
        }

        // Update an existing genre
        public void Update()
        {
            string query = @"UPDATE Genres
                            SET GenreName = @GenreName,
                                Description = @Description
                            WHERE GenreID = @GenreID";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GenreID", this.GenreID),
                new SqlParameter("@GenreName", this.GenreName),
                new SqlParameter("@Description", this.Description)
            };
            
            Database.ExecuteNonQuery(query, parameters);
        }

        // Delete a genre
        public void Delete()
        {
            string query = "DELETE FROM Genres WHERE GenreID = @GenreID";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GenreID", this.GenreID)
            };
            
            Database.ExecuteNonQuery(query, parameters);
        }

        // Check if genre has books
        public bool HasBooks()
        {
            string query = "SELECT COUNT(*) FROM Books WHERE GenreID = @GenreID";
            
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GenreID", GenreID)
            };
            
            object result = Database.ExecuteScalar(query, parameters);
            int count = Convert.ToInt32(result);
            
            return count > 0;
        }
    }
} 