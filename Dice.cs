namespace mission2;

public class Dice
{
    public int NumberSides { get; }
    private Random Rnd = new Random();
    
    public Dice()
    {
        this.NumberSides = 6;
    }

    public Dice(int sides)
    {
        this.NumberSides = sides;
    }

    public int Roll()
    {
        return Rnd.Next(1, this.NumberSides + 1);
    }
}