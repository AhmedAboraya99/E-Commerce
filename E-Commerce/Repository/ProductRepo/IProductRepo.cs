using E_Commerce.DTOs;

namespace E_Commerce.Repository.ProductRepo
{
    public interface IProductRepo
    {

        public ProductDTO GetById(int id);

        public List<ProductDTO> GetAll();

        public ProductDTO Add(ProductDTO productDTO);

        public ProductDTO AddWithRelatedData(ProductDTO productDTO);

        public ProductDTO Update(int Id, ProductDTO productDTO);

        public ProductDTO Delete(int Id);
    }
}
