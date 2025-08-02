namespace ePharmacy.Application.Dtos.CartDtos;
public class CartItemCreateDto
{
    public long UserId { get; set; }
    public long ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal? Price { get; set; }
}
