Vehicle MyCar = new Civic();
Civic civic = new Civic();
//Console.WriteLine(MyCar.specific);
MyCar = new UpgradeLeaderSeats(MyCar);
Console.WriteLine(MyCar.GrandTotal());
MyCar = new UpgradeIgnitionButton(MyCar);
Console.WriteLine(MyCar.GrandTotal());
MyCar = new UpgradeHybridEngine(MyCar);

Console.WriteLine(MyCar.GrandTotal());

public abstract class Vehicle
{
    public DateTime Year { get; set; }
    public virtual string Model { get; set; }
    protected virtual double BasePrice { get; set; }
    public virtual double GrandTotal()
    {
        return BasePrice;
    }

    public virtual string Coluor { get; set; }
    public virtual string BodyType { get; set; }

}

public class Civic : Vehicle
{
    public string specific { get; set; }
    public Civic()
    {
        Year = DateTime.Now;
        Model = "Honda Civic";
        Coluor = "Slate Grey";
        BodyType = "Sedan";
        BasePrice = 20000;
        specific = " aaaaa";
    }
}
public class Accord : Vehicle
{
    public Accord()
    {
        Year = DateTime.Now;
        Model = "Honda Accord";
        Coluor = "Rainbow";
        BodyType = "Sedan";
        BasePrice = 30000;
    }
}
public abstract class Upgrade : Vehicle
{
    public Vehicle Vehicle { get; set; }
    //public abstract override double GrandTotal();
    //public override string BodyType { get => Vehicle.BodyType; set => Vehicle.BodyType = value; }
    //public override string Model { get => Vehicle.Model; set => Vehicle.Model = value; }
    //public override string Coluor { get => Vehicle.Coluor; set => Vehicle.Coluor = value; }
    

}

public class UpgradeLeaderSeats : Upgrade
{
    public UpgradeLeaderSeats(Vehicle v)
    {
        Vehicle = v;
    }
    public override double GrandTotal()
    {
        return Vehicle.GrandTotal() +800;
    }
}

public class UpgradeIgnitionButton : Upgrade
{
    public UpgradeIgnitionButton(Vehicle v)
    {
        Vehicle = v;
    }
    public override double GrandTotal()
    {
        return Vehicle.GrandTotal() +200;
    }
}

public class UpgradeHybridEngine : Upgrade
{
    public UpgradeHybridEngine(Vehicle v)
    {
        Vehicle = v;
    }
    public override double GrandTotal()
    {
        return Vehicle.GrandTotal() + 4000;
    }
}