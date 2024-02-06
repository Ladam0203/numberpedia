using System.Numerics;
using System.Text.Json.Serialization;

namespace api.Requests;

public record PrimeRequest
{
    public ulong Number { get; init; }
}