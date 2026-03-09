using CrazyCloset.Models;

namespace CrazyCloset.Services
{
    public interface IInventoryService
    {
        Task<List<ClothesItem>> GetAllClothesAsync();
        Task<List<CategoryDto>> GetItemsByCategoryAsync();
        Task<ClothesItem> SaveClothesItem(ClothesItem item, IFormFile imageFile);
        Task EditItemAsync(ClothesItem item, IFormFile? imageFile);
        Task DeleteClothesItemAsync(long id);
        Task ItemCheckIn(UseLog log);
        Task<List<UseLogDto>> GetUseLogsAsync();
        Task<List<UseLogDto>> GetAllLogsByIdAsync(long id);
        Task<List<ItemPopularityDto>> GetItemPopularity();

    }
}
