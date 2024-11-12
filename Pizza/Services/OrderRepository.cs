using Microsoft.EntityFrameworkCore;
using Pizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pizza.Services
{
    internal class OrderRepository :IOrderRepository
    {
        private readonly PizzaDbkozlovtsevContext _context 
            = new PizzaDbkozlovtsevContext();

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(long orderId)
        {
            using (TransactionScope scope = new TransactionScope()) 
            { 
                var order = _context.Orders.Include("OrderItems")
                    .Include("OrderItems.OrderItemsOptions")
                    .FirstOrDefault(o => o.Id == orderId); 

                if (order != null) 
                { 
                    foreach (OrderItem item in order.OrderItems)
                    {
                        foreach(var itemOpt in item.OrderItemOptions)
                        {
                            _context.OrderItemOptions.Remove(itemOpt);
                        }
                        _context.OrderItems.Remove(item);
                    }
                    _context.Orders.Remove(order);
                }

                await _context.SaveChangesAsync();
                scope.Complete();
            }
        }

        public Task<List<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderStatus>> GetAllOrderStatusesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductOption>> GetAllProductOptionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductSize>> GetAllProductSizesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByCustomerAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Order> UpdateOrderAsync(long orderId)
        {
            throw new NotImplementedException();
        }
    }
}
