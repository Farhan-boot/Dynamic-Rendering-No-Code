using Intact.DynamicRendering.Components.AtVantage;
using Intact.DynamicRendering.Components.Unqork;

namespace Intact.DynamicRendering.Services.AtVantage;

public class AtVantageProcessorService : IAtVantageProcessorService
{
    public List<UnqorkComponent> Process(List<AvailableItemGroup> items)
    {
        var nodes = new List<UnqorkComponent>();

        foreach (var item in items)
        {
            var node = ProcessItem(item);
            nodes.Add(node);
        }

        return nodes;
    }

    private static UnqorkComponent ProcessItem(AvailableItemGroup item)
    {
        var node = new GenericUnqorkComponent
        {
            Id = item.ItemTypeUID,
            Description = item.AvailableItem.ItemDSC,
            Children = []
        };

        if (item.AvailableItem == null || item.AvailableItem.AvailableItemOptionComposites == null)
        {
            return node;
        }

        foreach (var option in item.AvailableItem.AvailableItemOptionComposites)
        {
            // each one of these might really be a factory method on a factory class instead of inline in a switch statement; it depends how complicated the code becomes

            UnqorkComponent childNode;

            switch (option.WidgetTypeDSC)
            {
                case "Checkbox":
                    {
                        childNode = new Checkbox { };
                        break;
                    }
                case "Data Field":
                    {
                        childNode = new TextField { };
                        break;
                    }
                default:
                    {
                        childNode = new TextField { };
                        break;
                    }
            }
            childNode.Key = String.Concat(option.ItemOptionUID, option.ItemTypeUID);
            childNode.Label = option.ItemOptionDSC;

            node.Children.Add(childNode);
        }

        return node;
    }
}

