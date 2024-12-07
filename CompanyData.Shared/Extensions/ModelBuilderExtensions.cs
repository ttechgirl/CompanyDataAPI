using CompanyData.Shared.Models;
using CompanyDataAPI.Enum;
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
            builder.Entity<Department>().HasData(
                new Department
                {
                    Id = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                    Name = "Engineering & Product", 
                    Supervisor = "paul@company.com",
                },
                new Department
                {
                    Id = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                    Name ="Marketing & Sales",
                    Supervisor = "Adex@company.com",

                }
            );

            builder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.Parse("ACC627BB-7733-4E13-876E-7D49A3838C12"),
                    DepartmentId = Guid.Parse("43738933-acf0-4479-8624-0ef1bec0383d"),
                    LastName = "Paul",
                    FirstName = "Isaac",
                    PhoneNumber = "+1312754448",
                    Email = "paul@company.com",
                    JobRole = "Tech Lead", 
                    WagesInDollar = 4500,
                    Address = "8,Mesa Road",
                    City = "Houston",
                    State = "Texas",
                    Gender = Gender.FEMALE

                },
                new Employee
                {
                    Id = Guid.Parse("D17D52BD-9178-41D1-B399-705F6B7899B9"),
                    DepartmentId = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                    LastName = "Evans",
                    FirstName = "Cherri",
                    MiddleName = "Beauty",
                    PhoneNumber = "07027544487",
                    Email = "cherry@company.com",
                    JobRole = "Media",
                    WagesInDollar = 2500,
                    Address = "12,ogunnaike street GRA",
                    City = "Ikeja",
                    State = "Lagos",
                    Gender = Gender.FEMALE
                },
                new Employee
                {
                    Id = Guid.Parse("7713BF21-9E81-4949-ABF7-D5A64F281D69"),
                    DepartmentId = Guid.Parse("6c7e9c5d-89ae-43d9-8f19-feb71af65e8f"),
                    LastName = "Adex",
                    FirstName = "Michael",
                    MiddleName = null,
                    PhoneNumber = "0907794487",
                    Email = "Adex@company.com",
                    JobRole = "Media Lead",
                    WagesInDollar = 5500,
                    Address = "30 Alpha estate lekki",
                    City = "Ikeja",
                    State = "Lagos",
                    Gender = Gender.MALE
                }
            );
        }
    }
}
