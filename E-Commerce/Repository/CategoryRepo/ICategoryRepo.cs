using E_Commerce.DTOs;

namespace E_Commerce.Repository.CategoryRepo
{
    public interface ICategoryRepo
    {
        public CategoryToReturnDTO GetById(int id);

        public List<CategoryToReturnDTO> GetAll();

        public int Add(CategoryToAddOnlyDTO categoryDTO);

        public int AddWithRelatedData(CategoryToAddRelatedDTO categoryDTO);

        public bool Update(int Id , CategoryToAddOnlyDTO categoryDTO);
        public bool UpdateWithRelatedData(int Id, CategoryToAddRelatedDTO categoryDTO);
        public bool Delete(int Id);

    }
}
