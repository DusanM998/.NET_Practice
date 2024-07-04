using static System.Console;

// Poboljsanje prilagodlivosti za konzolne aplikacije

HttpClient client = new();

HttpResponseMessage responseMessage = await client.GetAsync("http://www.apple.com");

WriteLine("Apple's home page has {0:N0} bytes.",
    responseMessage.Content.Headers.ContentLength);