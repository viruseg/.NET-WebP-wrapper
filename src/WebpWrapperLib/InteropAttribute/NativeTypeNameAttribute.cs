namespace WebpWrapperLib.InteropAttribute;

[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = false)]
internal sealed class NativeTypeNameAttribute : Attribute
{
    public string Name { get; }

    public NativeTypeNameAttribute(string name)
    {
        Name = name;
    }
}