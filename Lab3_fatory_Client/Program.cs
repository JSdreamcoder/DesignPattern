
public abstract class ClientHandler
{
    public ClientFactory ClientFactory { get; set; }

    public abstract Client CreateClient(string type, string name);
}

public class RetailClientHandler : ClientHandler
{
    public RetailClientHandler()
    {
        ClientFactory = new ClientFactory();
    }

    public override Client CreateClient(string type, string name)
    {
        return ClientFactory.CreateClient(type, name);
    }

}

public class EnterpriseClientHandler : ClientHandler
{
    AccessBehaviour AccessBehaviour { get; set; }
    public EnterpriseClientHandler()
    {
        ClientFactory = new ClientFactory();
        AccessBehaviour = new CheckStiring();
    }

    public override Client CreateClient(string type, string name)
    {
        return ClientFactory.CreateClient(type, name);
    }
}

public class ClientFactory 
{
    public Client CreateClient(string type, string name)
    {
        Client newClient = new User(name);
        if (type == "Manager")
        {
            newClient = new Manager(name);
        }
        else if (type == "Admin")
        {
            newClient = new Admin(name);
        }

        newClient.BuilAuthString(name);
        return newClient;
    }
}

public interface Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }
    public bool HasAccess { get; set; }
    public void BuilAuthString(string UserName);
    
}

public class User : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get;  set; }

    public bool HasAccess { set; get; }

    public User(string name)
    {
        UserName = name;
        HasAccess = false;
    }
    public void BuilAuthString( string UserName)
    {
        UserAuthString = UserName;  
    }
}

public class Manager : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }

    public bool HasAccess { set; get; }

    public Manager(string name)
    {
        UserName=name;
        HasAccess = true;
    }
    public void BuilAuthString(string UserName)
    {
        UserAuthString = UserName+"ADMIN";
    }
}

public class Admin : Client
{
    public string UserName { get; set; }
    public string UserAuthString { get; set; }

    public bool HasAccess { set; get; }

    public Admin(string name)
    {
        UserName = name;
        HasAccess = true;
    }
    public void BuilAuthString(string UserName)
    {
        UserAuthString = UserName + "ADMIN";
    }
}

public interface AccessBehaviour
{
    public Client Client { get; set; }

    public bool HandleAccess(Client User);
}

public class CheckStiring : AccessBehaviour
{
    public Client Client { set; get; }

    public CheckStiring()
    {
        
    }
    public bool HandleAccess(Client user)
    {
        var original = user.UserAuthString;
        bool result = false;
        if(original.Substring(original.Length-5) == "ADMIN")
            result = true;

        return result;
    }
}

public class SwichAuth : AccessBehaviour
{
    public Client Client { set; get; }

    public bool HandleAccess(Client user)
    {
        if (user.HasAccess)
        {
            user.HasAccess = false;
        }else if (!user.HasAccess)
        {
            user.HasAccess=true;
        }

        return user.HasAccess;
    }
}