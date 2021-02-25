using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name).MinimumLength(2);
        }
    }
}
