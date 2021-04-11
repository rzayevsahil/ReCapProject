using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [CacheRemoveAspect("IPaymentService.Get")]
        public IResult Add(Payment payment)
        {
            var result = CheckCard(payment);

            if (result)
            {
                return new SuccessResult();
            }
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.CardAdded);
        }

        [CacheRemoveAspect("IPaymentService.Get")]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IPaymentService.Get")]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment> GetById(int cardId)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(p => p.PaymentId == cardId));
        }

        public IDataResult<List<Payment>> GetByCustomerId(int customerId)
        {
            var getByCustomerId = _paymentDal.GetAll(payment => payment.CustomerId == customerId);
            return new SuccessDataResult<List<Payment>>(getByCustomerId);
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IResult VerifyCard(Payment card)
        {
            var result = _paymentDal.Get(c => c.CardNameSurname == card.CardNameSurname && c.CardNumber == card.CardNumber && c.CardCvv == card.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private bool CheckCard(Payment card)
        {
            var beforeExist = _paymentDal.GetAll(c => c.CustomerId == card.CustomerId);

            if (beforeExist.Count > 0)
            {
                var currentCard = _paymentDal.Get(c => c.CardNumber == card.CardNumber);

                if (currentCard != null)
                {
                    return true;
                }
            }

            return false;
        }

        //public IResult IsCardExist(Payment payment)
        //{
        //    var result = _paymentDal.Get(p => p.CardNameSurname == payment.CardNameSurname && p.CardNumber == payment.CardNumber
        //    && p.CardCvv == payment.CardCvv && p.CardExpiryDate == payment.CardExpiryDate);
        //    if (result == null)
        //    {
        //        return new ErrorResult();
        //    }
        //    return new SuccessResult();
        //}

        //public bool CheckCardNumber(string cardNumber)
        //{
        //    var getByCardNumber = _paymentDal.Get(c => c.CardNumber == cardNumber);

        //    if (getByCardNumber != null)
        //        return true;

        //    return false;
        //}
    }
}
