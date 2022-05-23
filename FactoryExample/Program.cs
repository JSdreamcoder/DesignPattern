interface IClient
{
    public string UserName { get; set; }
    string UserAuthString { get; set; }
    bool HasAccess { get; set; }
    void BuildAuthString();
}
interface IAccessBehaviour
{
    IClient Client { get; set; }
    void HandleAccess();
}
public class User : IClient
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = false;
    public void BuildAuthString()
    {
    }
}
public class Manager : IClient
{
    public Manager(string userName, string userAuthString)
    {
        UserName = userName;
        UserAuthString = userAuthString + "MAN";
    }
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = true;
    public void BuildAuthString()
    {
    }
}
public class Admin : IClient
{
    public Admin(string userName, string userAuthString)
    {
        UserName = userName;
        UserAuthString = userAuthString + "ADMIN";
    }
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; } = true;
    public void BuildAuthString()
    {
    }
}
public class CheckString : IAccessBehaviour
{
    IClient IAccessBehaviour.Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public void HandleAccess()
    {
        // (which checks if the Client’s UserAuthString ends with “ADMIN” and returns the result as a boolean)
    }
}
public class SwitchAuth : IAccessBehaviour
{
    IClient IAccessBehaviour.Client { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public void HandleAccess()
    {
        // which returns the Client’s HasAccess property, and then switches that property’s value
    }
}
//public abstract class ClientFactory
//{
//    public IClient BuildUser(string clientType)
//    {
//    }
//}