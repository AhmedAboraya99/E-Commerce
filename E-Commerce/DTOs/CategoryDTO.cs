using E_Commerce.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTOs
{
    public class CategoryDTO
    {
        [Required]
        public string Name { get; set; }

    }
        public class CategoryToAddOnlyDTO
        {
            [Required]
            public string Name { get; set; }

            public List<int> ProductIds {  get; set; } = new List<int>();
        }

    public class CategoryToAddRelatedDTO
    {
        [Required]
        public string Name { get; set; }
        public ICollection<ProductToAddRelatedDTO>? Products { get; set; } = new Collection<ProductToAddRelatedDTO>();

    }
    public class CategoryToReturnDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<ProductToReturnDTO>? Products { get; set; }

    }
}
