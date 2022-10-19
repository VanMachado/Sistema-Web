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
            obj.Departament = _context.Departament.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}