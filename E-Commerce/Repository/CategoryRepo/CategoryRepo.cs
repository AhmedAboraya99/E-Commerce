using E_Commerce.DTOs;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace E_Commerce.Repository.CategoryRepo
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context) {

            _context = context;
            
        }
        public CategoryDTO Add(CategoryDTO categoryDTO)
        {
            if(categoryDTO.ProductIds.Count() == 0)
            {
                throw new ArgumentException();
            }

                Category category = new Category
            {
                Name = categoryDTO.Name,
                Products = _context.products
                .Where(p => categoryDTO.ProductIds.Count() > 0 
                                && categoryDTO.ProductIds.Contains(p.Id)).ToList(),
               
            };

            if (category == null) { return null; }
            _context.categories.Add(category);

            _context.SaveChanges();

            return categoryDTO;


        }

        public CategoryDTO AddWithRelatedData(CategoryDTO categoryDTO)
        {
            //form database
            //var existingproducts = _context.products.Select(m => m.Name).ToList();

            var category = new Category
            {
                Name = categoryDTO.Name,
                Products = categoryDTO.Products
                .Where(p => ! _context.products.Select(m => m.Name).Contains(p.Name))
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    Users = x.Users
                            .Where(i => _context.users.Select(u => u.Name).Contains(i.Name))
                            .Select(u => new User
                            {
                                Name = u.Name,
                                Email = u.Email,
                                Password = u.Password,
                                Card = new PaymentCard
                                {
                                    CardName = u.Card.CardName
                                }

                            }).ToList(),
                }
                        ).ToList()

            };
            _context.categories.Add(category);
            _context.SaveChanges();

            return categoryDTO;


        }

        public CategoryDTO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryDTO> GetAll()
        {
            var categories = _context.categories
                .Include(s => s.Products)
                .ThenInclude(p => p.Users)
                .ToList();

            if (categories.Count == 0)
            {
                return null;
            }
            var categoryListDTO = categories.Select(c => new CategoryDTO
            {
                Name = c.Name,
                Products = c.Products.Select(pm => new ProductDTO
                {
                    Name = pm.Name,
                    Price = pm.Price,
                    Users = pm.Users.Select(um => new UserDTO
                    {
                        Name = um.Name,
                        Email = um.Email,
                        Password = um.Password,
                        Card = new PaymentCardDTO
                        {
                            CardName = um.Card.CardName
                        }
                    }).ToList(),

                }).ToList(),
            }).ToList();
            return categoryListDTO;
            }
        
        

        public CategoryDTO GetById(int id)
        {
            var category = _context.categories
                .Include(s => s.Products)
                .ThenInclude(p => p.Users)
                .FirstOrDefault(c => c.Id == id);

            if (category == null) return null;

            var categoryDTO = new CategoryDTO
            {
                Name = category.Name,
                Products = category.Products.Select(x => new ProductDTO
                {
                    Name = x.Name,
                    Price = x.Price,
                    Users = x.Users.Select(u => new UserDTO
                    {
                        Name = u.Name,
                        Email = u.Email,
                        Password = u.Password,
                        
                        Card = new PaymentCardDTO
                        {
                            CardName = u.Card.CardName
                        }
                    }).ToList()
                }).ToList(),
            };
            return categoryDTO;
        }

        public CategoryDTO Update(int Id, CategoryDTO categoryDTO)
        {
            var category = _context.categories
               .Include(s => s.Products)
               .ThenInclude(p => p.Users)
               .FirstOrDefault(c => c.Id == Id);
            if (category == null)
            {
                return null;
            }
            category.Name = categoryDTO.Name;
            category.Products = categoryDTO.Products.Select(c => new Product
            {
                Name = c.Name,
                Price = c.Price,
                Users = c.Users.Select(u => new User
                {
                    Name= u.Name,
                    Email = u.Email,
                    Password = u.Password,
                    Card = new PaymentCard
                    {
                        CardName = u.Card.CardName
                    }
                }).ToList(),
            }).ToList();

            _context.categories.Update(category);
            _context.SaveChanges();
            return categoryDTO;
        }
    }
}
