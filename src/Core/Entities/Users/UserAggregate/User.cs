using Entities.Doctors.DoctorAggregate.Validators;
using Entities.Doctors.DoctorAggregate;
using Entities.SeedWork.Extensions;
using Entities.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Users.UserAggregate.Validators;

namespace Entities.Users.UserAggregate;
public class User : Entity, IAggregatedRoot
{
    public string Name { get; protected set; }
    public string Cpf { get; protected set; }   
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public UserType Type { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    public User(string name, string cpf, string email, string password)
    {
        Id = Guid.NewGuid();
        Name = name;
        Cpf = cpf;        
        Email = email;
        Password = password.ToMd5();
        CreatedAt = DateTime.UtcNow;        

        if (Validator.IsValid(this, out var error) is false)
            throw new DomainException(error);
    }

   

    private static readonly IValidator<User> Validator = new UserValidator();

    // Required for EF
    protected User()
    {
    }
}

public enum UserType : int
{
    Doctor,
    Patient
}