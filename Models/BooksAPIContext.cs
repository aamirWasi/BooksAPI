using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Models
{
    public class BooksAPIContext:DbContext
    {
        public BooksAPIContext(DbContextOptions<BooksAPIContext> options)
            :base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
