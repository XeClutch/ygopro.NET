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
```

### Get all cards
```c#
var cards = await GetAllCardsAsync();

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
var card = await GetCardByNameAsync("Dark Magician");

Console.WriteLine($"Name: {card?.Name}");    
Console.WriteLine($"Attack: {card?.Attack}, Defense: {card?.Defense}"); 

// The equivalent of this but client side
var cards = await GetAllCardsAsync();

if (cards != null)
{
    var card = cards.FirstOrDefault(x => x.Name == "Dark Magician");
}
```