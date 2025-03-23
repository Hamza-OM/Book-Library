using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            List<Genre> genres = Genre.GetAllGenres();
            return View(genres);
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            Genre genre = Genre.GetGenreByID(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (string.IsNullOrEmpty(genre.GenreName))
                    {
                        ModelState.AddModelError("GenreName", "Genre Name is required");
                        return View(genre);
                    }

                    genre.Insert();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error creating genre: " + ex.Message);
                TempData["ErrorMessage"] = "Error creating genre: " + ex.Message;
            }
            
            return View(genre);
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            Genre genre = Genre.GetGenreByID(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Genre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                genre.Update();
                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Genre genre = new Genre { GenreID = id };
                genre.Delete();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting genre: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
} 