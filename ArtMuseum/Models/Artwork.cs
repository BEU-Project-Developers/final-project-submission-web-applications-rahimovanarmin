using ArtMuseum.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ArtMuseum.Models
{
    public class Artwork
    {
        public int Id { get; set; }

      
        public string? Title { get; set; }

        public string? Description { get; set; } 

        [DataType(DataType.Date)]
      
        public DateTime YearCreated { get; set; }

        public string? ImageUrl { get; set; }

     
        public int ArtistId { get; set; }

      
        public Artist Artist { get; set; }
       
        public ICollection<ArtworkArtStyle> ArtworkArtStyles { get; set; }
    }
}

