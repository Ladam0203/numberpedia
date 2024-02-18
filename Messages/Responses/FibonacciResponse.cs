namespace Messages.Responses;

public record FibonacciResponse
{
    public ulong Number { get; init; }
    public bool IsFibonacci { get; init; }
    public long ElapsedMilliseconds { get; init; }
}