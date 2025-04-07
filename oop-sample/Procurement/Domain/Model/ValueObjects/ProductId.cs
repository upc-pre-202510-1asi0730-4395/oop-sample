namespace oop_sample.Procurement.Domain.Model.ValueObjects;

/// <summary>
/// This class represents a product ID value object.
/// </summary>
/// <remarks>
/// This class is immutable and should be used to represent product IDs.
/// </remarks> 
public record ProductId
{
    public Guid Id { get; init; }

    /// <summary>
    /// Constructs a new instance of the <see cref="ProductId"/> class.
    /// </summary>
    /// <param name="id">The identifier as a <see cref="Guid"/></param>
    /// <exception cref="ArgumentException">If id is empty</exception>
    public ProductId(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Product id cannot be empty.", nameof(id));
        Id = id;
    }
    
    /// <summary>
    /// This method generates a new product ID.
    /// </summary>
    /// <returns>A new <see cref="ProductId"/> instance with a new GUID</returns>
    public static ProductId New() => new(Guid.NewGuid());
}