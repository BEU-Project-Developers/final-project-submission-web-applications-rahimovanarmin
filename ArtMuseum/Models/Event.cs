using System.Net.Sockets;

namespace ArtMuseum.Models
{
    public class Event : BaseEntity
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }

        public int ExhibitionId { get; set; }
        public Exhibition Exhibition { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }

}
