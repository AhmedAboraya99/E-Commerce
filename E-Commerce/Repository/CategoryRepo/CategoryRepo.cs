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
        public int Add(CategoryToAddOnlyDTO categoryDTO)
        {
            //list of products that needed to be matched with new category 
            var matchedProduct = _context.products.Where(p => categoryDTO.ProductIds.Contains(p.Id)).ToList();
            var category = new Category
            {
                Name = categoryDTO.Name,
                Products = matchedProduct
            };
            if(category.Products == null)
            {
                throw new Exception("Not Found Products");
            }

            if (category == null) { throw new Exception("Category Not Found"); }


            _context.categories.Add(category);
            _context.SaveChanges();



            return category.Id;
        }
     
        public int AddWithRelatedData(CategoryToAddRelatedDTO categoryDTO)
        {
            //form database
            var newProducts = _context.products
                            .Where(p => !categoryDTO.Products.Select(c => c.Name).Contains(p.Name)).ToList();
           

            var category = new Category
            {
                Name = categoryDTO.Name,
                Products = categoryDTO.Products
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    Users = x.Users
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

            return category.Id;


        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryToReturnDTO> GetAll()
        {
            var categories = _context.categories
                .Include(s => s.Products)
                .ThenInclude(p => p.Users)
                .ToList();

            if (categories.Count == 0)
            {
                return null;
            }
            var categoryListDTO = categories.Select(c => new CategoryToReturnDTO
            {
                Id = c.Id,
                Name = c.Name,
                Products = c.Products.Select(pm => new ProductToReturnDTO
                {
                    Id = pm.Id,
                    Name = pm.Name,
                    Price = pm.Price,
                    Users = pm.Users.Select(um => new UserToReturnDTO
                    {
                        Id = um.Id,
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
        
        

        public CategoryToReturnDTO GetById(int id)
        {
            var category = _context.categories
                .Include(s => s.Products)
                .ThenInclude(p => p.Users)
                .FirstOrDefault(c => c.Id == id);

            if (category == null) return null;

            var categoryDTO = new CategoryToReturnDTO
            {
                Name = category.Name,
                Products = category.Products.Select(x => new ProductToReturnDTO
                {
                    Name = x.Name,
                    Price = x.Price,
                    Users = x.Users.Select(u => new UserToReturnDTO
                    {
                        Id = u.Id,
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

        public bool Update(int Id, CategoryToAddOnlyDTO categoryDTO)
        {
            var category = _context.categories
               .Include(s => s.Products)
               .ThenInclude(p => p.Users)
               .FirstOrDefault(c => c.Id == Id);

            //list of products that needed to be matched with new category 
            var matchedProduct = _context.products
                    .Where(p => categoryDTO.ProductIds.Contains(p.Id))
                    .ToList();

            if (category == null)
            {
                return false;
            }
            category.Name = categoryDTO.Name;
            category.Products = matchedProduct;

            _context.categories.Update(category);
            _context.SaveChanges();
            return true;
        }
        public bool UpdateWithRelatedData(int Id, CategoryToAddRelatedDTO categoryDTO)
        {
            var category = _context.categories
               .Include(s => s.Products)
               .ThenInclude(p => p.Users)
               .FirstOrDefault(c => c.Id == Id);

            if (category == null)
            {
                return false;
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
            return true;
        }

    }
}
