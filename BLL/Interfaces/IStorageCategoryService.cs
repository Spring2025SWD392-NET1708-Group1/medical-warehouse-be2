using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStorageCategoryService
    {
        Task<IEnumerable<StorageCategoryViewDTO>> GetAllStorageCategoriesAsync();
        Task<StorageCategoryViewDTO?> GetStorageCategoryByIdAsync(int id);
        Task<StorageCategoryViewDTO> CreateStorageCategoryAsync(StorageCategoryCreateDTO createDTO);
        Task<bool> UpdateStorageCategoryAsync(int id, StorageCategoryUpdateDTO updateDTO);
        Task<bool> DeleteStorageCategoryAsync(int id);
    }
}
