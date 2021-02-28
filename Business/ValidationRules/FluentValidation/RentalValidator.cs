using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.ReturnDate).NotEmpty();
            RuleFor(r => r.ReturnDate).GreaterThanOrEqualTo(r => r.RentDate).When(r => r.ReturnDate.HasValue);
        }
        
    }
}
