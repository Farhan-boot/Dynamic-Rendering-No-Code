using Newtonsoft.Json;

namespace Intact.DynamicRendering.Components.AtVantage;

public class AvailableItemGroup
{
    [JsonProperty("itemTypeUID")]
    public int ItemTypeUID { get; set; }

    [JsonProperty("displayOrderNBR")]
    public int DisplayOrderNBR { get; set; }

    [JsonProperty("itemMaxNBR")]
    public int ItemMaxNBR { get; set; } //repeatability: 1 = one time on screen, >1 = inside of a uniform grid

    [JsonProperty("availableItem")]
    public AvailableItem AvailableItem { get; set; } = new();
}
