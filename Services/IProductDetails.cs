using System;
using Product.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;

namespace ProductService
{
    public interface IProductDetailsService
    {
        Task<List<ProductDetails>> GetAll();
        Task<List<ProductDetails>> GetUsingId(int id);
        Task Create([FromBody] ProductDetails item);
        Task Update(int id, [FromBody] ProductDetails item);
        Task Delete(int id);
        bool IsAlphaName(ProductDetails item);
        bool IsNumericRate(ProductDetails item);
        bool IsNumericGroupID(ProductDetails item);
    }
}