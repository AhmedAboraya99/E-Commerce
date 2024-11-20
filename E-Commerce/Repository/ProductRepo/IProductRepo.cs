using E_Commerce.DTOs;

namespace E_Commerce.Repository.ProductRepo
{
    public interface IProductRepo
    {

        public ProductToReturnDTO GetById(int id);

        public List<ProductToReturnDTO> GetAll();

        public int Add(ProductToAddOnlyDTO productDTO);

        public int AddWithRelatedData(ProductToAddRelatedDTO productDTO);

        public bool Update(int Id, ProductToAddOnlyDTO productDTO);

        public bool Delete(int Id);
    }
}
