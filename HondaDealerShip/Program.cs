//► At a Honda dealership, people can choose to buy a car from a
//large selection of new cars.
//► All new cars have properties like(Year, Model, Base Price, Color,
//Body Type).
//► After choosing the car they want, customers can select from a
//wide range of upgrades.
//► Upgrades include (Leather Seats, Ignition Button, Hybrid Engine),
//each upgrade costs extra money.
//► Create an OOP design to model this system.
//► Add “Alloy Rims” to the set of upgrade

Car mycar = new Golf();
Console.WriteLine(mycar.Price);
mycar.Details();
Console.WriteLine();    
mycar = new AddLeatherSeats(mycar);
Console.WriteLine(mycar.Price);
mycar.Details();
Console.WriteLine();
mycar = new AddEgnitionButtoen(mycar);
Console.WriteLine(mycar.Price);
mycar.Details();
Console.WriteLine();
mycar = new AddHybridEngine(mycar);

Console.WriteLine(mycar.Price);
mycar.Details();
Console.WriteLine();


public abstract class Car
{
    protected int Year { get; set; }
    protected string Model { get; set; }
    public virtual double Price { get; set; }
    protected string Color { get; set; }
    protected string BodyType { get; set; }

   
    public virtual void AddCost(double cost)
    {
        Price += cost;
    }
    public virtual void Details()
    {
        Console.WriteLine("Thanks for buyning Car, Your Car is ");
        Console.WriteLine($"Year : {Year}");
        Console.WriteLine($"Model : {Model}");
        Console.WriteLine($"Price : {Price}");
        Console.WriteLine($"Color : {Color}");
        Console.WriteLine($"BodyType : {BodyType}");
    }

}

public class Golf : Car
{
    public Golf()
    {
        Year = 2022;
        Model = "Golf";
        Price = 20000;
        Color = "White";
        BodyType = "Coupe";
    }
}

public abstract class Upgrade : Car
{
   
    public abstract override void Details();
    public Car MyCar { get; set; }
    public override double Price { get => MyCar.Price; set => MyCar.Price = value; }
    

}

public class AddLeatherSeats : Upgrade
{
    double Cost = 1000.00;
   
    public AddLeatherSeats(Car car)
    {
        
        MyCar = car;
        MyCar.Price += Cost;
        
        
    }

    public override void Details()
    {
        
        MyCar.Details();
        Console.WriteLine($"Upgrade : Leader Seats(${Cost})");
    }

}

public class AddEgnitionButtoen : Upgrade
{
    double Cost = 1500.00;
   
    public AddEgnitionButtoen(Car car)
    {
        MyCar = car;
        MyCar.Price += Cost;

    }
  
    public override void Details()
    {
        
        MyCar.Details();
        Console.WriteLine($"Upgrade : Egnition Button(${Cost})");
    }

}

public class AddHybridEngine : Upgrade
{
    double Cost = 5000.00;
   
    public AddHybridEngine(Car car)
    {
        MyCar = car;
        MyCar.Price += Cost;

    }
   
    public override void Details()
    {
        
        MyCar.Details();
        Console.WriteLine($"Upgrade : Hybrid Engine(${Cost})");
    }

}