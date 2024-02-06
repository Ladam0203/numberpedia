using System.Numerics;

namespace api.Responses;

public record PrimeResponse
{
    public ulong Number { get; init; }
    public bool IsPrime { get; init; }
    public long ElapsedMilliseconds { get; init; }
}