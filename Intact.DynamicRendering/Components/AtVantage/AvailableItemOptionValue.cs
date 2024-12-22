using Newtonsoft.Json;

namespace Intact.DynamicRendering.Components.AtVantage;

public class AvailableItemOptionValue
{
    [JsonProperty("itemTypeUID")]
    public int ItemTypeUID { get; set; }

    [JsonProperty("itemOptionUID")]
    public int ItemOptionUID { get; set; }

    [JsonProperty("itemOptionSeqNBR")]
    public int ItemOptionSeqNBR { get; set; }

    [JsonProperty("valueDecimalNBR")]
    public int ValueDecimalNBR { get; set; }

    [JsonProperty("valueTextDSC")]
    public string ValueTextDSC { get; set; } = string.Empty;
}
