  
var worrier = new Player();
var goblin = new Goblin();
var lich = new Lich();
 
var fightsystem = new FightSystem();
fightsystem.fight(worrier, lich);




public class FightSystem
{
    public void fight(Player p, Enemy enemy)
    {
        while (p.MaxHP > 0 && enemy.MaxHP > 0)
        {
            p.Defence(enemy);
            var previousHP = enemy.MaxHP;
            enemy.Defence(p);
            var afterfightHP = enemy.MaxHP;
            if (afterfightHP >= previousHP)
            {
                Console.WriteLine("Player can't damage to enemy");
                Console.WriteLine("Player needs Special Weapon");
                Console.WriteLine("Please choose a speacial weapon");
                Console.WriteLine("1. Silver Justice");
                Console.WriteLine("2. Excaliver");
                var selectedWeopon = Console.ReadLine();
                if (selectedWeopon == "1")
                {
                    var silverjustice = new SilverJustice(p);
                    Console.WriteLine("Player equips SiverJustice");
                }else if (selectedWeopon == "2")
                {
                    var excaliver = new Excaliver(p);
                    Console.WriteLine("Player equips Excaliver");
                }
            }
        }
        if (p.MaxHP < 0)
        {
            Console.WriteLine("player died");

        }else
        {
            Console.WriteLine("enemy died");
        }
    }
}

public class Player
{
    public virtual int Strength { get; set; }
    public int MaxHP { get; set; }

    public int DefencePower { get; set; }

    public virtual int ExercismPower { get; set; }

    public Player()
    {
        Strength = 10;
        MaxHP = 50;
        DefencePower = 2;
        ExercismPower = 0;
    }
    public void Defence(Enemy enemy)
    {
        MaxHP -= (enemy.Strength-DefencePower);
        Console.WriteLine($"Player damaged {(enemy.Strength - DefencePower)} (remained HP :{MaxHP})");
    }

}

public abstract class Enemy
{
    public int Strength { get; set; }
    public int MaxHP { get; set; }
    public int DefencePower { get; set; }

    public virtual void Defence(Player player)
    {
        MaxHP -= (player.Strength-DefencePower);
        Console.WriteLine($"damaged {(player.Strength - DefencePower)} (remained HP :{MaxHP})");
    }
    
}

public class Goblin : Enemy
{
    public Goblin()
    {
        Strength = 5;
        MaxHP = 30;
        DefencePower = 5;
    }
    public override void Defence(Player player)
    {
        Console.WriteLine("Goblin ");
        base.Defence(player);

    }
}

public class Lich : Enemy
{
    public Lich()
    {
        Strength = 20;
        MaxHP = 100;
        DefencePower = 20;
    }

    public override void Defence(Player player)
    {


        MaxHP -= (player.ExercismPower - DefencePower);

        Console.WriteLine($"Lich damaged {(player.ExercismPower - DefencePower)} (remained HP :{MaxHP})");
    }
}

public abstract class Weapon : Player
{
    public Player player { get; set; }

    

    public override int ExercismPower { get => base.ExercismPower; set => base.ExercismPower = value; }
    public override int Strength { get => base.Strength; set => base.Strength = value; }

}

public class SilverJustice : Weapon
{
    public SilverJustice(Player p)
    {
        player = p;
        player.ExercismPower += 50;
    }
}


public class Excaliver : Weapon
{
    public Excaliver(Player p)
    {
        player = p;
        player.Strength += 100;
    }
}