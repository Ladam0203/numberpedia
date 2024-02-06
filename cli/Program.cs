var client = new HttpClient() { BaseAddress = new Uri("http://api:8080") };

while(true) {
    Console.WriteLine("Pinging api (as container)...");
    
    try {
        var response = await client.GetAsync("api/Prime");
        Console.WriteLine($"Response: {response.StatusCode}");
    } catch (Exception e) {
        Console.WriteLine($"Error: {e.Message}");
    }
    
    await Task.Delay(1000);
}