using Product.Models;
using ProductService;
using Microsoft.EntityFrameworkCore;//To integrate database with webapi
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; //For using task and asynchronous feature in webapi
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductGroupController:Controller
    {
        //private readonly ProductContext _context;

        private IProductGroupService _service;

        public ProductGroupController(/*ProductContext context*/IProductGroupService service)
        {
           // _context=context;
            _service=service;
        }

        [HttpGet]
        public Task<List<ProductGroup>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}", Name = "GetProductGroup")]
        public Task<List<ProductGroup>> GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost] //Post method
        public Task Create([FromBody] ProductGroup item)
        {
            return _service.Create(item);
        }

        [HttpPut("{id}")] //Update method
        public Task Update(int id, [FromBody] ProductGroup item)
        {
            return _service.Update(id,item);
        }

        [HttpDelete("{id}")] //Delete Method
        public Task Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}       