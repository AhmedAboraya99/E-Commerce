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

    }
        public class ProductToAddOnlyDTO
    {
        [Required]
        public string Name { get; set; }

        [Range(0.1, int.MaxValue)]
        public double Price { get; set; }

        public ICollection<int>? UserIds { get; set; } = new Collection<int>();

        public int CategoryId { get; set; }
    }

    public class ProductToAddRelatedDTO
    {
        [Required]
        public string Name { get; set; }

        [Range(0.1, int.MaxValue)]
        public double Price { get; set; }

        public ICollection<UserToAddRelatedDTO>? Users { get; set; } = new Collection<UserToAddRelatedDTO>();

        public string CategoryName { get; set; } = string.Empty;
    }

    public class ProductToReturnDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(0.1, int.MaxValue)]
        public double Price { get; set; }

        public ICollection<UserToReturnDTO>? Users { get; set; } = new Collection<UserToReturnDTO>();

        public CategoryToReturnDTO Category { get; set; } = new CategoryToReturnDTO();
    }
}
