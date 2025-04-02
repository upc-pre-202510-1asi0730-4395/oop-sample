using oop_sample.Procurement.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

namespace oop_sample.Procurement.Domain.Model.Aggregates;

public class PurchaseOrderItem(ProductId productId, int quantity, Money unitPrice)
{
    public ProductId ProductId { get;  } = productId ?? 
                                           throw new ArgumentNullException(nameof(productId));
    public int Quantity { get;  } = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
    public Money UnitPrice { get; } = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));

    public Money CalculateSubtotal()
    {
        return new Money(Quantity * UnitPrice.Amount, UnitPrice.Currency);
    }
}
