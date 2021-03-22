using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarByColorId(int colorId);
        IDataResult<List<Car>> GetCarByDailyPrice(decimal min, decimal max);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> CarListBrandIdColorId(int brandId, int colorId);

        IResult AddTransactionalTest(Car car);
    }
}
