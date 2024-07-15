using Lesson_3.Dto;

namespace Lesson_3.Abstraction
{
	public interface IStorageRepository
	{
		IEnumerable<StorageDto> GetAllStorages();
		int AddStorage(StorageDto storageDto);
		void UpdateStorageCount(int storageId, int count);
		void DeleteStorage(int id);
	}
}
