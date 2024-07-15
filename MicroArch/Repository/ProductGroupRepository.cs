using AutoMapper;
using Lesson_3.Abstraction;
using Lesson_3.Data;
using Lesson_3.Dto;
using Lesson_3.Models;

namespace Lesson_3.Repository
{
	public class ProductGroupRepository : IProductGroupRepository
	{
		private readonly StorageContext _storageContext;
		private readonly IMapper _mapper;

		public ProductGroupRepository(StorageContext storageContext, IMapper mapper)
		{
			_storageContext = storageContext;
			_mapper = mapper;
		}

		public int AddProductGroup(ProductGroupDto productGroupDto)
		{
			if (_storageContext.ProductGroups.Any(p => p.Name == productGroupDto.Name))
				throw new Exception("Уже есть группа продуктов с таким именем");

			var entity = _mapper.Map<ProductGroup>(productGroupDto);
			_storageContext.ProductGroups.Add(entity);
			_storageContext.SaveChanges();
			return entity.Id;
		}

		public void DeleteProductGroup(int id)
		{
			var productGroup = _storageContext.ProductGroups.Find(id);
			if (productGroup != null)
			{
				_storageContext.ProductGroups.Remove(productGroup);
				_storageContext.SaveChanges();
			}
		}

		public IEnumerable<ProductGroupDto> GetAllProductGroups()
		{
			return _storageContext.ProductGroups.Select(pg => _mapper.Map<ProductGroupDto>(pg)).ToList();
		}
	}
}
