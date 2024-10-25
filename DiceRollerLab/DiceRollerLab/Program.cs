GreetUser();
int diceSideNumber = GetDiceSides();
int rollNumber = 1;

do
{
    Console.WriteLine();

    Console.WriteLine($"Roll {rollNumber}:");
    int firstDie = RollDice(diceSideNumber);
    int secondDie = RollDice(diceSideNumber);
    Console.WriteLine($"You rolled a {firstDie} and a {secondDie}. ({firstDie + secondDie} total)");

    string comparisonSixSidedDice = CompareSixSidedDice(firstDie, secondDie);
    if (comparisonSixSidedDice != "")
    {
        Console.WriteLine(comparisonSixSidedDice);
    }

    string winner = GetWinner(firstDie, secondDie);
    if (winner != "")
    {
        Console.WriteLine(winner);  
    }
    
    if (RunGameAgain())
    {
        rollNumber++;
        continue;
    }
    else
    {
        Console.WriteLine("Thanks for playing!!");
        break;
    }

} while (true);


int GetDiceSides()
{
    Console.WriteLine("How many sides should each die have?");
    string diceSidesString = Console.ReadLine();
    ushort diceSides = 0;
    bool isValidDice = ushort.TryParse(diceSidesString, out diceSides);
    

    while (!isValidDice || diceSides == 0)
    {
        Console.WriteLine("Please enter a valid integer");
        diceSidesString = Console.ReadLine();
        isValidDice = ushort.TryParse(diceSidesString, out diceSides);
    }
    
    return diceSides;
}

int RollDice(int diceSides)
{
    Random RandomObject = new Random();
    int rollDice = RandomObject.Next(1, diceSides + 1);
    return rollDice;
}

string CompareSixSidedDice (int firstDie , int secondDie)
{
    string result = "";

    if (firstDie == 1 && secondDie == 1)
    {
        result = "Snake Eyes";
    }
    else if ((firstDie == 1 && secondDie == 2) || (firstDie == 2 && secondDie == 1))
    {
        result = "Ace Deuce"; 
    }
    else if (firstDie == 6 && secondDie == 6)
    {
        result = "Box Cars";
    }
    
    return result;
}

string GetWinner(int firstDie, int secondDie)
{
    int sumDice = firstDie + secondDie;
    string winner = "";

    if (sumDice == 7 || sumDice == 11)
    {
        winner = "Win";
    }
    else if (sumDice == 2 || sumDice == 3 || sumDice == 12)
    {
        winner = "Craps";
    }

    return winner;
}

void GreetUser()
{
    Console.WriteLine("Welcome to the Grand Circus Casino!");
}

bool RunGameAgain()
{
    bool isPlayingAgain = false;
    Console.WriteLine("Roll Again (y/n)?");
    string userAnswer = Console.ReadLine();
    

    if (userAnswer.ToLower() == "y")
    {
        isPlayingAgain = true;
        
    }
    else if (userAnswer.ToLower() == "n")
    {
        isPlayingAgain = false;
        
    }
    else
    {
        Console.WriteLine("You entered an invalid responce. Please try again.");
        isPlayingAgain = RunGameAgain();
    }
    return isPlayingAgain;
}