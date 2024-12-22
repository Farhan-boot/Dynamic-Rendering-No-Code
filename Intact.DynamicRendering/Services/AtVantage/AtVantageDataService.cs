using Intact.DynamicRendering.Components.AtVantage;
using Newtonsoft.Json;

namespace Intact.DynamicRendering.Services.AtVantage;

public class AtVantageDataService : IAtVantageDataService
{
    public List<AvailableItemGroup> GetItems(/* TODO add whatever params are needed to call @Vantage for it's JSON data*/)
    {
        // Retrieve the @Vantage data from their system
        // we are using JSON files for simplicity here

        // Read JSON file and deserialize it into a list of Item objects
        var baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        string jsonPath = "output/SideADIC.json";
        string jsonData = File.ReadAllText(Path.Combine(baseDirectory, jsonPath));

        var settings = new JsonSerializerSettings
        {
            Error = (sender, args) =>
            {
                Console.WriteLine($"Error deserializing {args.ErrorContext.Member}: {args.ErrorContext.Error.Message}");
                args.ErrorContext.Handled = true; // To continue processing even if errors are encountered
            }
        };

        var items = JsonConvert.DeserializeObject<List<AvailableItemGroup>>(jsonData, settings);

        return items;
    }
}
