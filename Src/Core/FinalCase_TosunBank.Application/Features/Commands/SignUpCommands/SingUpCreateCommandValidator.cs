using FinalCase_TosunBank.Application.DTOs.CustomerDTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace FinalCase_TosunBank.Application.Features.Commands.SignUpCommands;

public class SingUpCreateCommandValidator : AbstractValidator<SignUpCreateDTO>
{
    public SingUpCreateCommandValidator()
    {
        RuleFor(cmd => cmd.Email)
            .EmailAddress().WithMessage("Please enter a valid email address.");
        RuleFor(cmd => cmd.FirstName)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 255).WithMessage("Name must be at least 2 characters long.")
            .Matches("^[a-zA-ZüÜöÖçÇşŞğĞıI]*$").WithMessage("Name must only contain lowercase alphabetic characters.");
        RuleFor(cmd => cmd.LastName)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 255).WithMessage("Name must be at least 2 characters long.")
            .Matches("^[a-zA-ZüÜöÖçÇşŞğĞıI]*$").WithMessage("Name must only contain lowercase alphabetic characters.");
        RuleFor(cmd => cmd.Address)
            .NotEmpty().WithMessage("Address is required.");
        RuleFor(cmd => cmd.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(8, 16).WithMessage("Password must be between 8 and 16 characters long.")
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[\\W_])").WithMessage("Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character.");
        RuleFor(cmd => cmd.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Must(BeValidPhoneNumber).WithMessage("Enter a valid telephone number.");
        RuleFor(cmd => cmd.NationalityNumber)
            .NotEmpty().WithMessage("Nationality number is required.")
            .Length(11).WithMessage("Nationality number must be between 1 and 11 characters long.")
            .Matches("^\\d+$").WithMessage("Nationality number must be numeric only.");
        RuleFor(cmd => cmd.BirthDay)
            .NotEmpty().WithMessage("Birth day is reqired.")
            .Must(date => date.AddYears(18) <= DateTime.Now.Date).WithMessage("Must be over 18 years of age.");
    }

    private bool BeValidPhoneNumber(string phoneNumber)
    {
        return Regex.IsMatch(phoneNumber, @"^[0-9\s+-]+$");
    }
}
