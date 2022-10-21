using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Departament>> FindAllAsync()
        {
            return await _context.Departament
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
