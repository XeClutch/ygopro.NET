using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace YGOPRO.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum CardSetRarity
{
    [EnumMember(Value = "10000 Secret Rare")] SecretRare10000,
    [EnumMember(Value = "Collector's Rare")] CollectorsRare,
    [EnumMember(Value = "Common")] Common,
    [EnumMember(Value = "Duel Terminal Normal Parallel Rare")] DuelTerminalNormalParallelRare,
    [EnumMember(Value = "Duel Terminal Normal Rare Parallel Rare")] DuelTerminalNormalRareParallelRare,
    [EnumMember(Value = "Duel Terminal Rare Parallel Rare")] DuelTerminalRareParallelRare,
    [EnumMember(Value = "Duel Terminal Super Parallel Rare")] DuelTerminalSuperParallelRare,
    [EnumMember(Value = "Duel Terminal Ultra Parallel Rare")] DuelTerminalUltraParallelRare,
    [EnumMember(Value = "Extra Secret Rare")] ExtraSecretRare,
    [EnumMember(Value = "Ghost Rare")] GhostRare,
    [EnumMember(Value = "Ghost/Gold Rare")] GhostGoldRare,
    [EnumMember(Value = "Gold Rare")] GoldRare,
    [EnumMember(Value = "Gold Secret Rare")] GoldSecretRare,
    [EnumMember(Value = "Mosaic Rare")] MosaicRare,
    [EnumMember(Value = "Normal Parallel Rare")] NormalParallelRare,
    [EnumMember(Value = "Platinum Rare")] PlatinumRare,
    [EnumMember(Value = "Platinum Secret Rare")] PlatinumSecretRare,
    [EnumMember(Value = "Premium Gold Rare")] PremiumGoldRare,
    [EnumMember(Value = "Prismatic Secret Rare")] PrismaticSecretRare,
    [EnumMember(Value = "Rare")] Rare,
    [EnumMember(Value = "Secret Rare")] SecretRare,
    [EnumMember(Value = "Shatterfoil Rare")] ShatterfoilRare,
    [EnumMember(Value = "Short Print")] ShortPrint,
    [EnumMember(Value = "Starfoil Rare")] StarfoilRare,
    [EnumMember(Value = "Starlight Rare")] StarlightRare,
    [EnumMember(Value = "Super Parallel Rare")] SuperParallelRare,
    [EnumMember(Value = "Super Rare")] SuperRare,
    [EnumMember(Value = "Super Short Print")] SuperShortPrint,
    [EnumMember(Value = "Ultimate Rare")] UltimateRare,
    [EnumMember(Value = "Ultra Parallel Rare")] UltraParallelRare,
    [EnumMember(Value = "Ultra Rare")] UltraRare,
    [EnumMember(Value = "Ultra Secret Rare")] UltraSecretRare,

}