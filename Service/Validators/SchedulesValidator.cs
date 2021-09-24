using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class SchedulesValidator : AbstractValidator<Schedules>
    {
        public SchedulesValidator()
        {
            RuleFor(c => c.Entry)
               .NotEmpty().WithMessage("Please enter the Entry Time.")
               .NotNull().WithMessage("Please enter the Entry Time.");

            RuleFor(c => c.LunchTime)
                    .NotEmpty().WithMessage("Please enter the Lunch Time.")
                    .NotNull().WithMessage("Please enter the Lunch Time.");

            RuleFor(c => c.ReturnLunchTime)
                    .NotEmpty().WithMessage("Please enter the Lunch Return Time.")
                    .NotNull().WithMessage("Please enter the Lunch Return Time.");

            RuleFor(c => c.DepartureTime)
                    .NotEmpty().WithMessage("Please enter the Departure Time.")
                    .NotNull().WithMessage("Please enter the Departure Time.");

        }
    }
}