namespace Intact.DynamicRendering.Components.Unqork;

// I don't know exactly what Unqork needs to render....this is a placeholder for it
public class GenericUnqorkComponent : UnqorkComponent
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public ICollection<UnqorkComponent> Children { get; set; } = [];
}
