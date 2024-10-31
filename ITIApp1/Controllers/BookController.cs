using ITIApp1.Models;
using Manager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using Models;
using static Azure.Core.HttpHeader;
using ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace ITIApp1.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        // ProjectContext context = new ProjectContext();
        BookManager bookManager;
        PuplisherManager puplisherManager;
        SubjectManager subjectManager;
        public BookController(BookManager bookManager, PuplisherManager puplisherManager, SubjectManager subjectManager)
        {
            this.bookManager = bookManager;
            this.puplisherManager = puplisherManager;
            this.subjectManager = subjectManager;
        }

        [HttpGet]
        public IActionResult index(string searchText, decimal price, int subjectId = 0,int publisherId= 0,string columnName = "Id", bool IsAscending =false, int PageSize = 5, int PageNumber = 1)
        {
            
           Pagination< List<BookViewModel>> list = bookManager.Get(searchText,price,subjectId,publisherId,columnName,IsAscending, PageSize, PageNumber);
            ViewData["subject"] = subjectManager.GetAll().Select(s => new SelectListItem(s.Name, s.ID.ToString())).ToList();
            ViewData["publisher"] = puplisherManager.GetAll().Select(s => new SelectListItem($" {s.User.Firstname} {s.User.Lastname}", s.ID.ToString())).ToList();
            ViewData["price"] = price;
            ViewData["searchtext"] = searchText;
            ViewData["subid"] = subjectId;
            ViewData["pubid"] = publisherId;

            return View("booklist",list);
        }
        public IActionResult getdetails(int id)
        {
            BookViewModel book = bookManager.GetOne(id);
            return View(book);

        }
        [HttpGet]
        public IActionResult Add() {
            ViewData["subject"] = subjectManager.GetAll().Select(s => new SelectListItem(s.Name, s.ID.ToString())).ToList();
            ViewData["publisher"] = puplisherManager.GetAll().Select(s => new SelectListItem($" {s.User.Firstname} {s.User.Lastname}", s.ID.ToString())).ToList();
            return View(); ;
            
            
        
        }
        [HttpPost]
        public IActionResult SaveAdd(AddBookViewModel data)
        {
            if (ModelState.IsValid) {
               bookManager.Add(new Book
                {
                    Isbn=data.Isbn,
                    Title=data.Title,
                    Summary=data.Summary,
                    SubjectId=data.SubjectId,
                    PageCount=data.PageCount,
                    PublicationDate=data.PublicationDate,
                    PublisherId=data.PublisherId,
                    Notes=data.Notes,Price=data.Price,

                });
               
                return RedirectToAction("index",data);
            }
            else
            {
                ViewData["subject"] = subjectManager.GetAll().Select(s => new SelectListItem(s.Name, s.ID.ToString())).ToList();
                ViewData["publisher"] = puplisherManager.GetAll().Select(s => new SelectListItem($" {s.User.Firstname} {s.User.Lastname}", s.ID.ToString())).ToList();
                return View(data);
            }
            

        }
        public IActionResult edit(int id)
        {
            BookViewModel book = bookManager.GetOne(id); 
           
            ViewData["subject"] = subjectManager.GetAll().Select(s => new SelectListItem(s.Name, s.ID.ToString())).ToList();
            ViewData["publisher"] = puplisherManager.GetAll().Select(s => new SelectListItem($" {s.User.Firstname} {s.User.Lastname}", s.ID.ToString())).ToList();
           
            return View(book);
        }
        public IActionResult SaveEdit(int id, AddBookViewModel data)
        {
            BookViewModel book = bookManager.GetOne(id);
            if (ModelState.IsValid) // Check if the model state is valid
            {
               
                if (book == null)
                {
                    return NotFound(); // Handle case where book is not found
                }
                if(data.Title != null)
                {
                    book.Title = data.Title;
                    book.Notes = data.Notes; 
                   book.PageCount = data.PageCount;
                    book.Isbn = data.Isbn;
                    book.PublisherId = data.PublisherId;
                    book.SubjectId = data.SubjectId;
                    book.Price = data.Price;
                    book.Summary = data.Summary;
                }

                // Update properties of the book
           
               // context.SaveChanges(); // Save changes to the database

                return RedirectToAction("Index"); // Redirect to the Index action


            }

            // If we got this far, something failed, redisplay the form
            ViewData["subject"] = subjectManager.GetAll().Select(s => new SelectListItem(s.Name, s.ID.ToString())).ToList();
            ViewData["publisher"] = puplisherManager.GetAll().Select(s => new SelectListItem($" {s.User.Firstname} {s.User.Lastname}", s.ID.ToString())).ToList();
            return View("Edit", data); // Return the Edit view with the model data for corrections
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the book by ID
            BookViewModel book = bookManager.GetOne(id);

            // Check if the book exists
            if (book == null)
            {
                return NotFound(); // If not found, return a 404 response
            }

            // Pass the book to the view for confirmation
            return View(book);
        }




        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            BookViewModel book1 = bookManager.GetOne(id);

            if (book1 == null)
            {
                return NotFound();
            }
            Book book=book1.ToViewModel1();
            


            bookManager.delete(book);

            return RedirectToAction("Index");
        }







    }
}
