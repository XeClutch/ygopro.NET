using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YGOPRO.Enums;


[JsonConverter(typeof(StringEnumConverter))]
public enum CardFormat
{
    [EnumMember(Value = "TCG")] TCG,
    [EnumMember(Value = "Goat")] Goat,
    [EnumMember(Value = "OCG Goat")] OcgGoat,
    [EnumMember(Value = "Speed Duel")] SpeedDuel,
    [EnumMember(Value = "Rush Duel")] RushDuel,
    [EnumMember(Value = "Duel Links")] DuelLinks
}