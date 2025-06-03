using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtMuseum.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [ValidateNever]
        public string PasswordHash { get; set; }

		[BindNever]
		[ValidateNever]
		public string Role { get; set; }

		[ValidateNever]
        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();
    }

}
