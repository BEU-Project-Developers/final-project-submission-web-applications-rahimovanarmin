using System.Net.Sockets;

namespace ArtMuseum.Models
{
	public class Event
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime EventDate { get; set; }

		public int ExId { get; set; }
		public virtual Exhibition Exhibition { get; set; }

	}


}
