using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Application.DTOs;
using WWSI_Shop.Persistence.MySQL.Model;

namespace Web_Shop.Application.Services.Interfaces
{
    public interface IProductService : IBaseService<Product>

    {
        //Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> CreateNewProductAsync(GetSingleProductDTO dto);
        //Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> UpdateExistingProductAsync(GetSingleProductDTO dto, ulong id);
        //Task<(bool IsSuccess, Product? entity, HttpStatusCode StatusCode, string ErrorMessage)> VerifyPasswordByEmail(string email, string password);
    }
}
