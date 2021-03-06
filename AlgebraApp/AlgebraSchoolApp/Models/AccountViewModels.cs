﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace AlgebraSchoolApp.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {

        [Required(ErrorMessage ="Email je obavezan!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Lozinka je obavezna!")]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

    }

    public class RegisterViewModel
    {

        [Required(ErrorMessage ="Ime je obavezno!")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno!")]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Email adresa je obavezna!")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lozinka je obavezna!")]
        [StringLength(100, ErrorMessage = " {0} mora bit {2} znaka duga.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lozinka")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potvrdi lozinku")]
        [Compare("Password", ErrorMessage = "Lozinka i potvrdna lozinka se ne podudaraju")]
        public string ConfirmPassword { get; set; }


    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
