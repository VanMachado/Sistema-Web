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

        public List<Seller> FindaAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Seller.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller
                .Include(obj => obj.Department)
                .FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Seller seller)
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id))
            {
                throw new NotFoundException("ID not found!");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}