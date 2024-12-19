using FluentValidation;
using FluentValidationTest.Models;

namespace FluentValidationTest.Validator
{
    public class CustomerValidator:AbstractValidator<CustomerModel>
    {
        public CustomerValidator() {

            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(5).WithMessage("First Name must be min 5 character");
            RuleFor(x => x.LastName).NotEmpty().MinimumLength(5).WithMessage("Last Name must be min 5 character");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).Must(phone =>!string.IsNullOrEmpty(phone) && phone.StartsWith("+")).WithMessage("Phone must starts with + sign.");
            RuleFor(x => x.Age).InclusiveBetween(5,10).WithMessage("Age must be between 5 to 10 years");
        }
    }
}
