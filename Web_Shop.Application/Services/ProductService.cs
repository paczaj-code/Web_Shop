using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Application.DTOs;
using Web_Shop.Application.Services.Interfaces;
using Web_Shop.Persistence.UOW.Interfaces;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Application.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        public ProductService(ILogger<Product> logger,
                               ISieveProcessor sieveProcessor,
                               IOptions<SieveOptions> sieveOptions,
                               IUnitOfWork unitOfWork)
         : base(logger, sieveProcessor, sieveOptions, unitOfWork)
        {

        }

        //Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> IProductService.CreateNewProductAsync(GetSingleProductDTO dto)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> IProductService.UpdateExistingProductAsync(GetSingleProductDTO dto, ulong id)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> IProductService.VerifyPasswordByEmail(string email, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
