using CrazyCloset.Models;

namespace CrazyCloset.Repositories
{
    public interface IInventoryRepository
    {
        Task<List<ClothesItem>> GetAllClothesAsync();
        Task<ClothesItem> AddClothesItem(ClothesItem item);

        Task DeleteClothesItemAsync(long id);
        Task<ClothesItem> GetClothesItemByIdAsync(long id);
    }
}
