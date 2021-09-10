using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApp_mvc.Moddels
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }


        //====================================================
        //bhad lmethod kat9der dir insert l intial data f tabel employees

        /*
          f package manger console dir
            command :
            1 : Add-Migration chosingName
            2 : update-database 
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //hadchi ghir khtisar l dackchi li lta7t
            ModelbuilderExtensions.Seed(modelBuilder);

            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee
            //    {
            //        Id = 1,
            //        Name = "Mary",
            //        Department = Dept.IT,
            //        Email = "mary@gmail.com"
            //    },
            //    new Employee
            //    {
            //        Id = 2,
            //        Name = "Jhon",
            //        Department = Dept.HR,
            //        Email = "Jhon@gmail.com"
            //    }
            //);
        }
    }
}
