namespace PointOfSale.DTO.Request;

public class TransactionItemRequetsDto
{
  public Guid ProductId { get; set; }
  public int Quantity { get; set; }
  public int Price { get; set; }
  public Guid TransactionId { get; set; }
}