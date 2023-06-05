using CompanyData.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyData.Shared.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Company>().HasData(
               new Company
               {
                   //foreign key
                   Id = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                   Address = "8,Mesa Road",
                   City ="Houston",
                   State = "Texas",
                   //Employees = new List<Employee>
                   //{
                   //   new Employee
                   //   {
                   //       Id=1,
                   //       CompanyId = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                   //       LastName = "Paul",
                   //       FirstName = "Isaac",
                   //       PhoneNumber = "08027544487",
                   //       Department = "Digital",
                   //       JobRole = "Lead",
                   //       Wages_perhour = 45
                   //   }
                   //}
               },
              new Company
              {
                  //foreign key
                  Id = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                  Address = "12,ogunnaike street GRA",
                  City = "Ikeja",
                  State = "Lagos",
                  //Employees = new List<Employee>
                  //{
                  //    new Employee
                  //    {
                  //       Id = 2,
                  //       CompanyId = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                  //       LastName= "Evans",
                  //       FirstName="Cherri",
                  //       MiddleName="Beauty",
                  //       PhoneNumber= "07027544487",
                  //       Department ="Digital",
                  //       JobRole="Media",
                  //       Supervisor= Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                  //       Wages_perhour = 25
                  //    }
                  //}
              });

            builder.Entity<Employee>().HasData(
              new Employee
              {
                  Id = Guid.NewGuid(),
                  CompanyId = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                  LastName = "Paul",
                  FirstName = "Isaac",
                  PhoneNumber = "+1312754448",
                  Email = "digitalteam@gmail.com",
                  Department = "Digital",
                  JobRole = "Lead",
                  WagesInDollar = 4500
              },
            new Employee
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                LastName = "Evans",
                FirstName = "Cherri",
                MiddleName = "Beauty",
                PhoneNumber = "07027544487",
                Email ="paulI@gmail.com",
                Department = "Digital",
                JobRole = "Media",
                Supervisor = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                WagesInDollar = 2500
            });
        }
    }
}
