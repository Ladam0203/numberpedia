namespace Messages.Requests;

public record PrimeRequest
{
    public ulong Number { get; init; }
}