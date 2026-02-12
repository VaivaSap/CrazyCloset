using CrazyCloset.Models;

namespace CrazyCloset.Services
{
    public interface IInventoryService
    {
        Task<List<ClothesItem>> GetAllClothesAsync();
        Task<ClothesItem> SaveClothesItem(ClothesItem item, IFormFile imageFile);

        Task DeleteClothesItemAsync(long id);
    }
}
