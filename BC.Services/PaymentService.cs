using BC.Data.Entity;
using BC.Data.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BC.Services
{
    public class PaymentService : BaseService
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

        public Payment GetPaymentById(Guid id)
        {
            return _uow.Payment.Find(id);
        }

        public Payment PaymentGetByCredentials(string login, string password)
        {
           return _uow.Payment.GetByCredentials(p => p.Password.Equals(password) && p.Login.Equals(login));
        }
        
        public void AddOrUpdateProject(Payment payment)
        {
            var oldPayment = _uow.Payment.GetByCredentials(p => p.Password.Equals(payment.Password));
            if (oldPayment != null)
            {
                throw new DuplicateNameException("Password is already exist");
            }

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

        public void DeletePayment(Guid id)
        {
            _uow.Payment.Delete(id);
            _uow.Save();
        }
    }
}
