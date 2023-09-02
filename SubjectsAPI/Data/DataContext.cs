using Microsoft.EntityFrameworkCore;

namespace SubjectsAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Subject> Subjects => Set<Subject>();
    }
}
