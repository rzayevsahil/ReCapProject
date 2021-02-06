using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll();
        Car GetById(int Id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        
    }
}
