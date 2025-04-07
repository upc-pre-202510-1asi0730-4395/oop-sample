using oop_sample.Procurement.Domain.Model.ValueObjects;
using oop_sample.SCM.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

namespace oop_sample.Procurement.Domain.Model.Aggregates;

/// <summary>
/// This class represents a purchase order aggregate root.
/// </summary>
/// <remarks>
/// This class is the aggregate root for the purchase order entity.
/// </remarks>
/// <param name="orderNumber">The order number</param>
/// <param name="supplierId">The supplier ID as a <see cref="SupplierId"/></param>
/// <param name="orderDate">The order date</param>
/// <param name="currency">The currency code</param>
public class PurchaseOrder(string orderNumber, SupplierId supplierId, DateTime orderDate, string currency)
{
    private readonly List<PurchaseOrderItem> _items = new();
    
    public string OrderNumber { get; } = orderNumber ?? throw new ArgumentNullException(nameof(orderNumber));
    public SupplierId SupplierId { get; } = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    public DateTime OrderDate { get; } = orderDate;
    public string Currency { get; } = string.IsNullOrWhiteSpace(currency) || currency.Length != 3 
        ? throw new ArgumentException("Currency must be a 3-letter code.", nameof(currency))
        : currency;

    public IReadOnlyList<PurchaseOrderItem> Items => _items.AsReadOnly();

    /// <summary>
    /// Adds an item to the purchase order.
    /// </summary>
    /// <param name="productId">The product ID as a <see cref="ProductId"/></param>
    /// <param name="quantity">The quantity of the product</param>
    /// <param name="unitPriceAmount">The unit price amount</param>
    /// <returns>The current instance of <see cref="PurchaseOrder"/></returns>
    /// <exception cref="ArgumentOutOfRangeException">If quantity or unit price amount are less than or equal to zero</exception>
    public PurchaseOrder AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount < 0) throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit Price Amount cannot be negative.");
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
        return this;
    }

    /// <summary>
    /// Calculates the total amount of the purchase order.
    /// </summary>
    /// <returns>The total amount as a <see cref="Money"/></returns>
    public Money CalculateTotal()
    {
        var total = _items.Sum(item => item.CalculateSubtotal().Amount);
        return new Money(total, Currency);
    }
}
