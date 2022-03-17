# YGOPRO.NET

YGOPRO.NET is an API Wrapper for the [YGOPRODECK API](https://db.ygoprodeck.com/api-guide/)

## :wrench: Installation
### Install from source
1. `git clone https://github.com/MordechaiHadad/ygopro.NET.git` in your root directory
2. add this line to your App.csproj
```c#
<ItemGroup>
    <ProjectReference Include="..\YGOPRO\YGOPRO.csproj" />
</ItemGroup>
```

NuGet will come soon

## :question: Usage
### Initialize the client
```c#
using YGOPRO;

var client = new YGOClient();

// If you want to create a client with a different language:
// YGOPRODECK only accepts German, French, Italian, and Portuguese
var client = new YGOClient(Language.German);

// Different languages accept only names in the corresponding language
// For Example you can't make the language French and input: "Dark Magician"
```

### Get all cards
```c#
var cards = await client.GetAllCardsAsync();

// Get Dark Magician

if (cards != null)
{
    var card = cards.FirstOrDefault(x => x.Name == "Dark Magician");
    
    Console.WriteLine($"Name: {card?.Name}");    
    Console.WriteLine($"Attack: {card?.Attack}, Defense: {card?.Defense}");    
}
```

### Get specific card by name
```c#
var card = await client.GetCardByNameAsync("Dark Magician");

Console.WriteLine($"Name: {card?.Name}");    
Console.WriteLine($"Attack: {card?.Attack}, Defense: {card?.Defense}"); 

// The equivalent of this but client side
var cards = await client.GetAllCardsAsync();

if (cards != null)
{
    var card = cards.FirstOrDefault(x => x.Name == "Dark Magician");
}
```