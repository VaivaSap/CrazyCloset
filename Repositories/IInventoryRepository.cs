using CrazyCloset.Models;

namespace CrazyCloset.Repositories
{
    public interface IInventoryRepository
    {
        Task<List<ClothesItem>> GetAllClothesAsync();
        Task<ClothesItem> AddClothesItem(ClothesItem item);
        Task<List<CategoryDto>> GetItemsByCategoryAsync();
        Task EditItemAsync(ClothesItem item); 
        Task<ClothesItem> GetClothesItemByIdAsync(long id);
        Task DeleteClothesItemAsync(long id);
        Task ItemCheckIn(UseLog log); 
        Task<List<UseLogDto>> GetUseLogsAsync();
        Task<List<UseLogDto>> GetAllLogsByIdAsync(long id);
        Task<List<ItemPopularityDto>> GetItemPopularity();
      
    }
}
