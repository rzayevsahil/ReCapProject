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
            CarManager carManager = new CarManager(new EfBrandDal());
            Console.WriteLine("***************** Brand lists *****************");
            foreach (var brand in carManager.GetAllBrand())
            {
                Console.WriteLine(brand.BrandName);
            }

            CarManager carManager1 = new CarManager(new EfColorDal());
            Console.WriteLine("***************** Color lists *****************");
            foreach (var color in carManager1.GetAllColor())
            {
                Console.WriteLine(color.ColorName);
            }

            CarManager carManager2 = new CarManager(new EfCarDal());
            Brand brand1 = new Brand { BrandId=11,BrandName="Tofash"};
            
            carManager.BrandAdd(brand1);
            





            Console.ReadLine();
        }
    }
}
