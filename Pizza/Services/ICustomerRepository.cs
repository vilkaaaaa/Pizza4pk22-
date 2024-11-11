using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Models;

namespace Pizza.Services
{
    internal interface ICustomerRepository
    {
        //получать список всех пользователей
        Task<List<Customer>> GetCustomersAsync();
        //получать пользователя по id
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        //обновлять пользователя
        Task<Customer> UpdateCustomerAsync(Customer customer);
        //удалять пользователя
        Task DeleteCustomerAsync(Guid customerId);
        //создавать пользователя
        Task<Customer> CreateCustomerAsync(Customer customer);
    }
}
