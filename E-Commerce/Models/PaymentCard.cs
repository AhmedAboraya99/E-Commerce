using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace E_Commerce.Models
{
    public class PaymentCard
    {
        public int Id { get; set; }
        [Required]
        public int CardNumber { get; set; }

        public string CardName { get; set; } = string.Empty;

        public DateTime ExpireDate { get; set; }

        public User? User { get; set; }

    }
}
