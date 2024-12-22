namespace Intact.DynamicRendering.Components.Unqork;

public class UniformGrid : UnqorkComponent
{
    public static new string Type { get; set; } = "inlineGrid";
    public bool Collapsed { get; set; } = false;
    public string EditOption { get; set; } = "Full grid editable";
    public string DisplayPattern { get; set; } = "Inline";
    public string SelectedLabelView { get; set; } = "labelInline";
    public string CreateNewLabel { get; set; } = "Add New";
    public bool CustomizeButtonStyling { get; set; } = true;
    public List<ValidationNumber> Validate { get; set; } = [];
    public List<ValidationString> Errors { get; set; } = []; //this is a necessary overwrite due to the JSON structure of uniform grids
    public string CreateCustomClass { get; set; } = "btn-padding-xs";
    public string CreateLeftIcon { get; set; } = "add-circle-white";
    public string DeleteCustomClass { get; set; } = "btn-outline-ff add-border";
    public string DeleteLeftIcon { get; set; } = "trash-teal-icon";
}

public class ValidationString
{
    public string ArrayMinLength { get; set; } = string.Empty;
}

public class ValidationNumber
{
    public int ArrayMinLength { get; set; } = 0;
}
