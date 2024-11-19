using E_Commerce.DTOs;

namespace E_Commerce.Repository.UserRepo
{
    public interface IUserRepo
    {
        public UserDTO GetById(int id);

        public List<UserDTO> GetAll();

        public UserDTO Add(UserDTO userDTO);

        public UserDTO AddWithRelatedData(UserDTO userDTO);

        public UserDTO Update(int Id, UserDTO userDTO);

        public UserDTO Delete(int Id);
    }
}
