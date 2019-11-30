using System;
using System.ComponentModel.DataAnnotations; //validations
namespace quotingDojo.Models
{
    public class Quote
    {
        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string Name { get; set; }

        [MaxLength(30, ErrorMessage = "Must be less than 30 characters.")]
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}