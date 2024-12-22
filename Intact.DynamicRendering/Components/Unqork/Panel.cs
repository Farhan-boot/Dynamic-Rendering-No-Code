namespace Intact.DynamicRendering.Components.Unqork;
public class Panel : UnqorkComponent
{
    public bool Modal { get; set; } = false;
    public bool OutsideDismiss { get; set; } = false;
    public bool TableView { get; set; } = false;
    public string Theme { get; set; } = "default";
    public string Title { get; internal set; } = string.Empty;
}
