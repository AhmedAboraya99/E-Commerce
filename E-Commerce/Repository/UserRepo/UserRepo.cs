using E_Commerce.DTOs;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context) {
            _context = context;
        }
        public int Add(UserToAddOnlyDTO userDTO)
        {
            var products = _context.products
                .Where(d => userDTO.ProductIds.Contains(d.Id)).ToList();

            var card = _context.paymentCards
                .SingleOrDefault(pc => pc.Id == userDTO.CardId);
            if(products == null || card == null)
            {
                throw new Exception("Not Found");
            }
            var user = new User
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Products = products,
                Card = card,
                
            };
            _context.users.Add(user);
            _context.SaveChanges();


            return user.Id;
        }

        public int AddWithRelatedData(UserToAddRelatedDTO userDTO)
        {



            var user = new User
            {

                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Products = userDTO.Products?.Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = new Category
                    {
                        Name = p.Name,
                    }
                }
                ).ToList(),
                Card = new PaymentCard
                {
                    CardName = userDTO.Card.CardName,
                    ExpireDate = userDTO.Card.ExpireDate,

                }
            };

            _context.users.Add(user);
            _context.SaveChanges();

            return user.Id; 
        }

        public bool Delete(int Id)
        {
            var user = _context.users
                .SingleOrDefault(u => u.Id == Id);


            if (user == null) { return false; }


            _context.users.Remove(user);
            _context.SaveChanges();

            return true;

        }

        public List<UserToReturnDTO> GetAll()
        {
            var users = _context.users?.Include(u => u.Products)
                .ThenInclude(p => p.Category)
                .Include(u => u.Card)
                .Select(ud => new UserToReturnDTO
                {
                    Id = ud.Id,
                    Name = ud.Name,
                    Email = ud.Email,
                    Password = ud.Password,
                    Products = ud.Products.Select(p => new ProductToReturnDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Category = new CategoryToReturnDTO
                        {
                            Name = p.Category.Name,
                        }
                    }).ToList(),
                }).ToList();
            return users;
        }

        public UserToReturnDTO GetById(int id)
        {
            var user = _context.users?.Include(u => u.Products)
                .ThenInclude(p => p.Category)
                .Include(u => u.Card)
                .SingleOrDefault(u => u.Id == id);

            var userDto = new UserToReturnDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Products = user.Products?.Select(p => new ProductToReturnDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Category = new CategoryToReturnDTO
                    {
                        Id = p.Id,
                        Name = p.Category.Name,
                    }
                }).ToList()
            };
            return userDto;
        }

        public bool Update(int Id, UserToAddRelatedDTO userDTO)
        {
            var u = _context.users.FirstOrDefault(x => x.Id == Id);
            if(u == null) return false;

            u.Email=userDTO.Email;
            u.Password=userDTO.Password;
            u.Products = userDTO.Products?.Select(p => new Product
            {
                Name = p.Name,
                Price = p.Price,
                Category = new Category
                {
                    Name = p.CategoryName,
                }
            }).ToList();
            u.Card = new PaymentCard
            {
                CardName = userDTO.Card.CardName,
                CardNumber = userDTO.Card.CardNumber,
                ExpireDate = userDTO.Card.ExpireDate
            };

            _context.users.Update(u);
            _context.SaveChanges();
            return true;
        }
    }
}
