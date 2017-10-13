using System;
using Product.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProductService
{
    public class GroupMethods:IProductGroupService
    {
        private readonly ProductDetailsContext _context;

        public GroupMethods(ProductDetailsContext context)
        {
            _context=context;
        }


        [HttpGet]
        public async Task<List<ProductGroup>> Get()
        {
            return await _context.ProductGroupTable.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetProductGroup")]
        public async Task<List<ProductGroup>> GetById(int id)
        {
            ProductGroup objProductGroup= await _context.ProductGroupTable.FindAsync(id);

            List<ProductGroup> productGroup= new List<ProductGroup>();

            try
            {
                productGroup.Add(objProductGroup);
            }
            catch(Exception ex)
            {
                throw new Exception( ex.Message);
            }
            return productGroup;
        }  

        [HttpPost] //Post method
        public async Task Create([FromBody] ProductGroup item)
        {
            try
            {
                _context.ProductGroupTable.Add(item);

                try
                {
                if((IsNumericID(item)==true) && (IsAlphaProductGroupName(item)==true))
                await _context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    throw new Exception("Please enter the ID and ProductGroupName in proper format");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  


        [HttpPut("{id}")] //Update method
        public async Task Update(int id, [FromBody] ProductGroup item)
        {
            try
            {
                var res=_context.ProductGroupTable.FirstOrDefault(t =>t.ID==id);
                try
                {
                    if(IsNumericID(item)==true)
                    res.ID=item.ID;
                }
                catch(Exception)
                {
                    throw new Exception("ID not matching proper format");
                }

                try
                {
                    if(IsAlphaProductGroupName(item)==true)
                    res.ProductGroupName=item.ProductGroupName;
                }
                catch(Exception)
                {
                    throw new Exception("ProductGroupName is not given in proper format");
                }

                _context.ProductGroupTable.Update(res);
                await _context.SaveChangesAsync();
            }
            
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")] //Delete Method
        public async Task Delete(int id)
        {
            var res = _context.ProductGroupTable.FirstOrDefault(t => t.ID == id);
            try
            {
                _context.ProductGroupTable.Remove(res);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool IsNumericID(ProductGroup item)
        {   
            try
            {
                string pattern="^[0-9]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.ID.ToString().Trim())==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsAlphaProductGroupName(ProductGroup item)
        {   
            try
            {
                string pattern="[a-zA-Z]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.ProductGroupName.ToString().Trim())==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}