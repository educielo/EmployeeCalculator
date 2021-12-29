using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services
{
    public interface IEmployeeService : IService<Employee>
    {
        public Task<List<Employee>> GetAllActive();
    }
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private readonly DbContext _context;
        public EmployeeService(SproutDBContext context)
            :base(context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllActive()
        {
            return await Filter(a => a.IsDeleted == false).ToListAsync();
        }
    }
}
