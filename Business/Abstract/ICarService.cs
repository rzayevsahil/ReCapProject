using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        List<Car> GetCarByBrandId(int brandId);
        List<Car> GetCarByColorId(int colorId);
        List<Car> GetCarByDailyPrice(decimal min, decimal max);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        List<CarDetailDto> GetCarDetails();
    }
}
