using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class PuplisherManager : MainManager<Publisher>
    {
        public PuplisherManager(ProjectContext _context) : base(_context)
        {
        }
    }
}
