﻿using OnlineShopping.Server.Data;
using OnlineShopping.Server.IRepository;
using OnlineShopping.Server.Models;
using OnlineShopping.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShopping.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Brand> _brands;
        private IGenericRepository<Product> _products;
        private IGenericRepository<OrderItem> _orderItems;
        private IGenericRepository<ShopOrder> _shopOrders;
        private IGenericRepository<Payment> _payments;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<Delivery> _deliveries;
        private IGenericRepository<Category> _categories;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IGenericRepository<Brand> Brands => _brands ??= new GenericRepository<Brand>(_context);
        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(_context);
        public IGenericRepository<OrderItem> OrderItems => _orderItems ??= new GenericRepository<OrderItem>(_context);
        public IGenericRepository<ShopOrder> ShopOrders => _shopOrders ??= new GenericRepository<ShopOrder>(_context);
        public IGenericRepository<Payment> Payments => _payments ??= new GenericRepository<Payment>(_context);
        public IGenericRepository<Customer> Customers => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Staff> Staffs => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<Delivery> Deliveries => _deliveries ??= new GenericRepository<Delivery>(_context);
        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            //string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            //foreach (var entry in entries)
            //{
            //    ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
            //    ((BaseDomainModel)entry.Entity).UpdatedBy = user;
            //    if (entry.State == EntityState.Added)
            //    {
            //        ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
            //        ((BaseDomainModel)entry.Entity).CreatedBy = user;
            //    }
            //}

            await _context.SaveChangesAsync();
        }
    }
}
