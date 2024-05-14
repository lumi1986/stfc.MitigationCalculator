using System.Text.Json;
using System.Text.Json.Serialization;

namespace stfc.MitigationCalculator.Common.Converters;

public class JsonCamelCaseStringEnumConverter<TEnum>() : 
    JsonStringEnumConverter<TEnum>(JsonNamingPolicy.CamelCase) where TEnum : struct, Enum;