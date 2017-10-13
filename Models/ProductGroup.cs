using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class ProductGroup
    {
        [Required,Range(0,9999)]
        public int ID{get;set;}
        
        [Required,StringLength(50)]
        public string ProductGroupName{get;set;}
    }
}