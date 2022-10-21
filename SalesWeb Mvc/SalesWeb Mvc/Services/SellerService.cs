using Microsoft.EntityFrameworkCore;
using SalesWeb_Mvc.Data;
using SalesWeb_Mvc.Models;
using SalesWeb_Mvc.Services.Exceptions;

namespace SalesWeb_Mvc.Services
{
    public class SellerService
    {
        private readonly SalesWeb_MvcContext _context;

        public SellerService(SalesWeb_MvcContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindaAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return  await _context.Seller
                .Include(obj => obj.Department)
                .FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == seller.Id);

            if (!hasAny)
            {
                throw new NotFoundException("ID not found!");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}