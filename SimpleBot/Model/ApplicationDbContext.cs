using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot.Model
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<TargetImage> TargetImages { get; set; }
    }
}
