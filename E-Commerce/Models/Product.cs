using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.1,int.MaxValue)]
        public double Price { get; set; }

        public ICollection<User>? Users { get; set; } = new Collection<User>();

        [ForeignKey(nameof(Category.Id))]
        public int CategoryId { get; set; } 
        public Category Category { get; set; } = new Category();


        
        
    }
}
