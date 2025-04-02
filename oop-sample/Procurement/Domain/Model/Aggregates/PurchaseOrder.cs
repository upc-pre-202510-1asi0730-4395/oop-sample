using oop_sample.Procurement.Domain.Model.ValueObjects;
using oop_sample.SCM.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

namespace oop_sample.Procurement.Domain.Model.Aggregates;

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

    public void AddItem(ProductId productId, int quantity, decimal unitPriceAmount)
    {
        ArgumentNullException.ThrowIfNull(productId);
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");
        if (unitPriceAmount < 0) throw new ArgumentOutOfRangeException(nameof(unitPriceAmount), "Unit Price Amount cannot be negative.");
        var unitPrice = new Money(unitPriceAmount, Currency);
        var item = new PurchaseOrderItem(productId, quantity, unitPrice);
        _items.Add(item);
    }

    public Money CalculateTotal()
    {
        var total = _items.Sum(item => item.CalculateSubtotal().Amount);
        return new Money(total, Currency);
    }
}
