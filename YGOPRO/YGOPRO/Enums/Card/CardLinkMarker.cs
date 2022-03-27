using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YGOPRO.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CardLinkMarker
{
    [EnumMember(Value = "Top")] Top,
    [EnumMember(Value = "Bottom")] Bottom,
    [EnumMember(Value = "Left")] Left,
    [EnumMember(Value = "Right")] Right,
    [EnumMember(Value = "Bottom-Left")] BottomLeft,
    [EnumMember(Value = "Bottom-Right")] BottomRight,
    [EnumMember(Value = "Top-Left")] TopLeft,
    [EnumMember(Value = "Top-Right")] TopRight
}