using System.Text.Json.Serialization;
using stfc.MitigationCalculator.Common.Converters;

namespace stfc.MitigationCalculator.Common.Models;

[JsonConverter(typeof(JsonCamelCaseStringEnumConverter<DefenderType>))]
public enum DefenderType
{
    Explorer,
    Interceptor,
    Battleship,
    Survey,
    Armada
}