using E_Commerce.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs
{
    public class UserDTO
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string? Email { get; set; } = null;

        [MinLength(6)]
        public string? Password { get; set; }
        //for adding "matching existing" data
        public List<int> ProductIds {  get; set; } = new List<int>();
        public int CardId { get; set; }
        //for retreiving data
        //for adding nonexisting data
        public ICollection<ProductDTO>? Products { get; set; } = new Collection<ProductDTO>();
        public PaymentCardDTO Card { get; set; } = new PaymentCardDTO();
    }
}
