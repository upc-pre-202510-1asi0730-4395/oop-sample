namespace oop_sample.SCM.Domain.Model.ValueObjects;

/// <summary>
/// This class represents a supplier ID value object.
/// </summary>
/// <remarks>
/// This class is immutable and should be used to represent supplier IDs.
/// </remarks>
public record SupplierId
{
    public string Identifier { get; init; }

    /// <summary>
    /// Constructs a new instance of the <see cref="SupplierId"/> class.
    /// </summary>
    /// <param name="identifier">The identifier as a string</param>
    /// <exception cref="ArgumentException">If identifier is null or whitespace</exception>
    public SupplierId(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(identifier));
        Identifier = identifier;
    }
}