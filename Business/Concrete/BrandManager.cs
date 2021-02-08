using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("{0} - Marka adı başarıyla eklendi",brand.BrandName);
            }
            else
            {
                Console.WriteLine($"marka ismini 2 harfden fazla giriniz {brand.BrandName}");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("{0} - Marka adı başarıyla silindi", brand.BrandName);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("{0} - Marka adı başarıyla güncellendi", brand.BrandName);
        }

        public List<Brand> GetAll()
        {
            Console.WriteLine("*********** Car Brand List ***********");
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b => b.BrandId == id);
        }

        
    }
}
