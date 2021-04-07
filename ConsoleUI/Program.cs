using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            CarManager carManager = new CarManager(new EfCarDal());
           

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}",
                    car.Id,car.ColorName,car.BrandName,car.ModelYear,car.Description,car.DailyPrice);
            }

            //Brand brand1 = new Brand {BrandName="Tofash"};
            //Brand brand2 = new Brand();

            //brandManager.Add(brand1);

            //Console.WriteLine("Brand Id'si 1 olan arabalar:");
            //Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-20} ", 
            //    "CarID", "Color", "Brand", "Model Year", "Daily Price", "Description\n"));
            //foreach (var car in carManager.GetCarByBrandId(3))
            //{
            //    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-20} ", car.Id, colorManager.GetById(car.ColorId).ColorName,
            //        brandManager.GetById(car.BrandId).BrandName, car.ModelYear, car.DailyPrice, car.Description));

            //}

            //Console.WriteLine("\n\nGünlük fiyat aralığı 200 ile 500 olan arabalar:");
            //foreach (var car in carManager.GetCarByDailyPrice(200,500))
            //{
            //    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-20} ", car.Id, colorManager.GetById(car.ColorId).ColorName,
            //        brandManager.GetById(car.BrandId).BrandName, car.ModelYear, car.DailyPrice, car.Description));
            //}

            //Car car1 = carManager.GetById(5);
            //Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-20} ", car1.Id, colorManager.GetById(car1.ColorId).ColorName,
            //        brandManager.GetById(car1.BrandId).BrandName, car1.ModelYear, car1.DailyPrice, car1.Description));

            //carManager.Add(new Car { BrandId = 7, ColorId = 2, DailyPrice = 700, ModelYear = 2012, Description = "Güzel Araba" });
            //foreach (var car in carManager.GetAll())
            //    {
            //    Console.WriteLine(String.Format("{0,-12} | {1,-12} | {2,-13} | {3,-13} | {4,-13} | {5,-20} ", car.Id, colorManager.GetById(car.ColorId).ColorName,
            //        brandManager.GetById(car.BrandId).BrandName, car.ModelYear, car.DailyPrice, car.Description));

            //}
            //brandManager.Add(new Brand { BrandName = "a" });
            //carManager.Add(new Car { DailyPrice=-200 });
            //Car car3 = new Car {Id=2012 };
            //carManager.Delete(car3);
            //carManager.Update(new Car { Id=1, BrandId = 1, ColorId = 5, DailyPrice = 470, ModelYear = 2020, Description = "AUDI Q8 - Red" });
            //carManager.Update(new Car { Id = 7,BrandId=7,ModelYear=2021,ColorId=1,DailyPrice=730, Description = "PORSCHE P911 Turbo S - Black" });



            Console.ReadLine();
        }
    }
}
