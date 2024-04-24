using System.ComponentModel.DataAnnotations;

namespace ProductWebsite.Models
{
    public class AddProductForm
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Url]
        public string imageURL { get; set; }
        [Required]
        public decimal price { get; set; }

    }


    public class EditProductForm
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Url]
        public string imageURL { get; set; }
        [Required]
        public decimal price { get; set; }
    }
}
