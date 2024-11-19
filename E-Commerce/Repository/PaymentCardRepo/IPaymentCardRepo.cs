using E_Commerce.DTOs;

namespace E_Commerce.Repository.PaymentCardRepo
{
    public interface IPaymentCardRepo
    {

        public PaymentCardDTO GetById(int id);

        public List<PaymentCardDTO> GetAll();

        public PaymentCardDTO Add(PaymentCardDTO paymentCardDTO);

        public PaymentCardDTO AddWithRelatedData(PaymentCardDTO paymentCardDTO);

        public PaymentCardDTO Update(int Id, PaymentCardDTO paymentCardDTO);

        public PaymentCardDTO Delete(int Id);
    }
}
