namespace ArtMuseum.Models
{

    public class Artist: BaseEntity
    {
        
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Artwork> Artworks { get; set; }
    }

}
