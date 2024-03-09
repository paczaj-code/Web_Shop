using System;
using Bogus;

using WWSI_Shop.Persistence.MySQL.Context;
using WWSI_Shop.Persistence.MySQL.Model;
using Microsoft.EntityFrameworkCore;



namespace Web_Shop.Persistence.MySQL.Services
{
    public class DataGenerator
    {
        private readonly WwsishopContext _dbContext;
        private readonly string locale = "pl";

        public DataGenerator(WwsishopContext context)
        {
            _dbContext = context;

        }

        public void SeedCustomer()
        {
 
            Randomizer.Seed = new Random(600);

            _dbContext.Database.ExecuteSql($"DELETE FROM Customer");
            _dbContext.Database.ExecuteSql($"ALTER TABLE Customer AUTO_INCREMENT = 1;");

            var customerGenerator = new Faker<Customer>(locale)
                .RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.Surname, f => f.Person.LastName)
                .RuleFor(c => c.Email, f => f.Person.Email)
                .RuleFor(c => c.PasswordHash, f => f.Lorem.Word())
                .RuleFor(c => c.BirthDate, f => f.Date.BetweenDateOnly(new DateOnly(1970, 1, 1), new DateOnly(2010, 1, 1)));


            var customer = customerGenerator.Generate(200);
            _dbContext.AddRange(customer);
            _dbContext.SaveChanges();
        }

        public void SeedProduct()
        {
            Randomizer.Seed = new Random(600);

            _dbContext.Database.ExecuteSql($"DELETE FROM Product");
            _dbContext.Database.ExecuteSql($"ALTER TABLE Product AUTO_INCREMENT = 1;");

            var productGenerator = new Faker<Product>(locale)
                .RuleFor(c => c.Name, f => string.Join(" ", f.Lorem.Words(2)))
                .RuleFor(c => c.Description, f => f.Lorem.Sentences(5))
                .RuleFor(c => c.Price, f => f.Random.Decimal(1, 1000))
                .RuleFor(c => c.Sku, f => f.Commerce.Ean8());

            var product = productGenerator.Generate(100);
            _dbContext.AddRange(product);
            _dbContext.SaveChanges();
        }






    }
}
