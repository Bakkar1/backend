using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp_mvc.Moddels
{
    public class AppDbContext : IdentityDbContext
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
            //yla jak had l error mnin tbghi dir migration zid base.OnModelCreating(modelBuilder);
            //The entity type 'IdentityUserLogin<string>' requires a primary key to be defined. If you intended to use a keyless entity type, call 'HasNoKey' in 'OnModelCreating'. For more information on keyless entity types, see https://go.microsoft.com/fwlink/?linkid=2141943.
            base.OnModelCreating(modelBuilder);

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
