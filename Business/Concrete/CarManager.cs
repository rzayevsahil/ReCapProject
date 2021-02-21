using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            //bu kısmı fluent validator tarafına devrettim
            //if (car.DailyPrice <= 0)
            //{
            //    return new ErrorResult(Messages.CarDailyPriceInvalid);
            //}

            
            ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
                
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IResult Update(Car car)
        {
            //if (car.DailyPrice <= 0)
            //{
            //    return new ErrorResult(Messages.CarDailyPriceInvalid);
            //}
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarList);
        }
        
        public IDataResult<List<Car>> GetCarByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        
        public IDataResult<List<Car>> GetCarByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId ));
        }

        public IDataResult<List<Car>> GetCarByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }
    }
}
