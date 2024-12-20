namespace Book.Api.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public IEnumerable<CartItemDto> items { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public String PaymentMethod { get; set; }

    }
}
