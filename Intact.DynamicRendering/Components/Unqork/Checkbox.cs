namespace Intact.DynamicRendering.Components.Unqork;

public class Checkbox : UnqorkComponent
{
    public new string Type { get; set; } = "checkboxv2";
    public new string CustomClass { get; set; } = "mb-0";
    public bool Disabled { get; set; } = false;
    public string Trigger { get; set; } = string.Empty;
}
