using Intact.DynamicRendering.Components.Unqork;

namespace Intact.DynamicRendering.Services.AtVantage;

public class AtVantageService : IAtVantageService
{
    private readonly IAtVantageDataService _dataService;
    private readonly IAtVantageProcessorService _processorService;

    public AtVantageService()
    {
        // todo:  Use the Depedency Injection system for this instead of newing up items from the constructor
        //        We have examples of this in dynamic rendering already
        //        Register the IAtVantageDataService and IAtVantageProcessorService with the DI system
        //        Then add them as constructor arguments in this constructor
        _dataService = new AtVantageDataService();
        _processorService = new AtVantageProcessorService();
    }

    public List<UnqorkComponent> GetUnqorkComponents()
    {
        var dataService = new AtVantageDataService();
        var AtVantageData = dataService.GetItems();

        var processor = new AtVantageProcessorService();
        var unqorkComponents = processor.Process(AtVantageData);

        return unqorkComponents;
    }
}

