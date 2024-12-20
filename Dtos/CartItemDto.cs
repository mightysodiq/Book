namespace Book.Api.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => price * Quantity;
    }
}
