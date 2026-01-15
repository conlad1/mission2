namespace mission2;

class Program
{
    static void Main(string[] args)
    {
        
        System.Console.WriteLine("Welcome to the dice throwing simulator!");
        
        System.Console.WriteLine("\nHow many dice to roll in your hand?");
        int numDice = int.Parse(System.Console.ReadLine());
        
        System.Console.WriteLine("How many sides on each dice?");
        int numSides = int.Parse(System.Console.ReadLine());
        
        System.Console.WriteLine("How many dice rolls would you like to simulate?");
        int numRolls = int.Parse(System.Console.ReadLine());

        Dice[] dice = new Dice[numDice];
        for (int i = 0; i < numDice; i++)
        {
            dice[i] = new Dice(numSides);
        }

        DiceHand hand = new DiceHand(dice);
        int[] ValuesRolled = hand.RollManyHands(numRolls);
        
        System.Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS" +
                                 "\nEach \"*\" represents 1% of the total number of rolls." +
                                 $"\nTotal number of rolls = {numRolls}.\n");
        int minSum = hand.Dice.Count();
        for (int i = minSum; i < ValuesRolled.Length; i++)
        { 
            decimal percentage = (ValuesRolled[i] / (decimal)numRolls) * 100;
            int percent = (int)Math.Round(percentage, MidpointRounding.AwayFromZero); // 3
            string astk = new String('*', percent);
            
            System.Console.WriteLine($"Hand Sum {i}: \t{astk}");
        }
        
        System.Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}