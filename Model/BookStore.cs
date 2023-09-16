using System.ComponentModel.DataAnnotations;

namespace LightHeight.Model
{
    public class BookStore
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        //public decimal TotalPrice { get; set; }
    }
}
