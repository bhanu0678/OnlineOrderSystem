using System.ComponentModel.DataAnnotations;

namespace OnlineFoodOrder.Models
{
    public class Cart
    {

        //public int ProductmenuId { get; set; }

        public Productmenu Productmenu { get; set; }

       
        public int Count { get; set; }
    }
}
