public abstract class Duck {
    public FlyBehavior flyBehavior;
    public Duck()
    {

    }
    public void performFly()
    {
        flyBehavior.fly();
    }
    public void setFlyBehavior(FlyBehavior fb)
    {
        flyBehavior = fb;
    }
}

public interface FlyBehavior
{
    public void fly();
}
public class FiyWithWings : FlyBehavior
{
    public void fly()
    {
        Console.WriteLine("I am flying");
    }
}
public class FlyNoway : FlyBehavior
{
    public void fly()
    {
        Console.WriteLine("I can't fly");
    }
}

public class ModelDuck : Duck
{
    public ModelDuck()
    {
        flyBehavior = new FlyNoway();
    }
}