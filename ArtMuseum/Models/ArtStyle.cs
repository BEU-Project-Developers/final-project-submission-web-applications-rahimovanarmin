namespace ArtMuseum.Models
{
    public class ArtStyle : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ArtworkArtStyle> ArtworkArtStyles { get; set; }
    }
}

