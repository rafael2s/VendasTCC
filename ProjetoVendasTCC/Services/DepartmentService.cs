using ProjetoVendasTCC.Data;
using ProjetoVendasTCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjetoVendasTCC.Services
{
    public class DepartmentService
    {
        private readonly ProjetoVendasTCCContext _context;

        public DepartmentService(ProjetoVendasTCCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
