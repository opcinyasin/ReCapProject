using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => Convert.ToInt32(c.Price)).GreaterThan(0);
            RuleFor(c => c.ModelYear).Length(4);
        }
    }
}
