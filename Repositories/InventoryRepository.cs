using CrazyCloset.Data;
using CrazyCloset.Models;
using Microsoft.EntityFrameworkCore;

namespace CrazyCloset.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private ApplicationDbContext _context;

        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClothesItem>> GetAllClothesAsync()
        {
            return await _context.ClothesItems.ToListAsync();
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

        public async Task<ClothesItem> AddClothesItem(ClothesItem item) 
        { 
            await _context.ClothesItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteClothesItemAsync(long id)
        {
            var item = await GetClothesItemByIdAsync(id);
            _context.Remove(item);  
            await _context.SaveChangesAsync();
        }
    }
}
