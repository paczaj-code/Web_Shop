using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Web_Shop.Application.Services.Interfaces;
using Web_Shop.Persistence.MySQL.Services;
using WWSI_Shop.Persistence.MySQL.Context;
using System.Linq;
using System;
using WWSI_Shop.Persistence.MySQL.Model;
using Web_Shop.Application.DTOs;
using Web_Shop.Persistence.MySQL.Model;

namespace Web_Shop.RestAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FakeDataController : ControllerBase
    {
        private readonly WwsishopContext _dbContext;
        private readonly ILogger<CustomerController> _logger;
        private readonly DataGenerator _dataGenerator;

     
       

        public FakeDataController(ILogger<CustomerController> logger, WwsishopContext context, DataGenerator dataGenerator)
        {
            _dbContext = context;
            _logger = logger;
            _dataGenerator = dataGenerator;
        }

        [HttpPost("customers")]
        [SwaggerOperation(OperationId = "SeedCustomers")]
        public FakerResponse SeedCustomers()
        {


            _dataGenerator.SeedCustomer();
            IQueryable<Customer> records = _dbContext.Customers;
            var count = records.Count();

           

            return new FakerResponse() { recordCount = count , textResponse="Poprawnie wstawiono do encji Customer"};

        }

        [HttpPost("produts")]
        [SwaggerOperation(OperationId = "SeedProducts")]
        public  FakerResponse SeedProducts()
        {


            _dataGenerator.SeedProduct();
            IQueryable<Product> records = _dbContext.Products;
            var count =  records.Count();

            return new FakerResponse() { recordCount = count, textResponse = "Poprawnie wstawiono do encji Product" };

        }


       
    }
}
