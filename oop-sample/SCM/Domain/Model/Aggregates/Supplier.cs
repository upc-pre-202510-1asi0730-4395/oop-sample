using oop_sample.SCM.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

namespace oop_sample.SCM.Domain.Model.Aggregates;

public class Supplier
{
    public SupplierId SupplierId { get; private set; }
    public string Name { get; private set; }
    public Address Address { get; private set; }

    public Supplier(string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Supplier name cannot be null, empty or whitespace.", nameof(name));
        SupplierId = new SupplierId(Guid.NewGuid().ToString());
        Name = name;
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }
    
}