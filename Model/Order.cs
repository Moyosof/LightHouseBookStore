using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LightHeight.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual BookStore Book { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }  = DateTime.Now;
    }
}
