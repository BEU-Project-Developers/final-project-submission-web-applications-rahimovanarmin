using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtMuseum.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        
        public string? Name { get; set; }

        public string? Biography { get; set; }

       
        public string? Nation { get; set; }

        public string? PhotoUrl {  get; set; }

   
        public DateTime BirthDate { get; set; }
        public ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
    }
}

