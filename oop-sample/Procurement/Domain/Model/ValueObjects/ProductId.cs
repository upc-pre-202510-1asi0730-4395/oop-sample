namespace oop_sample.Procurement.Domain.Model.ValueObjects;

public record ProductId
{
    public Guid Id { get; init; }

    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product id cannot be empty.", nameof(id));
        Id = id;
    }
    
    public static ProductId New() => new(Guid.NewGuid());
}