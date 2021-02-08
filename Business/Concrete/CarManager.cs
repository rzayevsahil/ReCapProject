using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public CarManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public CarManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        
        public void BrandAdd(Brand brand)
        {
            _brandDal.Add(brand);
        }
        
        public void CarAdd(Car car)
        {
            _carDal.Add(car);
        }

        

        public void ColorAdd(Color color)
        {
            _colorDal.Add(color);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Brand> GetAllBrand()
        {
            return _brandDal.GetAll();
        }

        public List<Color> GetAllColor()
        {
            return _colorDal.GetAll();
        }

        public List<Car> GetCarByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
        }

        
        public List<Car> GettCarByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId == brandId );
        }

        public List<Car> GettCarByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        
    }
}
