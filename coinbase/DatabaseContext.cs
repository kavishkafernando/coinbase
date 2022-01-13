using coinbase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coinbase
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }
    }
}
