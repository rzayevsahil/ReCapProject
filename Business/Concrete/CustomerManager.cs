using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<CustomerDetailDto> GetByEmail(string email)
        {
            var getByEmail = _customerDal.GetByEmail(user => user.Email == email);
            return new SuccessDataResult<CustomerDetailDto>(getByEmail);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int customerId)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>
                (_customerDal.GetCustomerDetails(c => c.Id == customerId));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
