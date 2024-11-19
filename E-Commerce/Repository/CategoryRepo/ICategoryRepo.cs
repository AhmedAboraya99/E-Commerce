using E_Commerce.DTOs;

namespace E_Commerce.Repository.CategoryRepo
{
    public interface ICategoryRepo
    {
        public CategoryDTO GetById(int id);

        public List<CategoryDTO> GetAll();

        public CategoryDTO Add(CategoryDTO categoryDTO);

        public CategoryDTO AddWithRelatedData(CategoryDTO categoryDTO);

        public CategoryDTO Update(int Id , CategoryDTO categoryDTO);
        public CategoryDTO UpdateWithRelatedData(int Id, CategoryDTO categoryDTO);
        public CategoryDTO Delete(int Id);

    }
}
