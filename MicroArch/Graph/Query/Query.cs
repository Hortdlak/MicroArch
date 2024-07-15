using Lesson_3.Abstraction;
using Lesson_3.Dto;

namespace Lesson_3.Graph.Query
{
	public class Query
	{
		public IEnumerable<ProductDto> GetProducts([Service] IProductRepository productRepository) =>
			productRepository.GetAllProducts();

		public IEnumerable<ProductGroupDto> GetProductGroups([Service] IProductGroupRepository groupRepository) =>
			groupRepository.GetAllProductGroups();

		public IEnumerable<StorageDto> GetStorages([Service] IStorageRepository storageRepository) =>
			storageRepository.GetAllStorages();
	}
}
