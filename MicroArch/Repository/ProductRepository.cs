using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Lesson_3.Abstraction;
using Lesson_3.Data;
using Lesson_3.Dto;
using Lesson_3.Models;

namespace Lesson_3.Repository
{
	public class ProductRepository(StorageContext storageContext, IMapper mapper, IMemoryCache memoryCache) : IProductRepository
	{
		private readonly StorageContext _storageContext = storageContext;
		private readonly IMapper _mapper = mapper;
		private readonly IMemoryCache _memoryCache = memoryCache;

        public int AddProduct(ProductDto productDto)
		{
			if (_storageContext.Products.Any(p => p.Name == productDto.Name))
				throw new Exception("Уже есть продукт с таким именем");

			var entity = _mapper.Map<Product>(productDto);
			_storageContext.Products.Add(entity);
			_storageContext.SaveChanges();
			_memoryCache.Remove("products");
			return entity.Id;
		}

		public void DeleteProduct(int id)
		{
			var product = _storageContext.Products.Find(id);
			if (product != null)
			{
				_storageContext.Products.Remove(product);
				_storageContext.SaveChanges();
				_memoryCache.Remove("products");
			}
		}

		public IEnumerable<ProductDto> GetAllProducts()
		{
			if (_memoryCache.TryGetValue("products", out List<ProductDto> listDto)) return listDto;
			listDto = _storageContext.Products.Select(p => _mapper.Map<ProductDto>(p)).ToList();
			_memoryCache.Set("products", listDto, TimeSpan.FromMinutes(30));
			return listDto;
		}
	}
}
