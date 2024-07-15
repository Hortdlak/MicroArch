using Lesson_3.Dto;
using Lesson_3.Models;

namespace Lesson_3.Abstraction
{
	public interface IProductGroupRepository
	{
		IEnumerable<ProductGroupDto> GetAllProductGroups();
		int AddProductGroup(ProductGroupDto productGroupDto);
		void DeleteProductGroup(int id);
	}
}
