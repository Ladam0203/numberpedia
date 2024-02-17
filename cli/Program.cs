using System.Text;
using System.Text.Json;
using Messages.Requests;
using Messages.Responses;

var client = new HttpClient() { BaseAddress = new Uri("http://prime-service:8080") };

ulong numberValue = 1;
while(true) {
    Console.WriteLine("Displaying info about " + numberValue + "...");
    
    try {
        var response = await client.PostAsync("Prime", new StringContent(JsonSerializer.Serialize(new PrimeRequest { Number = numberValue }), Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();

        var rawResponse = await response.Content.ReadAsStringAsync();
        Console.WriteLine(rawResponse);
        var primeResponse = JsonSerializer.Deserialize<PrimeResponse>(rawResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (primeResponse == null)
        {
            throw new Exception("Failed to deserialize response");
        }
        Console.Write(primeResponse.IsPrime ? "Prime" : "Not Prime");
    } catch (Exception e)
    {
        Console.Write($"Error - {e.Message})");
    }

    Console.WriteLine();
    
    //Wait for a second
    await Task.Delay(1000);
    
    //Increment the number
    numberValue++;
}