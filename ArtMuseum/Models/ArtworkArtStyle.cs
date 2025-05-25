namespace ArtMuseum.Models
{
    public class ArtworkArtStyle
    {
        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; }

        public int ArtStyleId { get; set; }
        public ArtStyle ArtStyle { get; set; }
    }

}
