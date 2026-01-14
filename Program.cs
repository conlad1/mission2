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
        hand.RollManyHands(numRolls);
        
        System.Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }
}