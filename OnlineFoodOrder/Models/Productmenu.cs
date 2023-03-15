using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineFoodOrder.Models
{
    public class Productmenu
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Product Image")]
        
        public string? Image_url { get; set; }

        [NotMapped]
        [DisplayName("Choose Image")]
        public IFormFile? ImagePath { get; set; }

        [DisplayName("Product Title")]
        //[Required(ErrorMessage="Title is Required")]
        public string? Title { get; set; }
        [DisplayName("Product Description")]
        //[Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }
        //[DisplayName("Product Price")]
        //[Required(ErrorMessage = "price is Required")]
        public decimal? Price { get; set; } 


    }
}
