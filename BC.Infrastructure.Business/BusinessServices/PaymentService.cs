using BC.Domain.Core;
using BC.Domain.Core.Enums;
using BC.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BC.Infastructure.Interfaces;
using System.Linq.Expressions;

namespace BC.Infrastructure.Business.BusinessServices
{
    public class PaymentService : BaseService, IService<Payment>
    {
        private readonly Uow _uow;

        public PaymentService()
        {
            this._uow = BaseService.GetUow();
        }

        public  IEnumerable<Payment> All()
        {
            return _uow.Payment.All().AsEnumerable();
        }

        public void Add(Payment payment)
        {
            payment.Date = DateTime.Now;
            payment.Id = Guid.NewGuid();

            //TODO Rework
            //if (_uow.Payment.All.Any(p => p.Login.Equals(payment.Login)))
            //{
            //    throw new DuplicateNameException("Login is already exist");
            //}

            //if (payment.IsDemonstration)
            //{
            //    payment.CheckNumber = GetCheckNumber(payment);
            //    _uow.Payment.InsertOrUpdate(payment);
            //}
            //else
            //{
            //    var project = _uow.Project.All(p => p.Id == payment.ProjectId).FirstOrDefault();
            //    if (project == null)
            //    {
            //        throw new NullReferenceException("No project in id ");
            //    }

            //    if (project.ProjectStatus != ProjectStatus.Open)
            //    {
            //        throw new InvalidOperationException("Project is finish");
            //    }

            //    project.CurrentSum += payment.Sum;
            //    if (project.CurrentSum > project.TotalSum)
            //    {
            //        project.ProjectStatus = ProjectStatus.Finished;
            //    }
            //    _uow.Project.InsertOrUpdate(project);

            //    payment.CheckNumber = GetCheckNumber(payment);
            //    _uow.Payment.InsertOrUpdate(payment);
            //}
            _uow.Save();
        }

        public void Update(Payment payment)
        {
            if (payment != null)
            {
                _uow.Payment.Edit(payment);
                _uow.Save();
            }
            else
            {
                throw new NullReferenceException("Payment is null");
            }
        }

        public void Delete(Guid id)
        {
            var payment = _uow.Payment.FindBy(p => p.Id == id);
            _uow.Payment.Delete(payment);
            _uow.Save();
        }

        private int GetCheckNumber(Payment payment)
        {
            var payments = _uow.Payment.All(filter: p => p.ProjectId == payment.Id);
            if (payments.Count == 0)
            {
                return payment.IsDemonstration ? 0 : 1;
            }

            var count = payments.OrderBy(p => p.CheckNumber).Last().CheckNumber;

            return payment.IsDemonstration ? count : (count + 1);
        }

        public Payment FindBy(Expression<Func<Payment, bool>> predicate)
        {
            return _uow.Payment.FindBy(predicate);
        }
    }
}
