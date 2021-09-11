using CommentApp.BLL.VMs.Product;
using CommentApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentApp.BLL.Interfaces
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(CreateProduct product);
        List<CreateProduct> FindProductsByFunc(Func<Product, bool> func);
    }
}
