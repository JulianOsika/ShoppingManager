namespace ShoppingManager.Dtos
{
    public class CreateProductRequest
    {
        public required string Name { get; set; }
        public string? Unit { get; set; }
        public string? Company { get; set; }
        public string? Description { get; set; }

        public int? CategoryId { get; set; }
    }
}
