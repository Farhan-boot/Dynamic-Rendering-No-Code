using Newtonsoft.Json;

namespace Intact.DynamicRendering.Components.AtVantage;

public class AvailableItemOptionComposite
{
    [JsonProperty("itemTypeUID")]
    public int ItemTypeUID { get; set; }

    [JsonProperty("itemOptionUID")]
    public int ItemOptionUID { get; set; }

    [JsonProperty("defaultNumNBR")]
    public int? DefaultNumNBR { get; set; }

    [JsonProperty("defaultTextDSC")]
    public string DefaultTextDSC { get; set; } = string.Empty;

    [JsonProperty("displayIND")]
    public int DisplayIND { get; set; } = 1;

    [JsonProperty("displayMaskDSC")]
    public string DisplayMaskDSC { get; set; } = string.Empty;

    [JsonProperty("itemOptionDSC")]
    public string ItemOptionDSC { get; set; } = string.Empty;

    [JsonProperty("itemOptionValueDSC")]
    public string ItemOptionValueDSC { get; set; } = string.Empty; //todo: make into an enum for Text, Number, Date

    [JsonProperty("protectIND")]
    public int ProtectIND { get; set; } = 0;

    [JsonProperty("rangeMaxNBR")]
    public int? RangeMaxNBR { get; set; }

    [JsonProperty("rangeMinNBR")]
    public int? RangeMinNBR { get; set; }

    [JsonProperty("requiredOptionIND")]
    public int RequiredOptionIND { get; set; }

    [JsonProperty("valueLengthNBR")]
    public int ValueLengthNBR { get; set; }

    [JsonProperty("widgetTypeDSC")]
    public string WidgetTypeDSC { get; set; } = string.Empty;
}
