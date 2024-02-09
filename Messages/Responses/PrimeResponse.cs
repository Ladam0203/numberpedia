namespace Messages.Responses;

public record PrimeResponse
{
    public ulong Number { get; init; }
    public bool IsPrime { get; init; }
    public long ElapsedMilliseconds { get; init; }
}