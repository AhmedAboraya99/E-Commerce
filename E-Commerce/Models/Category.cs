using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new Collection<Product>();

    }
}
