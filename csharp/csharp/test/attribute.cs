

// Set restrict target
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
// Make Attribute class
public class MySpecialAttribute : Attribute
{
}


[MySpecial]
public class TestClass
{
    public void Run()
    {
    }
}