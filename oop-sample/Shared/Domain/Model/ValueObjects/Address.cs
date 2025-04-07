namespace oop_sample.Shared.Domain.Model.ValueObjects;

/// <summary>
/// This class represents an address value object.
/// </summary>
/// <remarks>
/// This class is immutable and should be used to represent addresses.
/// </remarks>
public record Address
{
    public string Street { get; init; }
    public string Number { get; init; }
    public string City { get; init; }
    public string StateOrRegion { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }

    /// <summary>
    /// Constructs a new instance of the <see cref="Address"/> class.
    /// </summary>
    /// <param name="street">Street address</param>
    /// <param name="number">Street number</param>
    /// <param name="city">City</param>
    /// <param name="stateOrRegion">State or region</param>
    /// <param name="postalCode">Postal code</param>
    /// <param name="country">Country</param>
    /// <exception cref="ArgumentException">If any of the parameters are null or whitespace</exception>
    public Address(string street, string number, string city, string stateOrRegion, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException($"'{nameof(street)}' cannot be null or whitespace", nameof(street));
        if (string.IsNullOrWhiteSpace(number))
            throw new ArgumentException($"'{nameof(number)}' cannot be null or whitespace", nameof(number));
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException($"'{nameof(city)}' cannot be null or whitespace", nameof(city));
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException($"'{nameof(postalCode)}' cannot be null or whitespace", nameof(postalCode));
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException($"'{nameof(country)}' cannot be null or whitespace", nameof(country));
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }
}