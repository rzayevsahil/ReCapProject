using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            //bu kısmı fluent validator tarafına devrettim
            //if (brand.BrandName.Length <= 2)
            //{
            //    return new ErrorResult(Messages.BrandNameInvalid);
            //}
            //ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandList);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(b => b.BrandId == id));
        }

        
    }
}
