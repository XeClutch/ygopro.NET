using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using YGOPRO.Enums;

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
        var cardNames = new List<string>
        {
            "A Rival Appears!",
            "Ancient Gear Factory",
            "Ancient Gear Drill",
            "Hydro Pressure Cannon",
            "Icejade Cradle"
        };

        var cardsByName = await _ygoClient.GetCardsByNameAsync(cardNames);

        Assert.IsNotNull(cardsByName);
        Assert.IsNotEmpty(cardsByName!);
        Assert.AreEqual(cardNames.Count, cardsByName!.Count);
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

        for (var i = 0; i < cardsByName.Count; i++)
        {
            Assert.AreEqual(attackValue, cardsByName[i].Attack);
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

        for (var i = 0; i < cardsByName.Count; i++)
        {
            Assert.AreEqual(defenseValue, cardsByName[i].Defense);
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
        var cardNames = new List<string>
        {
            "Random Card 1",
            "Random Card 2",
            "Random Card 3",
            "Random Card 4",
            "Random Card 5"
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