using OnlineShopping.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        IGenericRepository<ShopOrder> ShopOrders { get; }
        IGenericRepository<Payment> Payments { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Delivery> Deliveries { get; }
        IGenericRepository<Category> Categories { get; }
    }
}
