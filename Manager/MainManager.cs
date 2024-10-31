using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;
namespace Manager
{
    public class MainManager<T> where T : class
    {
        private readonly ProjectContext context;
        private DbSet<T> set1;
        public MainManager(ProjectContext _context) {
            this.context = _context;
            this.set1 = context.Set<T>();
        }
        public IQueryable<T> filter (Expression<Func<T,bool>> expression,
            string columnName,bool IsAscending = false,
           int PageSize=6 , int PageNumber=1)
        {
            IQueryable<T> query=this.set1.AsQueryable();
            if(expression!=null)
                query = query.Where(expression);
            if (!string.IsNullOrEmpty(columnName))
                query = query.OrderBy(columnName, IsAscending);
            //pagination PageSize , PageNumber
            if (PageNumber <= 0)
            {
                PageNumber = 1;
            }
            if (PageSize <= 0)
            {
                PageSize = 5;
            }
            int RowCount = query.Count();
            if (RowCount < PageSize)
            {
                PageSize = RowCount;
                PageNumber = 1;
            }
            int toskip=(PageNumber - 1)*(PageSize);
            query = query.Skip(toskip).Take(PageSize);
            return query;
        }
        public bool Add(T entity)
        {
            try
            {
                this.set1.Add(entity);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
               Console.WriteLine(ex.ToString());
                return false;
            }
         

            }
        public bool update(T entity)
        {
            try
            {
                this.set1.Update(entity);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public bool delete (T entity)
        {
            try
            {
                this.set1.Remove(entity);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public IQueryable<T> GetAll() { 
            return this.set1.AsQueryable();
                
        }

        }
}
