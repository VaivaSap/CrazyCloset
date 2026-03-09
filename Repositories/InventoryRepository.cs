using CrazyCloset.Data;
using CrazyCloset.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyCloset.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClothesItem>> GetAllClothesAsync()
        {
            return await _context.ClothesItems.ToListAsync();
        }

        public async Task<List<CategoryDto>> GetItemsByCategoryAsync()
        {
            var categoryCounts = await _context.ClothesItems
                .GroupBy(i => i.Category)
                .Select(g => new CategoryDto { Category = g.Key, Count = g.Count() })
                .ToListAsync();

            return categoryCounts;
        }

        public async Task<List<UseLogDto>> GetUseLogsAsync()
        {
            return await _context.UseLogs.Include(u => u.Item).Select(u => new UseLogDto
                {
                    UseLogId = u.UseLogId,
                    UsedDate = u.UsedDate,
                    ItemName = u.Item.Name,
                    FilePath = u.Item.FilePath
            }).ToListAsync();
        }

        public async Task<ClothesItem> GetClothesItemByIdAsync(long id)
        {
            var item = await _context.ClothesItems.FindAsync(id);

            if (item == null) 
            { 
               throw new Exception($"Item with id {id} not found.");
            }
             
            return item;
        }


        public async Task<List<UseLogDto>> GetAllLogsByIdAsync(long id)
        {
            var itemUseLogs = await _context.UseLogs.Where(u => u.ItemId == id).Select(u => new UseLogDto
            {
                UseLogId = u.UseLogId,
                UsedDate = u.UsedDate,
                ItemName = u.Item.Name
            }).ToListAsync();

            return itemUseLogs;
        }

      
         public async Task<List<ItemPopularityDto>> GetItemPopularity()
        {
            var popularityList = await _context.UseLogs
                .GroupBy(u => new { u.ItemId, u.Item.Name, u.Item.FilePath })
                .Select(g => new ItemPopularityDto
                {
                    ItemId = g.Key.ItemId,
                    Name = g.Key.Name,
                    FilePath = g.Key.FilePath,
                    WearCount = g.Count()
                }).OrderByDescending(x => x.WearCount).ToListAsync();

            return popularityList;
        }

        public async Task<ClothesItem> AddClothesItem(ClothesItem item) 
        { 
            await _context.ClothesItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task EditItemAsync(ClothesItem item)
        {
            var existingItem = await _context.ClothesItems.FindAsync(item.Id);
            
            if (existingItem == null) 
            { 
                throw new Exception($"Item not found."); 
            } 
            
            existingItem.Name = item.Name; 
            existingItem.Description = item.Description;
            existingItem.ArrivedDate = item.ArrivedDate;
            existingItem.Category = item.Category; 
            existingItem.Size = item.Size;

            if (item.FilePath != null) existingItem.FilePath = item.FilePath;

            _context.ClothesItems.Update(existingItem); 
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClothesItemAsync(long id)
        {
            var item = await GetClothesItemByIdAsync(id);
            _context.Remove(item);  
            await _context.SaveChangesAsync();
        }

        public async Task ItemCheckIn(UseLog log)
        {
            bool loggedToday = await _context.UseLogs.AnyAsync(l => l.ItemId == log.ItemId && l.UsedDate == DateOnly.FromDateTime(DateTime.Now));
            if (loggedToday) { return;}

            await _context.UseLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
    }
}
