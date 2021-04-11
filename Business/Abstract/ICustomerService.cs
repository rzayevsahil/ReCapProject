using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Delete(Customer customer);
        IResult Update(Customer customer);
        IDataResult<Customer> GetById(int id);
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetails();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int customerId);
        IDataResult<CustomerDetailDto> GetByEmail(string email);

    }
}
