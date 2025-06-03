// File: Models/Exhibition.cs
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ArtMuseum.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Exhibition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string? Descriptions { get; set; }

        [Required]
        public string Curator { get; set; }

        [Required]
        public string Location { get; set; }

        [Url]
        public string? ImageUrl { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? TicketPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }

}
