using E_Commerce.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }

        public List<int> ProductIds {  get; set; } = new List<int>();
        public ICollection<ProductDTO>? Products { get; set; }

    }
    public class CategoryToReturnDTO
    {
        [Required]
        public string Name { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }

    }
}
