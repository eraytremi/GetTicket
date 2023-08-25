using FluentValidation;
using GetTicket.Model.Dtos.PassengerDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTicket.Business.FluentValidation.RegisterValidation
{
    public class RegisterValidation : AbstractValidator<RegisterDto>
    {
        public RegisterValidation()
        {
            RuleFor(dto => dto.PassengerName)
           .NotEmpty().WithMessage("Yolcu adı boş olamaz.")
           .MaximumLength(50).WithMessage("Yolcu adı en fazla 30 karakter olmalıdır.");

            RuleFor(dto => dto.PassengerLastName)
                .NotEmpty().WithMessage("Yolcu soyadı boş olamaz.")
                .MaximumLength(50).WithMessage("Yolcu soyadı en fazla 30 karakter olmalıdır.");

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MinimumLength(6).WithMessage("Parola en az 6 karakter olmalıdır.");

            RuleFor(dto => dto.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\d{11}$").WithMessage("Geçersiz telefon numarası formatı.");

            RuleFor(dto => dto.IDNumber)
                .NotEmpty().WithMessage("Kimlik numarası boş olamaz.")
                .Matches(@"^\d{11}$").WithMessage("Geçersiz kimlik numarası formatı.");

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");


            RuleFor(dto => dto.Gender)
                .NotEmpty().WithMessage("Cinsiyet boş olamaz.");
                
        }
        
    }
}
