using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string? Email { get; set; } = null;

        [MinLength(6)]
        public string? Password { get; set; }

        public ICollection<Product>? Products { get; set; } = new Collection<Product>();

        [ForeignKey(nameof(Card.Id))]
        public int CardId { get; set; }
        public PaymentCard Card { get; set; } = new PaymentCard();
    }
}
