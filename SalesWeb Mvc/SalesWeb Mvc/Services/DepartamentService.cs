using SalesWeb_Mvc.Data;
using SalesWeb_Mvc.Models;

namespace SalesWeb_Mvc.Services
{
    public class DepartamentService
    {
        private readonly SalesWeb_MvcContext _context;

        public DepartamentService(SalesWeb_MvcContext context)
        {
            _context = context;
        }

        public List<Departament> FindAll()
        {
            return _context.Departament
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
