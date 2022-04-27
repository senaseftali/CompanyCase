﻿using CompanyCase.Services.Product.API.Dtos;
using CompanyCase.Shared.Dtos;

namespace CompanyCase.Services.Product.API.Services
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();

        Task<Response<ProductDto>> GetByIdAsync(string id);

        Task<Response<List<ProductDto>>> GetAllByUserIdAsync(string userId);

        Task<Response<ProductDto>> CreateAsync(ProductCreateDto courseCreateDto);

        Task<Response<NoContent>> UpdateAsync(ProductUpdateDto courseUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
