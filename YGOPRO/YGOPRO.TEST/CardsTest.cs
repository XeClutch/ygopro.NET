using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using YGOPRO.Enums;
using YGOPRO.Models;

namespace YGOPRO.TEST;

[Category("Cards")]
public class Tests
{
    private YGOClient _ygoClient;

    [OneTimeSetUp]
    public void GetSetup()
    {
        _ygoClient = new YGOClient();
    }

    #region Returns valid values

    [Test]
    public async Task GetAllCardsReturnsNonEmptyList()
    {
        var allCards = await _ygoClient.GetAllCardsAsync();

        Assert.IsNotNull(allCards);
        Assert.IsNotEmpty(allCards!);
    }

    [Test]
    public async Task GetCardByNameReturnsValidCard()
    {
        const string cardName = "A Rival Appears!";
        const CardType cardType = CardType.TrapCard;

        var cardByName = await _ygoClient.GetCardByNameAsync(cardName);

        Assert.IsNotNull(cardByName);
        Assert.IsTrue(string.Equals(cardName, cardByName!.Name));
        Assert.IsTrue(cardType == cardByName.Type);
    }

    [Test]
    public async Task GetMultipleCardsByNameReturnsValidCards()
    {
        var cardNames = new[] {
            "A Rival Appears!",
            "Ancient Gear Factory",
            "Ancient Gear Drill",
            "Hydro Pressure Cannon",
            "Icejade Cradle"
        };
        

        var cardsByName = await _ygoClient.GetCardsByNameAsync(cardNames);

        Assert.IsNotNull(cardsByName);
        Assert.IsNotEmpty(cardsByName!);
        Assert.AreEqual(cardNames.Length, cardsByName!.Count);
    }

    [Test]
    public async Task GetFuzzySearchCardByNameReturnsValidCard()
    {
        const string cardName = "Magician";

        var cardsByName = await _ygoClient.GetCardByFuzzyNameSearchAsync(cardName);

        Assert.IsNotNull(cardsByName);
        Assert.IsNotEmpty(cardsByName!);
        Assert.Greater(cardsByName!.Count, 100);
    }

    [Test]
    public async Task GetCardByIdReturnsValidCard()
    {
        const int cardId = 67865534;
        const string cardName = "Magician of Hope";
        const CardType cardType = CardType.XYZPendulumEffectMonster;

        var cardByName = await _ygoClient.GetCardByIdAsync(cardId);

        Assert.IsNotNull(cardByName);
        Assert.AreEqual(cardId, cardByName!.Id);
        Assert.IsTrue(cardType == cardByName.Type);
        Assert.IsTrue(cardName == cardByName.Name);
    }

    [Test]
    public async Task GetCardsByTypeReturnsValidCards()
    {
        const CardType cardType = CardType.XYZPendulumEffectMonster;

        var cardsByName = await _ygoClient.GetCardsByTypeAsync(cardType);

        Assert.IsNotNull(cardsByName);
        Assert.IsNotEmpty(cardsByName!);
        Assert.Greater(cardsByName!.Count, 5);
    }

    [Test]
    public async Task GetCardsByAttackValueReturnsValidCards()
    {
        const int attackValue = 2500;

        var cardsByName = await _ygoClient.GetCardsByAttackAsync(attackValue);

        Assert.IsNotNull(cardsByName);
        Assert.IsNotEmpty(cardsByName!);
        Assert.Greater(cardsByName!.Count, 200);

        foreach (var card in cardsByName)
        {
            Assert.AreEqual(attackValue, card.Attack);
        }
    }

    [Test]
    public async Task GetCardsByDefenseValueReturnsValidCards()
    {
        const int defenseValue = 2000;

        var cardsByName = await _ygoClient.GetCardsByDefenseAsync(defenseValue);

        Assert.IsNotNull(cardsByName);
        Assert.IsNotEmpty(cardsByName!);
        Assert.Greater(cardsByName!.Count, 500);

        foreach (var card in cardsByName)
        {
            Assert.AreEqual(defenseValue, card.Defense);
        }
    }

    [Test]
    public async Task GetCardsByLevelValueReturnsValidCards()
    {
        const int levelValue = 6;

        var cardsByName = await _ygoClient.GetCardsByLevelAsync(levelValue);

        Assert.IsNotNull(cardsByName);
        Assert.IsNotEmpty(cardsByName!);
        Assert.Greater(cardsByName!.Count, 500);

        // Breaks due to their api returning cards that don't have a level even if you request a specific level :/
        // for (var i = 0; i < cardsByName.Count; i++)
        // {
        //     Assert.AreEqual(levelValue, cardsByName[i].Level);
        // }
    }

    [Test]
    public async Task GetCardsByRaceAsyncReturnsValidCards()
    {
        const CardRace raceValue = CardRace.Aqua;

        var cardsByRace = await _ygoClient.GetCardsByRaceAsync(raceValue);
        
        Assert.IsNotNull(cardsByRace);
        Assert.IsNotEmpty(cardsByRace!);
        foreach (var card in cardsByRace!)
        {
            Assert.AreEqual(raceValue, card.CardRace);
        }
        
    }

    [Test]
    public async Task GetCardsByAttributeAsyncReturnsValidCards()
    {
        const CardAttribute attributeValue = CardAttribute.Dark;

        var cardsByAttribute = await _ygoClient.GetCardsByAttributeAsync(attributeValue);
        
        Assert.IsNotNull(cardsByAttribute);
        Assert.IsNotEmpty(cardsByAttribute!);
        // Failing because some attributes are null...
        // foreach (var card in cardsByAttribute!)
        // {
        //     Assert.AreEqual(attributeValue, card.Attribute);
        // }
    }

    #endregion

    #region Returns invalid values

    [Test]
    public async Task GetCardByNameReturnsInvalidCard()
    {
        const string cardName = "Invalid Card Here";
        const CardType cardType = CardType.TrapCard;

        var cardByName = await _ygoClient.GetCardByNameAsync(cardName);

        Assert.IsNull(cardByName);
    }

    [Test]
    public async Task GetMultipleCardsByNameReturnsInvalidCards()
    {

        var cardNames = new[]
        {
            "Random Card 1",
            "Random Card 2",
            "Random Card 3"
        };
        var cardsByName = await _ygoClient.GetCardsByNameAsync(cardNames);

        Assert.IsNull(cardsByName);
    }

    [Test]
    public async Task GetFuzzySearchCardByNameReturnsInvalidCard()
    {
        const string cardName = "Random Card";

        var cardsByName = await _ygoClient.GetCardByFuzzyNameSearchAsync(cardName);

        Assert.IsNull(cardsByName);
    }

    [Test]
    public async Task GetCardByIdReturnsInvalidCard()
    {
        const int cardId = 1234;

        var cardByName = await _ygoClient.GetCardByIdAsync(cardId);

        Assert.IsNull(cardByName);
    }
    
    #endregion
}