using CompanyCase.Services.Product.API.Dtos;
using CompanyCase.Shared.Dtos;

namespace CompanyCase.Services.Product.API.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}