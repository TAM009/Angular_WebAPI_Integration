using System.ComponentModel.DataAnnotations; //For model validation.

namespace Product.Models
{
    public class ProductDetails
    {
        [Required,Range(1,9999)]
        public long ID{get;set;}
       
        [Required,Range(1,4)]
        public int GroupID{get;set;}
       
        [Required,StringLength(100)]
        public string ProductName{get;set;}

        [Required,StringLength(100)]
        public string ProductDescription{get;set;}
        
        [Required,Range(0,1000)]
        public int Rate{get;set;}
    } 
}