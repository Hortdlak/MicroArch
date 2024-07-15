using Lesson_3.Dto;
using Lesson_3.Models;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Lesson_3.Data;
using System.Collections.Generic;
using System.Linq;
using Lesson_3.Abstraction;

namespace Lesson_3.Repository
{
	public class StorageRepository : IStorageRepository
	{
		private readonly StorageContext _storageContext;
		private readonly IMapper _mapper;

		public StorageRepository(StorageContext storageContext, IMapper mapper)
		{
			_storageContext = storageContext;
			_mapper = mapper;
		}

		public IEnumerable<StorageDto> GetAllStorages()
		{
			return _storageContext.Storages.Select(s => _mapper.Map<StorageDto>(s)).ToList();
		}

		public int AddStorage(StorageDto storageDto)
		{
			var entity = _mapper.Map<Storage>(storageDto);
			_storageContext.Storages.Add(entity);
			_storageContext.SaveChanges();
			return entity.Id;
		}

		public void UpdateStorageCount(int storageId, int count)
		{
			var storage = _storageContext.Storages.Find(storageId);
			if (storage != null)
			{
				storage.Count = count;
				_storageContext.SaveChanges();
			}
		}

		public void DeleteStorage(int id)
		{
			var storage = _storageContext.Storages.Find(id);
			if (storage != null)
			{
				_storageContext.Storages.Remove(storage);
				_storageContext.SaveChanges();
			}
		}
	}
}
