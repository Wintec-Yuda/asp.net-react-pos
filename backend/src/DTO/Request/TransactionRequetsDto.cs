namespace PointOfSale.DTO.Request;

public class TransactionRequetsDto
{
  public Guid UserId { get; set; }
  public List<TransactionItemRequetsDto>? transactionItems { get; set; }
  public int TotalAmount { get; set; }
}