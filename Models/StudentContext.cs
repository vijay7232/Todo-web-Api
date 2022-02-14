using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace TodoApi
{
    public class StudentContext : DbContext
    {

        public StudentContext (DbContextOptions<StudentContext> options)
        : base(options)
        {

        }

        public DbSet<StudentDetail> StudentDetails {get; set;} = null!;
    }
}