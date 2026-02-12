using CrazyCloset.Models;
using CrazyCloset.Repositories;

namespace CrazyCloset.Services
{
    public class InventoryService: IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository) 
        { 
            _inventoryRepository = inventoryRepository;
        }


        public async Task<List<ClothesItem>> GetAllClothesAsync() 
        {
            var allItems = await _inventoryRepository.GetAllClothesAsync();

            return allItems;
        }

        public async Task<ClothesItem> SaveClothesItem(ClothesItem item, IFormFile imageFile)
        {
            var fileName = $"{DateTime.Now.Ticks}.jpg"; 

            var path = Path.Combine(@"D:\Desktop\crazycloset_items","Items", fileName);

            await imageFile.CopyToAsync(new FileStream(path, FileMode.Create));

            item.FilePath = fileName;

            var savedItem = await _inventoryRepository.AddClothesItem(item);
            return savedItem;
        }


        public async Task DeleteClothesItemAsync(long id)
        {
            await _inventoryRepository.DeleteClothesItemAsync(id);
        }
    }
}
