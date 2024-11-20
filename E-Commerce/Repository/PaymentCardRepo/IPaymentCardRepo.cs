using E_Commerce.DTOs;

namespace E_Commerce.Repository.PaymentCardRepo
{
    public interface IPaymentCardRepo
    {

        public PaymentCardDTO GetById(int id);

        public List<PaymentCardDTO> GetAll();

        public int Add(PaymentCardDTO paymentCardDTO);

        public int AddWithRelatedData(PaymentCardDTO paymentCardDTO);

        public bool Update(int Id, PaymentCardDTO paymentCardDTO);

        public bool Delete(int Id);
    }
}
