namespace ArtMuseum.Models
{
    public class Ticket : BaseEntity
    {
        
        public string BuyerName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Age { get; set; }

        public bool IsDiscounted { get; set; }
        public string DiscountType { get; set; } 

        public decimal OriginalPrice { get; set; }
        public decimal FinalPrice { get; set; }   

        public int EventId { get; set; }
        public Event Event { get; set; }
    }

}
