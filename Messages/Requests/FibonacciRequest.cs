namespace Messages.Requests;

public record FibonacciRequest
{
    public ulong Number { get; init; }
}