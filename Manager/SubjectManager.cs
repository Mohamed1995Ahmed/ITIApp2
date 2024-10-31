using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class SubjectManager : MainManager<Subject>
    {
        public SubjectManager(ProjectContext _context) : base(_context)
        {
        }
    }
}
