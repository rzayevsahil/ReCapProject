using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from rental in filter == null ? 
                             context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new RentalDetailDto
                             {
                                 Id=rental.Id,
                                 CarId = car.Id,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 CustomerId=customer.Id,
                                 CustomerFirstName=user.FirstName,
                                 CustomerLastName = user.LastName,
                                 CompanyName=customer.CompanyName,
                                 CarModelYear=car.ModelYear,
                                 CarDailyPrice=car.DailyPrice,
                                 CarDescription=car.Description,
                                 ReturnDate = rental.ReturnDate,
                                 RentDate=rental.RentDate
                             };

                return result.ToList();
            }
        }
    }
}
