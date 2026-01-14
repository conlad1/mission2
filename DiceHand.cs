using System.Runtime.CompilerServices;

namespace mission2;

public class DiceHand
{
    private List<Dice> Dice { get; }
    private List<int[]> HandsRolled { get; }
    private Dictionary<int, int> ValuesRolled { get; }
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


        this.ValuesRolled = CreateValuesDictionary();

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

    private Dictionary<int, int> CreateValuesDictionary()
    {
        Dictionary<int, int> valuesRolledInit = new();

        int minSum = this.Dice.Count();
        int maxSum = this.Dice.Sum(d => d.NumberSides);
        
        for (int sum = minSum; sum <= maxSum; sum++)
        {
            valuesRolledInit[sum] = 0;
        }
        
        return valuesRolledInit;
    }

    public void RollManyHands(int numRolls)
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
        
        System.Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS" +
                                 "\nEach \"*\" represents 1% of the total number of rolls." +
                                 $"\nTotal number of rolls = {numRolls}.\n");
        foreach (var kvp in this.ValuesRolled)
        { 
            decimal percentage = (kvp.Value / (decimal)numRolls) * 100;
            int percent = (int)Math.Round(percentage, MidpointRounding.AwayFromZero); // 3
            string astk = new String('*', percent);
            
            System.Console.WriteLine($"Hand Sum {kvp.Key}: \t{astk}");
        }

        
    }
}