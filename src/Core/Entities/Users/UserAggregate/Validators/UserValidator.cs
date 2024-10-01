using Entities.Doctors.DoctorAggregate;
using Entities.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Users.UserAggregate.Validators;

internal sealed class UserValidator : IValidator<User>
{
    public bool IsValid(User doctor, out string error)
    {
        // TODO: Implement validations
        error = string.Empty;
        return true;
    }
}

