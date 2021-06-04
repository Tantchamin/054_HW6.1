using System;

namespace HW6
{
    class Program
    {
        enum Difficulty
        {
            Easy,
            Normal,
            Hard
        }
        struct Problem
        {
            public string Message;
            public int Answer;

            public Problem(string message, int answer)
            {
                Message = message;
                Answer = answer;
            }
        }
        static void Main(string[] args)
        {
            double score = 0;
            Problem[] randomProblems;
            Difficulty Level = Difficulty.Easy;
                Console.WriteLine("Score: {0}, Difficulty: {1}", score, Level);
                int command = int.Parse(Console.ReadLine()); 
            
            while (command != 2)
            {
                while (command < 0 || command > 2)
                {
                    Console.WriteLine("Please input 0 - 2.");
                    Console.WriteLine("Score: {0}, Difficulty: {1}", score, Level);
                    command = int.Parse(Console.ReadLine());
                }
                if (command == 0)
                {
                    double Qc = 0;
                    int Question = 0;
                    if (Level == Difficulty.Easy)
                    {
                        Question = 3;
                    }
                    else if (Level == Difficulty.Normal)
                    {
                        Question = 5;
                    }
                    else if (Level == Difficulty.Hard)
                    {
                        Question = 7;
                    }
                    long time1 = DateTimeOffset.Now.ToUnixTimeSeconds();
                    randomProblems = GenerateRandomProblems(Question);
                    for (int i = 0; i < Question; i++)
                    {
                        Console.WriteLine(randomProblems[i].Message);
                        double answer = int.Parse(Console.ReadLine());
                        if (answer == randomProblems[i].Answer)
                        {
                            Qc += 1;
                        }
                    }
                    long time2 = DateTimeOffset.Now.ToUnixTimeSeconds();

                    long time = time2 - time1;

                    // Check value
                    /*Console.WriteLine("Time: {0}", time);
                    Console.WriteLine("Qc: {0}", Qc);
                    Console.WriteLine("Question: {0}", Question);
                    Console.WriteLine("Level: {0}", (double)Level);
                    Console.WriteLine("Qc/Qa: {0}", Qc / Question);*/

                    score += (Qc / Question) * (((25 - Math.Pow((double)Level, 2))) / (Math.Max(time, 25 - Math.Pow((double)Level, 2))))
                                     * (Math.Pow(((2 * (double)Level) + 1), 2));

                }
                else if (command == 1)
                {
                    int setting = int.Parse(Console.ReadLine());
                    while (setting < 0 || setting > 2)
                    {
                        Console.WriteLine("Please input 0 - 2.");
                        setting = int.Parse(Console.ReadLine());
                    }
                    Level = (Difficulty)setting;
                }                

                Console.WriteLine("Score: {0}, Difficulty: {1}", score, Level);
                command = int.Parse(Console.ReadLine());

            }
            
        }
        static Problem[] GenerateRandomProblems(int numProblem)
        {
            Problem[] randomProblems = new Problem[numProblem];

            Random rnd = new Random();
            int x, y;

            for (int i = 0; i < numProblem; i++)
            {
                x = rnd.Next(50);
                y = rnd.Next(50);
                if (rnd.NextDouble() >= 0.5)
                    randomProblems[i] =
                    new Problem(String.Format("{0} + {1} = ?", x, y), x + y);
                else
                    randomProblems[i] =
                    new Problem(String.Format("{0} - {1} = ?", x, y), x - y);
            }

            return randomProblems;
        }

    }
}
