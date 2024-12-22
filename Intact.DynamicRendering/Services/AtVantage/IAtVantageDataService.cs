using Intact.DynamicRendering.Components.AtVantage;

namespace Intact.DynamicRendering.Services.AtVantage;

public interface IAtVantageDataService
{
    List<AvailableItemGroup> GetItems(/* TODO add whatever params are needed to call @Vantage for it's JSON data*/);
}
