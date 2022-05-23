var myDuck = new ModelDuck();
myDuck.performFly();
myDuck.setFlyBehavior(new FlyNoway());
myDuck.performFly();

public abstract class Duck {
    public Behavior flyBehavior;
    public Duck()
    {

    }
    public void performFly()
    {
        flyBehavior.fly();
    }
    public void setFlyBehavior(Behavior fb)
    {
        flyBehavior = fb;
    }
}

public interface Behavior
{
    public void fly();
    
}
public class FiyWithWings : Behavior
{
    public void fly()
    {
        Console.WriteLine("I am flying");
    }
    
}
public class FlyNoway : Behavior
{
    public void fly()
    {
        Console.WriteLine("I can't fly");
    }
    
}

public class FlyingFight : Behavior
{
    public void fly()
    {
        Console.WriteLine("I am fighting in the sky");
    }
}

public class ModelDuck : Duck
{

    public ModelDuck()
    {
        flyBehavior = new FlyingFight();
    }
}

public class RedDuct : Duck
{
    
    
    public RedDuct()
    {
        flyBehavior = new FlyingFight();

    }
}

public class BabyDuct : Duck
{
    
    public BabyDuct()
    {
        flyBehavior = new FlyingFight();
    }
}