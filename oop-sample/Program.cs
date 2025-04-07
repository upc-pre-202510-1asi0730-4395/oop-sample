using oop_sample.Procurement.Domain.Model.Aggregates;
using oop_sample.Procurement.Domain.Model.ValueObjects;
using oop_sample.SCM.Domain.Model.Aggregates;
using oop_sample.SCM.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

// Create a new Supplier
var supplierAddress = new Address("Main St", "100", "New York", null, "62701", "United States");
var supplier = new Supplier("Microsoft, Inc.", supplierAddress);


// Create a new Purchase Order

Console.WriteLine("Creating purchase order...");

var purchaseOrder = new PurchaseOrder("PO001",
    supplier.SupplierId, DateTime.Now, "USD");

// Add items to the purchase order
purchaseOrder
    .AddItem(ProductId.New(), 10,25.99m)
    .AddItem(ProductId.New(), 5, 15.99m);

Console.WriteLine($"Purchase Order ID: {purchaseOrder.OrderNumber} created for supplier {supplier.Name}");

foreach (var item in purchaseOrder.Items)
    Console.WriteLine($"Item Subtotal: {item.CalculateSubtotal().Amount} {item.CalculateSubtotal().Currency}");
// Calculate the total amount of the purchase order
Console.WriteLine($"Total: {purchaseOrder.CalculateTotal().Amount} {purchaseOrder.CalculateTotal().Currency}");
    