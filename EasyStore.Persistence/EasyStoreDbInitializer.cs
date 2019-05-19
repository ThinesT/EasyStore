using System;
using System.Linq;
using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using EasyStore.Domain.ValueObjects;

namespace EasyStore.Persistence
{
    public class EasyStoreDbInitializer
    {
        public static void Initialize(EasyStoreDbContext context)
        {
            var initialize = new EasyStoreDbInitializer();
            initialize.SeedAll(context);
        }

        private void SeedAll(EasyStoreDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                // Db has been seeded
                return;
            }
            SeedCustomers(context);
            SeedProducts(context);
        }

        private void SeedProducts(EasyStoreDbContext context)
        {
            var products = new[]
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Product1",
                    Price = new Money(100),
                    ProductDescription = "Description of the product 1"

                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Product2",
                    Price = new Money(200),
                    ProductDescription = "Description of the product 2"

                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Product3",
                    Price = new Money(300),
                    ProductDescription = "Description of the product 3"

                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Product4",
                    Price = new Money(400),
                    ProductDescription = "Description of the product 4"

                }

            };

            context.AddRange(products);
            context.SaveChanges();
        }

        // Seeding  customers
        private void SeedCustomers(EasyStoreDbContext context)
        {
            var customers = new[]
            {
               new Customer {
                             CustomerId = 1, 
                             Address = new Address("Address 1", "Address 2", "Stockholm", "email@email.com", "Sweden", "14576"),
                             FirstName = "FirstName 1",
                             LastName = "LastName 2",
                             Phone = "0756353738"
                             },
               new Customer {
                             CustomerId = 2,
                             Address = new Address("Address 2", "Address 3", "Oslo", "email1@email.com", "Norway", "14376"),
                             FirstName = "FirstName 2",
                             LastName = "LastName 3",
                             Phone = "0756353745"
                             },
               new Customer {
                             CustomerId = 3,
                             Address = new Address("Address 3", "Address 4", "Washington", "email2@email.com", "USA", "198736"),
                             FirstName = "FirstName 4",
                             LastName = "LastName 5",
                             Phone = "0794587655"
                             },



            };
            context.AddRange(customers);
            context.SaveChanges();
        }
    }
}
