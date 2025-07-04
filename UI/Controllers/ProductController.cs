﻿using Logic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using UI.Authorization;

namespace UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet("getall")]
        [PermissionAuthorize("Product.View")]
        public async Task<IActionResult> GetAll()
        {
            ResponseDataDto<List<ProductDto>> response = new();
            response = await _productService.GetAllProductsAsync();

            if (!response.Completed)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost("create")]
        [PermissionAuthorize("Product.Create")]
        public async Task<IActionResult> Create(ProductDto product) 
        {
            ResponseDto response = new();
            response = await _productService.InsertProductAsync(product);

            if (!response.Completed)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
