using Microsoft.AspNetCore.Mvc;
using Lesson_3.Dto;
using Lesson_3.Models;


namespace Lesson_3.Abstraction
{
	public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        int AddProduct(ProductDto productDto);
        void DeleteProduct(int id);
    }
}
