using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public static class BookExtentions
    {
        public static BookViewModel ToViewModel (this Book book)
        {
            return new BookViewModel
            {
                ID = book.ID,
                Title = book.Title,
                Isbn = book.Isbn,
                SubjectId = book.SubjectId,
                Summary = book.Summary,
                PageCount = book.PageCount,
                PublicationDate = book.PublicationDate,
                PublisherId = book.PublisherId,
                Notes = book.Notes,
                Price = book.Price,
                Publishername = $" {book.Publisher.User.Firstname} {book.Publisher.User.Lastname}",
                Subjectname=book.Subject.Name,
                Attachments = book.Attachments.Select(x =>x.Path).ToList(),
               Authers =book.Authers.Select(x=> $" {x.Author.User.Firstname} {x.Author.User.Lastname}").ToList(),
            };

        }
        public static Book ToViewModel1(this BookViewModel book)
        {
            return new Book
            {
                //ID = book.ID,
                //Title = book.Title,
                //Isbn = book.Isbn,
                //SubjectId = book.SubjectId,
                //Summary = book.Summary,
                //PageCount = book.PageCount,
                //PublicationDate = book.PublicationDate,
                //PublisherId = book.PublisherId,
                //Notes = book.Notes,
                //Price = book.Price,
                //Publishername = book.Publisher.WebSite,
                //Subjectname = book.Subject.Name,
                //Attachments = book.Attachments.Select(x => x.Path).ToList(),
                //Authers = book.Authers.Select(x => x.Author.WebSite).ToList(),
                ID=book.ID,
                Title = book.Title,
                Isbn = book.Isbn,
                SubjectId = book.SubjectId,
                Summary = book.Summary,
                PageCount = book.PageCount,
                PublicationDate = book.PublicationDate,
                PublisherId = book.PublisherId,
                Notes = book.Notes,
                Price = book.Price,

            };

        }
    }
}
