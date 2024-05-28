# YgoPro.NET <a href="https://www.nuget.org/packages/YgoPro.NET"><img alt="NuGet" src="https://badgen.net/badge/YgoPro.NET/v1.1.1/blue?icon=nuget"/></a>

YgoPro.NET is an API Wrapper for the [YGOPRODECK API](https://db.ygoprodeck.com/api-guide/).

Support the free API by [purchasing a subscription](https://ygoprodeck.com/premium/).

## :wrench: Installation
### NuGet
`dotnet add package YgoPro.NET`

### Install from source
1. `git clone https://github.com/MordechaiHadad/ygopro.NET.git` in your root directory
2. add this line to your App.csproj
```c#
<ItemGroup>
    <ProjectReference Include="..\YGOPRO\YGOPRO.csproj" />
</ItemGroup>
```

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
This may take a while as the response from the API is not paginated and all cards in the ygoprodeck database will be returned.
It's recommended that you make this call once and cache it locally.
```c#
var cards = await client.GetAllCardsAsync();
```

### Get specific card by name
Make sure that if you're only looking for a particular card that you use the appropriate methods. YGOPRODECK is a free community run API primarily paid for by donations.
Making unnecessarily heavy calls increases their server costs and can lead to you IP address being blacklisted.
```c#
// do this:
var ygoDarkMagician = await client.GetCardByNameAsync("Dark Magician");

// not this:
var cards = await client.GetAllCardsAsync();
if (cards?.Count > 0) {
    var ygoDarkMagician = cards.FirstOrDefault(x => x.Name.ToLower() == "dark magician");
}
```

### Get all sets
Unfortunately the ygoprodeck API only supports returning all sets and are unable to query the API for a specific set.
It's recommended that you make this call once and cache it locally.
```c#
var sets = await client.GetAllSetsAsync();
```
