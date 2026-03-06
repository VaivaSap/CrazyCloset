using CrazyCloset.Models;
using CrazyCloset.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

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

        public async Task<List<UseLogDto>> GetUseLogsAsync()
        {
            var allLogs = await _inventoryRepository.GetUseLogsAsync();
            return allLogs;
        }

        public async Task<List<UseLogDto>> GetAllLogsByIdAsync(long id)
        {
            var itemUseLogs = await _inventoryRepository.GetAllLogsByIdAsync(id);
            return itemUseLogs;
        }

        public async Task<ClothesItem> SaveClothesItem(ClothesItem item, IFormFile imageFile)
        {
            var fileName = $"{DateTime.Now.Ticks}.jpg"; 

            var path = Path.Combine(@"D:\Desktop\crazycloset_items","Items", fileName);

            using var image = await Image.LoadAsync(imageFile.OpenReadStream());
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(800, 800),
                Mode = ResizeMode.Max
            }));
            await image.SaveAsJpegAsync(path, new JpegEncoder { Quality = 80 });

            item.FilePath = fileName;

            var savedItem = await _inventoryRepository.AddClothesItem(item);
            return savedItem;
        }

        public async Task EditItemAsync(ClothesItem item, IFormFile? imageFile)
        {
            if (imageFile != null)
            {
                var fileName = $"{DateTime.Now.Ticks}.jpg";
                var path = Path.Combine(@"D:\Desktop\crazycloset_items", "Items", fileName);

                using var image = await Image.LoadAsync(imageFile.OpenReadStream());
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new Size(800, 800),
                    Mode = ResizeMode.Max
                }));
                await image.SaveAsJpegAsync(path, new JpegEncoder { Quality = 80 });

                item.FilePath = fileName;
            }

            await _inventoryRepository.EditItemAsync(item);
        }

        public async Task DeleteClothesItemAsync(long id)
        {
            await _inventoryRepository.DeleteClothesItemAsync(id);
        }

        public async Task ItemCheckIn(UseLog log) 
        { 
            await _inventoryRepository.ItemCheckIn(log); 
        }

        public async Task<List<ItemPopularityDto>> GetItemPopularity()
        {
            var popularityList = await _inventoryRepository.GetItemPopularity();
            return popularityList;
        }
    }
}
