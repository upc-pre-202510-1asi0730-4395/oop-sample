using oop_sample.SCM.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

namespace oop_sample.SCM.Domain.Model.Aggregates;

/// <summary>
/// This class represents a supplier aggregate.
/// </summary>
/// <remarks>
/// This class is the aggregate root for the supplier entity.
/// </remarks> 
public class Supplier
{
    public SupplierId SupplierId { get; private set; }
    public string Name { get; private set; }
    public Address Address { get; private set; }

    /// <summary>
    /// Constructs a new instance of the <see cref="Supplier"/> class.
    /// </summary>
    /// <param name="name">The name of the supplier</param>
    /// <param name="address">The address of the supplier</param>
    /// <exception cref="ArgumentException">If name is null, empty or whitespace</exception>
    /// <exception cref="ArgumentNullException">If address is null</exception>
    public Supplier(string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Supplier name cannot be null, empty or whitespace.", nameof(name));
        SupplierId = new SupplierId(Guid.NewGuid().ToString());
        Name = name;
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }
    
}