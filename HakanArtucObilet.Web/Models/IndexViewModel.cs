using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HakanArtucObilet.Web.Models
{
    public class IndexViewModel : BaseViewModel, IValidatableObject
    {
        [Required(ErrorMessage = "Bu alan gereklidir")]
        public int OriginId { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir")]
        public int DestinationId { get; set; }

        [Required(ErrorMessage = "Bu alan gereklidir")]
        public DateTime DepartureDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (OriginId == DestinationId)
            {
                yield return new ValidationResult("Kalkış noktası ile varış noktası aynı olamaz.");
            }

            if (DepartureDate.Date < DateTime.Now.Date)
            {
                yield return new ValidationResult("Kalkış tarihi bugünden eski olamaz.");
            }
        }
    }
}
