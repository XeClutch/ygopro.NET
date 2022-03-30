using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YGOPRO.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CardRace
{
    [EnumMember(Value = "Aqua")] Aqua,
    [EnumMember(Value = "Beast")] Beast,
    [EnumMember(Value = "Beast-Warrior")] BeastWarrior,
    [EnumMember(Value = "Creator-God")] CreatorGod,
    [EnumMember(Value = "Cyberse")] Cyberse,
    [EnumMember(Value = "Continuous")] Continuous,
    [EnumMember(Value = "Counter")] Counter,
    [EnumMember(Value = "Dinosaur")] Dinosaur,
    [EnumMember(Value = "Divine-Beast")] DivineBeast,
    [EnumMember(Value = "Dragon")] Dragon,
    [EnumMember(Value = "Equip")] Equip,
    [EnumMember(Value = "Fairy")] Fairy,
    [EnumMember(Value = "Field")] Field,
    [EnumMember(Value = "Fiend")] Fiend,
    [EnumMember(Value = "Fish")] Fish,
    [EnumMember(Value = "Insect")] Insect,
    [EnumMember(Value = "Machine")] Machine,
    [EnumMember(Value = "Normal")] Normal,
    [EnumMember(Value = "Plant")] Plant,
    [EnumMember(Value = "Psychic")] Psychic,
    [EnumMember(Value = "Pyro")] Pyro,
    [EnumMember(Value = "Quick-Play")] QuickPlay,
    [EnumMember(Value = "Reptile")] Reptile,
    [EnumMember(Value = "Ritual")] Ritual,
    [EnumMember(Value = "Rock")] Rock,
    [EnumMember(Value = "Sea Serpent")] SeaSerpent,
    [EnumMember(Value = "Spellcaster")] Spellcaster,
    [EnumMember(Value = "Thunder")] Thunder,
    [EnumMember(Value = "Warrior")] Warrior,
    [EnumMember(Value = "Winged Beast")] WingedBeast,
    [EnumMember(Value = "Wyrm")] Wyrm,
    [EnumMember(Value = "Zombie")] Zombie,
}