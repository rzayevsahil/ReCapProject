using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result=_rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null ).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentedCarAlreadyExists);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<Rental> CheckReturnDate(int carId)
        {
            List<Rental> resultRental = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            if (resultRental.Count > 0)
            {
                return new ErrorDataResult<Rental>(Messages.RentalUndeliveredCar);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));
        }

        public IResult CheckRule(Rental rental)
        {
            IResult result = BusinessRules.Run(RentalRule(rental));

            if (result != null)
            {
                return result;
            }
            return new SuccessResult();
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalList);
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        public IDataResult<List<Rental>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == customerId));
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>
                (_rentalDal.GetRentalDetails(r => r.CarId == carId), Messages.RentalListed);
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        [CacheRemoveAspect("IRentalService.Get")] 
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }



        private IResult RentalRule(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && 
            ((rental.RentDate > r.RentDate || rental.ReturnDate >= r.RentDate) && rental.RentDate <= r.ReturnDate));
            
            if (rental.RentDate < DateTime.Now || result.Count > 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult CheckRent(int carId)
        {
            var result = _rentalDal.GetAll().Where(r => r.CarId == carId).LastOrDefault();
            if (result!=null && (result.ReturnDate!=null && result.ReturnDate<= DateTime.Now))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }


        
    }
}
