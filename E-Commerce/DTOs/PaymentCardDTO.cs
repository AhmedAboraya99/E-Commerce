using E_Commerce.Models;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs
{
    public class PaymentCardDTO
    {

        [Required]
        public int CardNumber { get; set; }

        public string CardName { get; set; } = string.Empty;

        public DateTime ExpireDate { get; set; }

    }
}
