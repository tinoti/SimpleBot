using SimpleBot.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBot
{
    class DatabaseHelper
    {

        ApplicationDbContext _context;

        DatabaseHelper()
        {
            _context = new ApplicationDbContext();
        }

        public static void WriteTargetImageToDatabase(string imgTargetPath)
        {

        }
    }
}
