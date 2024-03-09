using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using Web_Shop.Application.DTOs;
using Web_Shop.Application.Services.Interfaces;
using Web_Shop.Persistence.UOW.Interfaces;
using Web_Shop.Application.Mappings;
using Sieve.Models;
using Web_Shop.Application.Helpers.PagedList;
using WWSI_Shop.Persistence.MySQL.Model;
using Web_Shop.Application.Services;

namespace Web_Shop.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("list")]
        [SwaggerOperation(OperationId = "GetProducts")]
        public async Task<ActionResult<IPagedList<GetSingleProductDTO>>> GetProducts([FromQuery] SieveModel paginationParams)
        {
            var result = await _productService.SearchAsync(paginationParams, resultEntity => DomainToDtoMapper.MapGetSingleProductDTO(resultEntity));

            if (!result.IsSuccess)
            {
                return Problem(statusCode: (int)result.StatusCode, title: "Read error.", detail: result.ErrorMessage);
            }

            return Ok(result.entityList);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(OperationId = "GetCustomerById")]
        public async Task<ActionResult<GetSingleProductDTO>> GetCustomer(ulong id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (!result.IsSuccess)
            {
                return Problem(statusCode: (int)result.StatusCode, title: "Read error.", detail: result.ErrorMessage);
            }

            return StatusCode((int)result.StatusCode, result.entity!.MapGetSingleProductDTO());
        }
    }
}
