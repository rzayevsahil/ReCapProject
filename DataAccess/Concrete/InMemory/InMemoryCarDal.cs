using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId=1, BrandName="Alfa Romeo"},
                new Brand{BrandId=2, BrandName="Audi"},
                new Brand{BrandId=3, BrandName="Ferrari"},
                new Brand{BrandId=4, BrandName="BMW"},
                new Brand{BrandId=5, BrandName="Porsche"}
            };

            _colors = new List<Color>
            {
                new Color{ColorId=1, ColorName="Black"},
                new Color{ColorId=2, ColorName="White"},
                new Color{ColorId=3, ColorName="Red"},
                new Color{ColorId=4, ColorName="Grey"},
                new Color{ColorId=5, ColorName="Blue"}
            };

            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=2, ModelYear=2014, DailyPrice=300, Description="Fena değil"},
                new Car{Id=2, BrandId=1, ColorId=2, ModelYear=2015, DailyPrice=320, Description="Fena değil"},
                new Car{Id=3, BrandId=2, ColorId=2, ModelYear=2019, DailyPrice=390, Description="Bebek gibi"},
                new Car{Id=4, BrandId=3, ColorId=2, ModelYear=2021, DailyPrice=850, Description="Adrenalin dolu bi yaşam"},
                new Car{Id=5, BrandId=4, ColorId=2, ModelYear=2018, DailyPrice=470, Description="Havalı bir araba"},
                new Car{Id=6, BrandId=5, ColorId=2, ModelYear=2017, DailyPrice=600, Description="Zorluklara karşı diren"},
                new Car{Id=7, BrandId=4, ColorId=2, ModelYear=2016, DailyPrice=430, Description="Havalı bir araba"},
                new Car{Id=8, BrandId=5, ColorId=2, ModelYear=2020, DailyPrice=680, Description="Zorluklara karşı diren"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
            Console.WriteLine("Yeni araba eklendi : " + car.Description);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            Console.WriteLine("Araba silme işlemi tamamlandı");
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            Console.WriteLine("Araba bilgileri güncellendi :" + carToUpdate.Description);
        }
    }
}
