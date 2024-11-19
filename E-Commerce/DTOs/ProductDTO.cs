using E_Commerce.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs
{
    public class ProductDTO
    {
        [Required]
        public string Name { get; set; }

        [Range(0.1, int.MaxValue)]
        public double Price { get; set; }

        public ICollection<UserDTO>? Users { get; set; } = new Collection<UserDTO>();

        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; } = new CategoryDTO();
    }
}
