using DLL.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly northwindContext _context;

        public CustomerRepository(northwindContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            if (!customers.Any()) return Enumerable.Empty<Customer>();
            return customers;
        }
    }
}
