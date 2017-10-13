using Product.Models;
using ProductService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.Net.Http;


namespace ProductInfo.Controllers
{
    [Route("api/[controller]")]
    public class ProductDetailsController:Controller //4.Using the infoservice defined in startup in the controller.
    {
        private readonly ProductDetailsContext _context;

        private IProductDetailsService _service;

        public ProductDetailsController(ProductDetailsContext context,IProductDetailsService service)
        {
            _context=context;
            _service=service;
        }

        [HttpGet]
        public Task<List<ProductDetails>> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}", Name = "GetProductDetails")]
        public Task<List<ProductDetails>> GetUsingId(int id)
        {
            return _service.GetUsingId(id);
        }

        [HttpPost] //Post method
        public Task Create([FromBody] ProductDetails item)
        {
            return _service.Create(item);
        }

        [HttpPut("{id}")] //Update method
        public Task Update(int id, [FromBody] ProductDetails item)
        {
            return _service.Update(id,item);
        }

        [HttpDelete("{id}")] //Delete Method
        public Task Delete(int id)
        {
            return _service.Delete(id);
        }

        public bool IsAlphaName(ProductDetails item)
        {
            return _service.IsAlphaName(item);
        }

        public bool IsNumericRate(ProductDetails item)
        {
            return _service.IsNumericRate(item);
        }

        public bool IsNumericGroupID(ProductDetails item)
        {
            return _service.IsNumericGroupID(item);
        }
    }
}