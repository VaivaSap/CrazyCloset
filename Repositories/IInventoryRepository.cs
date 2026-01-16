using CrazyCloset.Models;

namespace CrazyCloset.Repositories
{
    public interface IInventoryRepository
    {
        Task<ClothesItem> GetClothesByIdAsync(long id);
        Task<List<ClothesItem>> GetAllClothesAsync();
        Task<ShoesItem> GetShouesByIdAsync(long id);
        Task<List<ShoesItem>> GetAllShoesAsync();
        Task<AccessoriesItem> GetAccessoriesByIdAsync(long id);
        Task<AccessoriesItem> GetAccessoriesByIdAsync();
    }
}
