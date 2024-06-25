using Infrastructure.Persistence.Entity;
using Infrastructure.Persistence.Repository.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Customers
{
    public class CustomersService
    {
        private CustomersRepository customersRepository;

        public CustomersService(CustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await customersRepository.GetAllAsync();
        }

        public async Task<List<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await customersRepository.GetAsync(predicate);
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await customersRepository.GetByIdAsync(id);
        }

        public async Task<Customer> Create(Customer customer)
        {
            await customersRepository.AddAsync(customer);
            await customersRepository.SaveAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            customersRepository.Update(customer);
            await customersRepository.SaveAsync();
            return customer;
        }

        public async Task Delete(int id)
        {
            await customersRepository.DeleteAsync(p => p.Id == id);
            await customersRepository.SaveAsync();
        }
    }
}
