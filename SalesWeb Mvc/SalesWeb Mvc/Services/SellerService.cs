using Microsoft.EntityFrameworkCore;
using SalesWeb_Mvc.Data;
using SalesWeb_Mvc.Models;

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
                .Include(obj => obj.Departament)
                .FirstOrDefault(obj => obj.Id == id);                            
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}