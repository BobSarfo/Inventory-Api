namespace Inventory.Core.Domain.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string? Customer { get; set; }
        public string? Product { get; set; }
        public decimal Price { get; set; }
    }
}
