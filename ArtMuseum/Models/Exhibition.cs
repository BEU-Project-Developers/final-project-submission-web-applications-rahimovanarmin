namespace ArtMuseum.Models
{
    public class Exhibition : BaseEntity
    {
      
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Artwork> Artworks { get; set; }
        public ICollection<Event> Events { get; set; }
    }



}
