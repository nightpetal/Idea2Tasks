using Idea2Tasks.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Idea2Tasks.Backend.Data
{
    public class AppDb : DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
    }
}