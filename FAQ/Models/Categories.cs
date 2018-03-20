using System.ComponentModel.DataAnnotations;

namespace FAQ.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } 
        public int SiteCode { get; set; }
    }
}