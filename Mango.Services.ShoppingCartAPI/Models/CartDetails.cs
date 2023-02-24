using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Services.ShoppingCartAPI.Models
{
    public class CartDetails
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set;}
        public int ProducitId { get; set; }
        [ForeignKey("ProducitId")]
        public virtual Product Product { get; set; }
        public int Count { get; set; }
    }
}
