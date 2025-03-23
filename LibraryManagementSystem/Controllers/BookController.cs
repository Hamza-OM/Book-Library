using System;
using System.Collections.Generic;
using System.Web.Mvc;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<Book> books = Book.GetAllBooks();
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = Book.GetBookByID(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            ViewBag.Genres = Genre.GetAllGenres();
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Insert();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = Genre.GetAllGenres();
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = Book.GetBookByID(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Genres = Genre.GetAllGenres();
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Update();
                return RedirectToAction("Index");
            }
            ViewBag.Genres = Genre.GetAllGenres();
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Book book = new Book { BookID = id };
                book.Delete();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error deleting book: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
} 