using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Final1stProject
{
    class Player : RandomNumber
    {
        public const int MinNumberChoise = 1;
        public const int MaxNumberChoise = 46;
        public const int MaxJokerChoise = 21;
        public const int MaxChoise = 5;


        public List<int> choises;



        private int joker;
        public int Joker
        {
            get
            {
                return joker;
            }
            set
            {
                if (value < 1 || value > 20)
                    throw new ArgumentException("You have to be in range 1...20");
                if (value.Equals(null))
                    throw new ArgumentNullException("Joker can not be unassigned");

                joker = value;
            }
        }


        public Player()
        {
            choises = new List<int>();


        }


        public List<int> GenerateRandomNumbers()
        {
            Random r = new Random();
            for (int i = 0; i < MaxChoise; i++)
            {
                choises.Add(r.Next(MinNumberChoise, MaxNumberChoise));

            }

            foreach (int choise in choises)
            {

                Console.WriteLine($"Player:{choise}");
            }

            joker = r.Next(MinNumberChoise, MaxJokerChoise);

            Console.WriteLine($"PlayerJoker:{joker}");

            return choises;
        }

        //The player can choose between manual or random play

        public List<int> ManuallyOrRandomly()
        {
            Console.WriteLine("\n");
            Console.WriteLine("For manual game press 1, else for random game press 2");
            int choise = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");

            switch (choise)
            {
                case 1: //Manual
                    for (int j = 0; j < MaxChoise; j++)
                    {
                        Console.WriteLine("Give me a number");
                        int number = int.Parse(Console.ReadLine());
                        if (!choises.Contains(number))
                            choises.Add(number);

                    }
                    foreach (var number in choises)
                    {
                        Console.WriteLine($"Player:{number}");

                    }
                    Console.WriteLine("Give me the Joker Number");
                    joker = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Joker:{joker}");
                    break;
                case 2: //Random
                    Thread.Sleep(500);
                    GenerateRandomNumbers();
                    break;
                default:
                    Console.WriteLine("You have to choose one of the two choises if you want to play");
                    break;
            }
            return choises;
        }
    }
}

