using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GettCarByBrandId(int brandId);
        List<Car> GettCarByColorId(int colorId);
        List<Car> GetCarByDailyPrice(decimal min, decimal max);
        List<Brand> GetAllBrand();
        List<Color> GetAllColor();
        void CarAdd(Car car);
        void ColorAdd(Color color);
        void BrandAdd(Brand brand);
    }
}
