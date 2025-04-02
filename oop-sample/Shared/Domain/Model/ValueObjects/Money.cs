namespace oop_sample.Shared.Domain.Model.ValueObjects;

public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }

    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency) || currency.Length != 3)
            throw new ArgumentException("Currency must be 3 characters long.", nameof(currency));
        Amount = amount;
        Currency = currency;
    }
}