namespace ArtMuseum.Models
{
    public class ArtworkArtStyle
    {
        public int ArtWorkId { get; set; }
        public int ArtStyleId { get; set; }

        public virtual Artwork Artwork { get; set; }
        public virtual ArtStyle ArtStyle { get; set; }
    }


}
