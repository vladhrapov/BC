using BC.Data.Entity;
using BC.Data.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Services
{
    class PaymentService : BaseService
    {
        private readonly Uow _uow;

        public PaymentService()
        {
            this._uow = BaseService.GetUow();
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _uow.Payment.All.AsEnumerable();
        }

        public Payment GetPaymentById(int id)
        {
            return _uow.Payment.Find(id);
        }

        public void AddOrUpdateProject(Payment payment)
        {
            if (payment != null)
            {
                _uow.Payment.InsertOrUpdate(payment);
                _uow.Save();
            }
            else
            {
                throw new NullReferenceException("Payment is null");
            }
            
        }

        public void DeletePayment(int id)
        {
            _uow.Payment.Delete(id);
            _uow.Save();
        }
    }
}
