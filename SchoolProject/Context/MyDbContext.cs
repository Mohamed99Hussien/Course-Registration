using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SchoolProject.Context
{
    public class MyDbContext : DbContext
    {
        internal object std;

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<Students> StudentsTable { get; set; }
        public DbSet<Teacher> TeachersTable { get; set; }
        public DbSet<Room> RoomsTable { get; set; }
        public DbSet<Course> CoursesTable { get; set; }
        public DbSet<StudentCourse> StudentCourseTable { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) {

            base.OnConfiguring(dbContextOptionsBuilder);
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            var conString = config.GetConnectionString("MyConnection");
            dbContextOptionsBuilder.UseSqlServer(conString);

        }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
        }
    }
}
