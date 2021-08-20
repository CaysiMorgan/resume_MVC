using System;
using System.Collections.Generic;

namespace resume_MVC.Controllers
{
    internal class DemoDataBaseEntities
    {
        public IEnumerable<object> Company_Users { get; internal set; }

        internal int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
} 