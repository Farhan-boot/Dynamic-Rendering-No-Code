namespace Intact.DynamicRendering.Components.Unqork;

public class Number : UnqorkComponent
{
    public new string Type { get; set; } = "number";
    public bool Disabled { get; set; } = false;
    public int DecimalLimit { get; set; } = 2;
    public string DecimalCharacter { get; set; } = "locale";
    public int Step { get; set; } = 2;
    public bool DisallowDecimal { get; set; } = false;
    public bool ShowThousandsSeparator { get; set; } = true;
    public double? DefaultValue { get; set; }
}
