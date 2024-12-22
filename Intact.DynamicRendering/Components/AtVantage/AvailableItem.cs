using Newtonsoft.Json;

namespace Intact.DynamicRendering.Components.AtVantage;

public class AvailableItem
{
    [JsonProperty("itemTypeUID")]
    public int? ItemTypeUID { get; set; }

    [JsonProperty("itemDSC")]
    public string ItemDSC { get; set; } = string.Empty; //section label/header

    [JsonProperty("availableItemOptionComposites")]
    public List<AvailableItemOptionComposite> AvailableItemOptionComposites { get; set; } = []; //nested fields
}
