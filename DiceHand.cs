using System.Runtime.CompilerServices;

namespace mission2;

public class DiceHand
{
    public List<Dice> Dice { get; }
    private List<int[]> HandsRolled { get; }
    private int[] ValuesRolled { get; }
    public int MaxSides { get; }
    public int SecondMaxSides { get; }

    public DiceHand(Dice[] dice)
    {
        if (dice.Length == 0)
            throw new ArgumentException("DiceHand must contain at least one die.");
        this.Dice = new List<Dice>(dice);
        this.HandsRolled = new List<int[]>();
        
        var distinctSides = this.Dice
            .Select(d => d.NumberSides)
            .Distinct()
            .OrderByDescending(x => x)
            .ToList();

        this.MaxSides = distinctSides[0];
        this.SecondMaxSides = distinctSides.Count > 1 ? distinctSides[1] : distinctSides[0];


        this.ValuesRolled = CreateValuesArray();

    }

    private void RollHand()
    {
        int[] rollValues = new int[this.Dice.Count];

        for (int i = 0; i < this.Dice.Count; i++)
        {
            rollValues[i] = this.Dice[i].Roll();
        }

        int sum = rollValues.Sum();
        this.ValuesRolled[sum]++;
        this.HandsRolled.Add(rollValues);
    }

    private int[] CreateValuesArray()
    {

        int minSum = this.Dice.Count();
        int maxSum = this.Dice.Sum(d => d.NumberSides);
        
        int[] valuesRolledInit = new int[maxSum + 1];
        
        for (int sum = minSum; sum <= maxSum; sum++)
        {
            valuesRolledInit[sum] = 0;
        }
        
        return valuesRolledInit;
    }

    public int[] RollManyHands(int numRolls)
    {
        for (int i = 0; i < numRolls; i++)
        {
            this.RollHand();
        }
        
        // System.Console.WriteLine("Hands Rolled: ");
        // foreach (var roll in this.HandsRolled)
        // {
        //     System.Console.WriteLine(string.Join(", ", roll));
        // }
        
        return this.ValuesRolled;
        
    }
}