namespace ArtMuseum.Models
{
    public class Artwork : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearCreated { get; set; }

        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public ICollection<ArtworkArtStyle> ArtworkArtStyles { get; set; }
    }



}
