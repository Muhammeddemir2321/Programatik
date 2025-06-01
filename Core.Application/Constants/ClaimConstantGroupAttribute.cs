namespace Core.Application.Constants;

public class ClaimConstantGroupAttribute:Attribute
{
    public string GroupName { get; }
    public ClaimConstantGroupAttribute(string groupName) => GroupName = groupName;
}
