using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YGOPRO.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CardAttribute
{
    [EnumMember(Value = "DARK")] Dark,
    [EnumMember(Value = "DIVINE")] Divine,
    [EnumMember(Value = "EARTH")] Earth,
    [EnumMember(Value = "FIRE")] Fire,
    [EnumMember(Value = "LIGHT")] Light,
    [EnumMember(Value = "WATER")] Water,
    [EnumMember(Value = "WIND")] Wind,
}