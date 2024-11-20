using E_Commerce.DTOs;

namespace E_Commerce.Repository.UserRepo
{
    public interface IUserRepo
    {
        public UserToReturnDTO GetById(int id);

        public List<UserToReturnDTO> GetAll();

        public int Add(UserToAddOnlyDTO userDTO);

        public int AddWithRelatedData(UserToAddRelatedDTO userDTO);

        public bool Update(int Id, UserToAddRelatedDTO userDTO);

        public bool Delete(int Id);
    }
}
