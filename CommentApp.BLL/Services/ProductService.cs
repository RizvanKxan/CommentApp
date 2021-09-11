﻿using CommentApp.BLL.Interfaces;
using CommentApp.BLL.VMs.Product;
using CommentApp.DAL.Patterns;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommentApp.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork db;
        public ProductService(IUnitOfWork _db)
        {
            db = _db;
        }
        public async Task<Guid> CreateProductAsync(CreateProduct product)
        {
            try
            {
                var dbProduct = new Product()
                {
                    Name = product.Name,
                    Category = product.Category
                };
                dbProduct = await db.Products.CreateAsync(dbProduct);
                return dbProduct.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreateProduct> FindProductsByFunc(Func<Product, bool> func)
        {
            try
            {
                var dbProducts = db.Products.GetAll().Where(func).
                                                      Select(m =>
                                                      {
                                                          return new CreateProduct()
                                                          {
                                                              Category = m.Category,
                                                              Name = m.Name
                                                          };
                                                      }).ToList();
                return dbProducts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
