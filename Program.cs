namespace MonsterkampfSimulator;

class Program
{
    private static ConsoleColor copColor = ConsoleColor.DarkBlue;
    private static ConsoleColor antifaColor = ConsoleColor.DarkRed;
    private static ConsoleColor hooliganColor = ConsoleColor.DarkYellow;

    private static ConsoleColor errorColor = ConsoleColor.Red;
    private static ConsoleColor menuColor = ConsoleColor.Gray;
    private static ConsoleColor gameColor = Console.ForegroundColor;

    private static Fighter firstFighter = null;
    private static Fighter secondFighter = null;

    private static float newHLT;
    private static float newATK;
    private static float newDEF;
    private static float newSPD;

    private const int maxTurn = 99;

    static void Main(string[] args)
    {
        while (true)
        {
            Start();
            SetUpFighters();
            GameLoop();
        }
    }

    private static void Start()
    {
        Console.Clear();
        ColoredWrite("NEWS: ", errorColor);
        Console.WriteLine("A large demonstration escalated today. A battle has broken out between different groups.");
        Console.ReadKey();
    }

    private static void SetUpFighters()
    {
        Console.ForegroundColor = menuColor;

        EType firstFighterType = ChooseFighterType("first");
        firstFighter = RegistrateFighter(firstFighterType);
        ColoredWrite($"{firstFighter.Race}", firstFighter.Color);
        Console.WriteLine(" has arrived!");
        Console.ReadKey();

        EType secondFighterType;
        do
        {
            secondFighterType = ChooseFighterType("second");

            if (firstFighterType == secondFighterType)
            {
                OccuringError("ERROR: Fighters from the same social-class doesnt fight each other.");
            }

        }
        while (firstFighterType == secondFighterType);

        secondFighter = RegistrateFighter(secondFighterType);
        ColoredWrite($"{secondFighter.Race}", secondFighter.Color);
        Console.WriteLine(" has arrived!");
        Console.ReadKey();

        Console.ForegroundColor = gameColor;

        Console.Clear();

        Console.Write("On the one side stood the ");
        ColoredWrite($"{firstFighter.Race}", firstFighter.Color);
        Console.Write($", on the other side the ");
        ColoredWrite($"{secondFighter.Race}", secondFighter.Color);
        Console.Write(".\n\n");
        Console.ReadKey();

    }

    private static void GameLoop()
    {
        Fighter firstToAttack;
        Fighter secondToAttack;

        if (firstFighter.Spd > secondFighter.Spd)
        {
            firstToAttack = firstFighter;
            secondToAttack = secondFighter;
        }
        else
        {
            secondToAttack = firstFighter;
            firstToAttack = secondFighter;
        }
        firstToAttack.isFirstToAttack = true;

        ColoredWrite($"{firstToAttack.Race}", firstToAttack.Color);
        Console.WriteLine(" has attacked first.");

        Console.ReadKey(true);

        int turn = 1;

        while (!firstToAttack.IsDead && !secondToAttack.IsDead)
        {
            Console.Write($"{turn}. ");
            firstToAttack.Attack(secondToAttack);
            Console.ReadKey(true);
            turn++;

            if (secondToAttack.IsDead)
                break;

            Console.Write($"{turn}. ");
            secondToAttack.Attack(firstToAttack);
            Console.ReadKey(true);
            turn++;

            if (hasOversteppedMaximalTurns(turn))
            {
                break;
            }
        }

        Console.Clear();

        if (firstToAttack.IsDead)
        {
            secondToAttack.PrintWinningText();
        }
        else if (secondToAttack.IsDead)
        {
            firstToAttack.PrintWinningText();
        }
        else
        {
            Console.WriteLine("The situation ended in a draw and could only be ended by the deployment of the military.");
        }

        Console.Write("\n");

        if (turn>1)
        {
            Console.Write($"\n(Ended after {turn} moves)\n");
        }
        else
        {
            Console.Write($"\n(Ended after a single move)\n");
        }
        Console.ReadKey(true);
    }

    private static bool hasOversteppedMaximalTurns(int turn)
    {
        return (turn > maxTurn);

    }

    private static EType ChooseFighterType(string numeration)
    {
        int fighterIndex;
        bool isCorrectInput = false;
        bool wasIncorrect = false;

        Console.Clear();
        Console.Write($"Choose the {numeration} Group: \n");
        Console.Write("[1]-");
        ColoredWrite("COP ", copColor);
        Console.Write("[2]-");
        ColoredWrite("ANTIFA ", antifaColor);
        Console.Write("[3]-");
        ColoredWrite("HOOLIGAN ", hooliganColor);
        Console.Write("\n");

        do
        {
            if (wasIncorrect)
            {
                OccuringError("ERROR! Input was not accepted, try something else.");
                wasIncorrect = false;
            }

            isCorrectInput = int.TryParse(Console.ReadLine(), out fighterIndex);

            wasIncorrect = true;
        }
        while (!isCorrectInput || fighterIndex > 3 || fighterIndex <= 0);

        return (EType)fighterIndex;
    }

    private static Fighter RegistrateFighter(EType fighterType)
    {
        ConsoleColor fighterColor = AssignColor((int)fighterType);

        Console.Write("You have chosen the ");
        ColoredWrite($"{fighterType}", fighterColor);
        Console.Write(".\n\n");

        float abilityPoints = 10;

        bool hasPassedCustomization = false;

        do
        {
            abilityPoints = 10;
            ColoredWrite($"You have {abilityPoints} Abilitypoints to customize the {fighterType}\n" +
            $" <HEALTH> <ATTACK> <DEFENSE> <SPEED>\n" +
            $"(Every must contain at least a value of 1)\n\n", ConsoleColor.Yellow);

            Console.Write("Choose HEALTH:");
            newHLT = RegistrateCustomStat(10);
            abilityPoints -= newHLT;
            ColoredWrite($"you have {abilityPoints} AP left.\n\n", ConsoleColor.Yellow);

            if (abilityPoints > 0)
            {
                Console.Write("Choose ATTACK:");
                newATK = RegistrateCustomStat(5);
                abilityPoints -= newATK;
                ColoredWrite($"you have {abilityPoints} AP left.\n\n", ConsoleColor.Yellow);
            }

            if (abilityPoints > 0)
            {
                Console.Write("Choose DEFENSE:");
                newDEF = RegistrateCustomStat(5);
                abilityPoints -= newDEF;
                ColoredWrite($"you have {abilityPoints} AP left.\n\n", ConsoleColor.Yellow);
            }

            if (abilityPoints > 0)
            {
                Console.Write("Choose SPEED:");
                newSPD = RegistrateCustomStat(5);
                abilityPoints -= newSPD;
                ColoredWrite($"you have {abilityPoints} AP left.\n\n", ConsoleColor.Yellow);

                if (abilityPoints >= 0)
                {
                    hasPassedCustomization = true;
                }
            }

            if (!hasPassedCustomization)
            {
                Console.Clear();
                Console.Write("\n");
                OccuringError("ERROR: Outside of Ability Points Maximum!\n\n");
            }

        } while (!hasPassedCustomization);

        Console.Write("\nTYPE:");
        ColoredWrite($"{fighterType}", fighterColor);
        Console.Write("\nHLT:<");
        ColoredWrite($"{newHLT}", fighterColor);
        Console.Write("> ATK:<");
        ColoredWrite($"{newATK}", fighterColor);
        Console.Write("> DEF:<");
        ColoredWrite($"{newDEF}", fighterColor);
        Console.Write("> SPD:<");
        ColoredWrite($"{newSPD}", fighterColor);
        Console.Write(">\n\n");

        return CreateFighter((int)fighterType, fighterColor, newHLT, newATK, newDEF, newSPD);
    }

    private static float RegistrateCustomStat(float maximum)
    {
        Console.Write($"\n(the stat must be a number between 1 - {maximum})\n");

        float newStat = 0;//default
        bool isCorrectNewState = false;
        bool isWrongValue = false;

        do
        {
            if (isWrongValue)
            {
                OccuringError("ERROR: type in a number inside the given values!");
                isWrongValue = false;
            }

            isCorrectNewState = float.TryParse(Console.ReadLine(), out newStat);
            isWrongValue = true;

        } while (!isCorrectNewState || newStat < 1 || newStat > maximum);

        return newStat;
    }

    private static void DeleteCurrentLine(int line)
    {
        int bufferWidth = Console.BufferWidth;

        Console.SetCursorPosition(0, line);
        for (int i = 0; i < bufferWidth; i++)
        {
            Console.Write(" ");
        }
        Console.SetCursorPosition(0, line);
    }

    private static void OccuringError(string errorMessage = "")
    {
        int startLine = Console.GetCursorPosition().Top;
        DeleteCurrentLine(startLine);

        Console.SetCursorPosition(Console.GetCursorPosition().Left, startLine - 1);
        DeleteCurrentLine(startLine-1);

        ColoredWrite(errorMessage, errorColor);

        Console.ReadKey();
        DeleteCurrentLine(startLine-1);
    }


    private static Fighter CreateFighter(int newFighterIndex, ConsoleColor newColor, float newHLT, float newATK, float newDEF, float newSPD)
    {
        switch(newFighterIndex)
        {
            case (int)EType.COP:
                return new Cop(newHLT, newATK, newDEF, newSPD, newColor);
            case (int)EType.ANTIFA:
                return new Antifa(newHLT, newATK, newDEF, newSPD, newColor);
            case (int)EType.HOOLIGAN:
                return new Hooligan(newHLT, newATK, newDEF, newSPD, newColor);
            default:
                return new Cop(newHLT, newATK, newDEF, newSPD, ConsoleColor.Magenta);//ERROR
        }
    }

    private static ConsoleColor AssignColor(int newFighterIndex)
    {
        switch (newFighterIndex)
        {
            case (int)EType.COP:
                return copColor;
            case (int)EType.ANTIFA:
                return antifaColor;
            case (int)EType.HOOLIGAN:
                return hooliganColor;
            default:
                return ConsoleColor.Magenta;//ERROR
        }
    }

    private static void ColoredWrite(string content, ConsoleColor color)
    {
        ConsoleColor currentForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(content);
        Console.ForegroundColor = currentForegroundColor;
    }
}

