using PluralsightAndBooksManager.Core;
using System.Data.Entity;

namespace PluralsightAndBooksManager.Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<CourseMaterial> Courses { get; set; }
    }
}
