using CrazyCloset.Models;

namespace CrazyCloset.Repositories
{
    public class InventoryRepository
    {
        public async Task<ClothesItem> GetClothesByIdAsync(long id) 
        {
            return null;
        }
        public async Task<List<ClothesItem>> GetAllClothesAsync() 
        {
            return null;
        }
        public async Task<ShoesItem> GetShoesByIdAsync(long id) 
        { 
            return null;
        }
        public async Task<List<ShoesItem>> GetAllShoesAsync() 
        { 
            return null;
        }
        public async Task<AccessoriesItem> GetAccessoriesByIdAsync(long id) 
        { 
            return null;
        }
        public async Task<AccessoriesItem> GetAccessoriesByIdAsync()
        {
            return null;
        }

        public async Task<ClothesItem> AddClothesItem(long id) 
        { return null; }
        public async Task<ClothesItem> SaveClothesItem(long id) 
        { return null; }
        public async Task<ClothesItem> LoadClothesItem(long id) 
        { return null; }
    }
}
