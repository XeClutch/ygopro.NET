﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YGOPRO.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CardRace
{
    [EnumMember(Value = "Andrew")] Andrew,
    [EnumMember(Value = "Aqua")] Aqua,
    [EnumMember(Value = "Arkana")] Arkana,
    [EnumMember(Value = "Beast-Warrior")] BeastWarrior,
    [EnumMember(Value = "Beast")] Beast,
    [EnumMember(Value = "Bonz")] Bonz,
    [EnumMember(Value = "Christine")] Christine,
    [EnumMember(Value = "Continuous")] Continuous,
    [EnumMember(Value = "Counter")] Counter,
    [EnumMember(Value = "Creator-God")] CreatorGod,
    [EnumMember(Value = "Cyberse")] Cyberse,
    [EnumMember(Value = "David")] David,
    [EnumMember(Value = "Dinosaur")] Dinosaur,
    [EnumMember(Value = "Divine-Beast")] DivineBeast,
    [EnumMember(Value = "Dragon")] Dragon,
    [EnumMember(Value = "Emma")] Emma,
    [EnumMember(Value = "Equip")] Equip,
    [EnumMember(Value = "Espa Roba")] EspaRoba,
    [EnumMember(Value = "Fairy")] Fairy,
    [EnumMember(Value = "Field")] Field,
    [EnumMember(Value = "Fiend")] Fiend,
    [EnumMember(Value = "Fish")] Fish,
    [EnumMember(Value = "Insect")] Insect,
    [EnumMember(Value = "Ishizu Ishtar")] IshizuIshtar,
    [EnumMember(Value = "Ishizu")] Ishizu,
    [EnumMember(Value = "Joey Wheeler")] JoeyWheeler,
    [EnumMember(Value = "Joey")] Joey,
    [EnumMember(Value = "Kaiba")] Kaiba,
    [EnumMember(Value = "Keith")] Keith,
    [EnumMember(Value = "Lumis Umbra")] LumisUmbra,
    [EnumMember(Value = "Machine")] Machine,
    [EnumMember(Value = "Mai Valentine")] MaiValentine,
    [EnumMember(Value = "Mai")] Mai,
    [EnumMember(Value = "Mako")] Mako,
    [EnumMember(Value = "Normal")] Normal,
    [EnumMember(Value = "Odion")] Odion,
    [EnumMember(Value = "Pegasus")] Pegasus,
    [EnumMember(Value = "Plant")] Plant,
    [EnumMember(Value = "Psychic")] Psychic,
    [EnumMember(Value = "Pyro")] Pyro,
    [EnumMember(Value = "Quick-Play")] QuickPlay,
    [EnumMember(Value = "Reptile")] Reptile,
    [EnumMember(Value = "Rex")] Rex,
    [EnumMember(Value = "Ritual")] Ritual,
    [EnumMember(Value = "Rock")] Rock,
    [EnumMember(Value = "Sea Serpent")] SeaSerpent,
    [EnumMember(Value = "Seto Kaiba")] SetoKaiba,
    [EnumMember(Value = "Spellcaster")] Spellcaster,
    [EnumMember(Value = "Tea Gardner")] TeaGardner,
    [EnumMember(Value = "Thunder")] Thunder,
    [EnumMember(Value = "Warrior")] Warrior,
    [EnumMember(Value = "Weevil")] Weevil,
    [EnumMember(Value = "Winged Beast")] WingedBeast,
    [EnumMember(Value = "Wyrm")] Wyrm,
    [EnumMember(Value = "Yami Bakura")] YamiBakura,
    [EnumMember(Value = "Yami Marik")] YamiMarik,
    [EnumMember(Value = "Yami Yugi")] YamiYugi,
    [EnumMember(Value = "Yugi")] Yugi,
    [EnumMember(Value = "Zombie")] Zombie,
}