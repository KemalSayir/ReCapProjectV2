using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.RentDate).Must(GreaterThanNow).WithMessage("Başlangıç Tarihi Günümüzden Sonra olmalıdır");
            RuleFor(p => p.ReturnDate).Must(GreaterThanNow).WithMessage("Geri Dönüş Tarih Günümüzden Sonra olmalıdır");
        }

        private bool GreaterThanNow(DateTime arg)
        {
            return arg.Date <= DateTime.Now ? false : true;
        }
    }
}
