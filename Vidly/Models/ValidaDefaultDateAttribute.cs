using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class ValidaDefaultDateAttribute : ValidationAttribute

    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //if(validationContext.ObjectInstance is Movie movie && movie.ReleaseDate==Movie.DateofMovieReleased) 
            //    return  new ValidationResult(" please type a valid date.");
            return ValidationResult.Success;
        }
    }
}