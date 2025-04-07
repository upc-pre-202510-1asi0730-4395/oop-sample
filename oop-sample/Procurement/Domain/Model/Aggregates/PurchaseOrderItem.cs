using oop_sample.Procurement.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

namespace oop_sample.Procurement.Domain.Model.Aggregates;

/// <summary>
/// This class represents a purchase order item for the purchase order aggregate.
/// </summary>
/// <param name="productId">The product ID as a <see cref="ProductId"/></param>
/// <param name="quantity">The quantity of the product</param>
/// <param name="unitPrice">The unit price as a <see cref="Money"/></param>
public class PurchaseOrderItem(ProductId productId, int quantity, Money unitPrice)
{
    public ProductId ProductId { get;  } = productId ?? 
                                           throw new ArgumentNullException(nameof(productId));
    public int Quantity { get;  } = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity), quantity, "Quantity must be greater than zero.");
    public Money UnitPrice { get; } = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));

    /// <summary>
    /// Calculates the subtotal for the purchase order item.
    /// </summary>
    /// <returns>The subtotal as a <see cref="Money"/></returns>
    public Money CalculateSubtotal()
    {
        return new Money(Quantity * UnitPrice.Amount, UnitPrice.Currency);
    }
}
