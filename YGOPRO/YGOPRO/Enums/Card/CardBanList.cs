using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YGOPRO.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CardBanList
{
    [EnumMember(Value = "TCG")] TCG,
    [EnumMember(Value = "OCG")] OCG,
    [EnumMember(Value = "GOAT")] GOAT
}