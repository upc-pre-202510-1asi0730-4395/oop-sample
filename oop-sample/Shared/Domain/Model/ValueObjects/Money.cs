namespace oop_sample.Shared.Domain.Model.ValueObjects;

/// <summary>
/// Represents a monetary value object with an amount and currency.
/// </summary>
/// <remarks>
/// This class is immutable and should be used to represent money values.
/// </remarks>
public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }

    /// <summary>
    /// Constructs a new instance of the <see cref="Money"/> class.
    /// </summary>
    /// <param name="amount">The amount as a decimal value</param>
    /// <param name="currency">The 3-letter code for currency</param>
    /// <exception cref="ArgumentException">If currency is null, white space or not restricted to 3-letter code</exception>
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be 3 characters long.", nameof(currency));
        Amount = amount;
        Currency = currency;
    }
}