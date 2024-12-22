using Intact.DynamicRendering.Components.AtVantage;
using Intact.DynamicRendering.Components.Unqork;

namespace Intact.DynamicRendering.Services.AtVantage;

public interface IAtVantageProcessorService
{
    List<UnqorkComponent> Process(List<AvailableItemGroup> items);
}
