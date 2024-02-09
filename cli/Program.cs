using System.Text;
using System.Text.Json;
using Messages.Requests;

var client = new HttpClient() { BaseAddress = new Uri("http://prime-service:8080") };

while(true) {
    Console.WriteLine("What number would you like to know more about? (Type 'exit' to quit)");
    var number = 12; //Console.ReadLine();
    
    /*
    //Check if the user wants to exit
    if (number == "exit") {
        break;
    }
    
    //Check if the input is a number
    if (!ulong.TryParse(number, out var numberValue)) {
        Console.WriteLine("Please enter a valid number");
        continue;
    }
    */
    
    ulong numberValue = 12;
    
    //Fetch the prime number
    try {
        var response = await client.PostAsync("Prime", new StringContent(JsonSerializer.Serialize(new PrimeRequest { Number = numberValue }), Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    } catch (Exception e)
    {
        throw;
        Console.WriteLine($"Error: {e.Message}");
    }
    
    await Task.Delay(1000);
}