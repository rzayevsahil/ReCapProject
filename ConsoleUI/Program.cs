using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            
            

            carManager.Add(new Car { Id = 9, BrandId = 3, ColorId = 3, ModelYear = 2013, DailyPrice = 740, Description = "Yeni eklenmiş araba" });
            carManager.GetAll();

            carManager.Update(new Car { Id = 1, BrandId = 4, ColorId = 3, ModelYear = 2015, DailyPrice = 305, Description = "Bilgileri güncellenmiş araba" });
            carManager.GetAll();

            carManager.Delete(new Car { Id = 9, BrandId = 3, ColorId = 3, ModelYear = 2013, DailyPrice = 740, Description = "Yeni eklenmiş araba" });
            carManager.GetAll();

            carManager.GetById(1);

            




            Console.ReadLine();
        }
    }
}
