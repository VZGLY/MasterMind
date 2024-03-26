const int nbrEssais = 12;

bool isWin = false;

ConsoleColor[] colors = new ConsoleColor[6] 
{
    ConsoleColor.Red,
    ConsoleColor.Green,
    ConsoleColor.Blue,
    ConsoleColor.Yellow,
    ConsoleColor.Magenta,
    ConsoleColor.Cyan,
};

ConsoleColor[] secret = new ConsoleColor[4];

ConsoleColor[,] table = new ConsoleColor[nbrEssais,secret.Length];

initialize();
display();
run();

void initialize()
{
    Random rnd = new Random();
    for (int i = 0; i < secret.Length; i++)
    {
        secret[i] = colors[rnd.Next(colors.Length)];
    }

    for (int i = 0; i < table.GetLength(0); i++)
    {
        for (int j = 0; j < table.GetLength(1); j++)
        {
            table[i,j] = ConsoleColor.White;
        }
    }
}


void display()
{

    Console.Clear();

    

    Console.WriteLine("SUPER MEGA SUPRA MASTERMIIIIND");

    

    for (int i = 0; i < table.GetLength(0); i++)
    {
        int colorPlace = 0;

        int color = 0;

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("|");

        ConsoleColor[] tempRow = new ConsoleColor[4];

        for (int j = 0; j < table.GetLength(1); j++)
        {
            Console.ForegroundColor = table[i,j];

            tempRow[j] = table[i,j];

            Console.Write("o");
        }

        int[] resultLine = handleLine(secret, tempRow);

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("|");

        for (int j = 0; j < resultLine[0]; j++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("o");
        }

        for (int j = 0; j < resultLine[1]; j++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("o");
        }

        if (resultLine[0] == 4)
        {
            isWin = true;
        }

        Console.WriteLine();

    }

    for (int i = 0; i < colors.Length; i++)
    {
        Console.WriteLine($"{i + 1}: {colors[i]}");
    }

}

int[] handleLine(ConsoleColor[] secret, ConsoleColor[] line)
{
    int[] result = new int[2];

    for (int i = 0; i < secret.Length; i++)
    {
        bool isWhite = false;
        bool isOrange = false;

        for (int j = 0; j < line.Length; j++)
        {
            if (secret[i] == line[j] && i == j)
            {
                isWhite = false;
                isOrange = true;
                j = line.Length;
            }
            else if(secret[i] == line[j])
            {
                isWhite = true;
            }
        }

        if (isWhite)
        {
            result[1] += 1;
        }
        else if(isOrange)
        {
            result[0] += 1;
        }
    }

    return result;
}

void run()
{
    for (int i = 0; i < nbrEssais; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            Console.WriteLine($"Choisissez une couleur {j+1} :");
            int result = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Couleur {colors[result -1]} Choisie.");
            table[i, j] = colors[result- 1];
        }

        display();

        if (isWin)
        {
            i = nbrEssais;
        }
    }
    
    if (!isWin)
    {
        loose();
    }
    else
    {
        win();
    }
    


}

void win()
{
    Console.WriteLine("YOU WINNNN !!!!");
}

void loose()
{
    Console.WriteLine("BOOOOUH JOHNNY LA LOOSE !");
}


