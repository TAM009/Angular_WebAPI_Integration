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
    public class ProductInfo:IProductDetailsService //2.Defining method of the connected interface.

    {
        public readonly ProductDetailsContext _context;

        public ProductInfo(ProductDetailsContext context)
        {
            _context=context;
        }
        
        [HttpGet]
        public async Task<List<ProductDetails>> GetAll() //ProductDetails is the class performing one on one mapping with ProductInfoTable in database.
        {
            return await _context.ProductInfoTable.ToListAsync(); //ProductInfoTable is the database in SqlServer
        }

        [HttpGet("{id}", Name = "GetProductDetails")]
        public async Task<List<ProductDetails>> GetUsingId(int id)
        {
            ProductDetails objProductDetails= await _context.ProductInfoTable.FindAsync(id);

            List<ProductDetails> ProductDetails= new List<ProductDetails>();

            try
            {
                ProductDetails.Add(objProductDetails);
            }
            catch(Exception ex)
            {
                throw new Exception( ex.Message );
            }
            return ProductDetails;
        }  

        [HttpPost] //Post method
        public async Task Create([FromBody] ProductDetails item)
        {
            try
            {
                _context.ProductInfoTable.Add(item);

                try
                {
                    if(IsAlphaName(item) && IsNumericRate(item) && IsNumericGroupID(item)&&IsAlphaDescription(item))
                    await _context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    throw new Exception("Please make sure that all the inputs are given in the proper format");
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }  


        [HttpPut("{id}")] //Update method
        public async Task Update(int id, [FromBody] ProductDetails item)
        {
            var res=_context.ProductInfoTable.FirstOrDefault(t =>t.ID==id);
            
            try
            {   
                try
                {
                    if(IsAlphaName(item))
                    res.ProductName=item.ProductName;
                }
                catch(Exception ex)
                {
                    //throw new Exception("Product name can contain only alphabets and space");
                    throw new Exception(ex.Message);
                }


                try
                {
                    if(IsNumericRate(item))
                    res.Rate=item.Rate;
                }
                catch(Exception)
                {
                    throw new Exception("rate can consist only integer input");
                } 


                try
                {
                    if(IsNumericGroupID(item))   
                    res.GroupID=item.GroupID;
                }
                catch(Exception)
                {
                    throw new Exception("GroupID can consist only integer input");
                } 


                _context.ProductInfoTable.Update(res);
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
            
            try
            {
                var res = _context.ProductInfoTable.FirstOrDefault(t => t.ID == id);
                _context.ProductInfoTable.Remove(res);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        //TypeSafe Check
        public bool IsAlphaName(ProductDetails item)
        {   
            try
            {
                string pattern="[a-zA-Z]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.ProductName.ToString().Trim())==true)
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

        public bool IsAlphaDescription(ProductDetails item)
        {   
            try
            {
                string pattern="[a-zA-Z]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.ProductDescription.ToString().Trim())==true)
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

        public bool IsNumericRate(ProductDetails item)
        {   
            try
            {
                string pattern="^[0-9]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.Rate.ToString().Trim())==true)
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

        public bool IsNumericGroupID(ProductDetails item)
        {   
            try
            {
                string pattern="^[0-9]+$";
                Regex regex=new Regex(pattern);
                if(regex.IsMatch(item.GroupID.ToString().Trim())==true)
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