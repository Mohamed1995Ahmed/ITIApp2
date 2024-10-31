using LinqKit;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Manager
{
    public class BookManager:MainManager<Book>
    {
        public BookManager(ProjectContext _context) : base(_context)
        {
        }

        public BookViewModel GetOne(int id)
        {
            return base.GetAll().Where(b => b.ID == id).FirstOrDefault().ToViewModel();
        }
        public Pagination <List<BookViewModel>> Get(string searchText, decimal price,
          int SubjectId = 0, int PublisherId = 0,  string columnName = "Id", bool IsAscending = false,
            int PageSize = 6, int PageNumber = 1)
        {
            var builder = PredicateBuilder.New<Book>();
            var old = builder;


            if (!string.IsNullOrEmpty(searchText))
            {
                builder = builder.Or(b => b.Title.Contains(searchText)|| b.Notes.Contains(searchText)||b.Summary.Contains(searchText));
            }
            if (price > 0)
            {
                builder = builder.Or(d => d.Price > 400);

            }
            if (old == builder)
            {
                builder = null;
            }

            int total =(builder==null)?base.GetAll().Count(): base.GetAll().Where(builder).Count();
            var query = filter (builder, columnName, IsAscending, PageSize, PageNumber);
          
            return new Pagination<List<BookViewModel>>
            {
                PageNumber = PageNumber,
                PageSize = PageSize,
                TotalCount = total,
                DAta=query.Select(b=>b.ToViewModel()).ToList(),
            };

        
      }
    }
}
