using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,ReCapDbContext>,ICustomerDal
    {        
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from customer in filter == null ? context.Customers : context.Customers.Where(filter)
                             join user in context.Users
                                 on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 UserId = user.Id,
                                 CompanyName = customer.CompanyName,
                                 Email = user.Email,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Status = user.Status,
                                 FindexPoint=customer.FindexPoint
                             };
                return result.ToList();

            }
        }

        public CustomerDetailDto GetByEmail(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CustomerId = customer.Id,
                                 UserId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 CompanyName = customer.CompanyName,
                                 FindexPoint = customer.FindexPoint
                             };
                return result.SingleOrDefault(filter);
            }
        }
    }
}
