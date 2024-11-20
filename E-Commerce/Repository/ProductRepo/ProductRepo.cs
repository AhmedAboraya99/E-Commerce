using E_Commerce.DTOs;

namespace E_Commerce.Repository.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        public int Add(ProductToAddOnlyDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public int AddWithRelatedData(ProductToAddRelatedDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductToReturnDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductToReturnDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int Id, ProductToAddOnlyDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
