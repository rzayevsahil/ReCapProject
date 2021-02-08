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
        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Add(car);
                Console.WriteLine("** " + car.Description + " ** araba eklendi.");
            }
            else
            {
                Console.WriteLine("Günlük fiyatınız 0 dan büyük olmalıdır sisteme girilen deger : {car.DailyPrice}");
            }
        }
                
        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("** " + car.Description + " ** araba silindi.");
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine("** " + car.Description + " ** araba güncellendi.");
            }
            else
            {
                Console.WriteLine($"araba güncelleme aşamasında günlük fiyat hatalı girildi . O dan büyük giriniz girdiginiz deger {car.DailyPrice}");
            }
            
        }

        public List<Car> GetAll()
        {
            Console.WriteLine("*********** Car List ***********");
            return _carDal.GetAll();
        }
        
        public List<Car> GetCarByDailyPrice(decimal min, decimal max)
        {
            Console.WriteLine("*********** Car List by Daily Price ***********");
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        
        public List<Car> GetCarByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId );
        }

        public List<Car> GetCarByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

    }
}
