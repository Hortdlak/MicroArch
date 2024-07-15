using Lesson_3.Dto;
using Lesson_3.Models;
using AutoMapper;

namespace Lesson_3.Mapper
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Product, ProductDto>().ReverseMap();
			CreateMap<ProductGroup, ProductGroupDto>().ReverseMap();
			CreateMap<Storage, StorageDto>().ReverseMap();
		}
	}
}
