/*
 * Coffee
 *  2 Sugar
 *  2 Cream
 *  Extra Syrup
 */

//Beverage myCoffee = new Coffee();
//myCoffee = new AddOnSaltedCaramel(myCoffee);
//myCoffee = new AddOnSaltedCaramel(myCoffee);

//Console.WriteLine(myCoffee.Cost());
//Console.WriteLine(myCoffee.Description());

Beverage myBeverage = new MilkTee();
myBeverage = new AddOnMilk(myBeverage);
myBeverage = new AddOnSpeakingDrink(myBeverage);

Console.WriteLine(myBeverage.Description());
Console.WriteLine(myBeverage.Cost());
Console.WriteLine(myBeverage);
public abstract class Beverage
{
    protected string _description { get; set; }
    public virtual string Description()
    {
        return _description;
    }

    protected double _cost { get; set; }

    public virtual double Cost()
    {
        return _cost;
    }

    public virtual int Milliliters { get; set; }
}

public class Coffee : Beverage
{
    public Coffee()
    {
        _description = "Coffee";
        _cost = 1.5;
    }
}

public class Latte : Beverage
{
    public Latte()
    {
        _description = "Latte Coffee";
        _cost = 1.5;
    }
}

public class Esprreso : Beverage
{
    public Esprreso()
    {
        _description = "Esprreso Coffee";
        _cost = 1.25;
    }
}

public class Tea : Beverage
{
    public Tea()
    {
        _description = "Loose Leaf";
        _cost = 1;
    }
}

public class MilkTee :Beverage
{
    public MilkTee()
    {
        _description = "Milk Tee";
        _cost = 2.0;
    }
}


//add an extra shot of espresso
public abstract class AddOnDecorator : Beverage
{
    public Beverage Beverage { get; set; }
    public abstract override string Description();  // for force to make this function in child class
    public abstract override double Cost(); // for force to make this function in child class

    public virtual void Speak()
    {

    }
    public override int Milliliters { get => base.Milliliters; set => base.Milliliters = value; }




}

public class AddOnSaltedCaramel : AddOnDecorator
{
    public AddOnSaltedCaramel(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override string Description()
    {
        return Beverage.Description() + ", Salted Caramel";
    }

    public override double Cost()
    {
        return Beverage.Cost() + 1.00;
    }
}

public class AddOnMilk : AddOnDecorator
{
    public AddOnMilk(Beverage b)
    {
        Beverage = b;
    }

    public override string Description()
    {
        return Beverage.Description() + " , Milk";
    }
    public override double Cost()
    {
        return Beverage.Cost() + 0.5;
    }
}

public class AddOnSpeakingDrink : AddOnDecorator
{
    public AddOnSpeakingDrink(Beverage b)
    {
        Beverage = b;
    }

    public override string Description()
    {
        return Beverage.Description() + ", Speaking";
    }
    public override double Cost()
    {
        return Beverage.Cost() + 5.00;
    }

    public override void Speak()
    {
        Console.WriteLine($"The beverage is speaking to you. It tells you that it is a {Beverage.Description()} that cost you {Beverage.Cost()} to buy.");
    }
}