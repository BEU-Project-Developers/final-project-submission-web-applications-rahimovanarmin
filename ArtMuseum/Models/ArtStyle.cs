
using System.ComponentModel.DataAnnotations;
namespace ArtMuseum.Models


{
    public class ArtStyle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Style name is required.")]
        public string? Name { get; set; }

        public virtual ICollection<ArtworkArtStyle> ArtworkArtStyles { get; set; }
    }

}

