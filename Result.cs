using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1stProject
{
    class Result
    {
        //Result Categories
        public int fiveAndOneSuccess;
        public int fiveSuccess;
        public int fourAndOneSuccess;
        public int fourSuccess;
        public int threeAndOneSuccess;
        public int threeSuccess;
        public int twoAndOneSuccess;
        public int twoSuccess;
        public int oneAndOneSuccess;
        public int nothing;
        //Winnings for every result category (from game budget)
        public double fiveAndOneWinnings;
        public double fiveWinnings;
        public double fourAndOneWinnings;
        public double fourWinnings;
        public double threeAndOneWinnings;
        public double threeWinnings;
        public double twoAndOneWinnings;
        public double twoWinnings;
        public double oneAndOneWinnings;

        public bool foundJoker = false;

        public Result()
        {
            fiveAndOneSuccess = 0;
            fiveSuccess = 0;
            fourAndOneSuccess = 0;
            fourSuccess = 0;
            threeAndOneSuccess = 0;
            threeSuccess = 0;
            twoAndOneSuccess = 0;
            twoSuccess = 0;
            oneAndOneSuccess = 0;
            nothing = 0;
            fiveAndOneWinnings = 0;
            fiveWinnings = 0;
            fourAndOneWinnings = 0;
            fourWinnings = 0;
            threeAndOneWinnings = 0;
            threeWinnings = 0;
            twoAndOneWinnings = 0;
            twoWinnings = 0;
            oneAndOneWinnings = 0;
        }


        public void CategoriesOfWinners(List<int> drawNumbers, int drawJoker, List<int> choises, int joker)
        {
            int success = 0;


            foreach (var choise in choises)
            {

                if (drawNumbers.Contains(choise))
                    success += 1;

            }
            if (drawJoker == joker)
                foundJoker = true;


            switch (success)
            {

                case 5:
                    if (foundJoker)
                        fiveAndOneSuccess += 1;
                    else
                        fiveSuccess += 1;
                    break;
                case 4:
                    if (foundJoker)
                        fourAndOneSuccess += 1;
                    else
                        fourSuccess += 1;
                    break;
                case 3:
                    if (foundJoker)
                        threeAndOneSuccess += 1;
                    else
                        threeSuccess += 1;
                    break;
                case 2:
                    if (foundJoker)
                        twoAndOneSuccess += 1;
                    else
                        twoSuccess += 1;
                    break;
                case 1:
                    if (foundJoker)
                        oneAndOneSuccess += 1;
                    else
                        nothing += 1;
                    break;
                case 0:
                    if (foundJoker)
                        nothing += 1;
                    else
                        nothing += 1;
                    break;
                default:
                    Console.WriteLine("Something get wrong!");
                    break;
            }


        }

        public void PrintCategoriesOfWinning()
        {
            Console.WriteLine($"{nothing}, Found nothing!");
            Console.WriteLine($"{oneAndOneSuccess}, Found one number and the Joker!Total Euros won: {oneAndOneWinnings:F2}");
            Console.WriteLine($"{twoSuccess}, Found two numbers!Total Euros won: {twoWinnings:F2}");
            Console.WriteLine($"{twoAndOneSuccess}, Found two numbers and the Joker!Total Euros won: {twoAndOneWinnings:F2}");
            Console.WriteLine($"{threeSuccess}, Found three numbers!Total Euros won: {threeWinnings:F2}");
            Console.WriteLine($"{threeAndOneSuccess}, Found three numbers and the Joker!Total Euros won: {threeAndOneWinnings:F2}");
            Console.WriteLine($"{fourSuccess}, Found four numbers!Total Euros won: {fourWinnings:F2}");
            Console.WriteLine($"{fourAndOneSuccess}, Found four numbers and the Joker!Total Euros won: {fourAndOneWinnings:F2}");
            Console.WriteLine($"{fiveSuccess}, Found five numbers!Total Euros won: {fiveWinnings:F2}");
            Console.WriteLine($"{fiveAndOneSuccess}, Found five numbers and the Joker!Total Euros won: {fiveAndOneWinnings:F2}");

        }

        public double CalculateRemainingBudget(double budget)
        {

            //Calculate each category's winnings for this draw
            //as well as the remaining budget that will be returned to the Game
            //to be used in the next Draw

            double remainingBudget = 0;

            if (fiveAndOneSuccess > 0)
            {
                fiveAndOneWinnings = (budget * 0.4);
                budget -= (budget * 0.4);
            }

            else
                remainingBudget += budget * 0.4;

            if (fiveSuccess > 0)
            {
                fiveWinnings = (budget * 0.25);
                budget -= (budget * 0.25);
            }

            else
                remainingBudget += budget * 0.25;

            if (fourAndOneSuccess > 0)
            {
                fourAndOneWinnings = (budget * 0.15);
                budget -= (budget * 0.15);
            }

            else
                remainingBudget += budget * 0.15;

            if (fourSuccess > 0)
            {
                fourWinnings = (budget * 0.05);
                budget -= (budget * 0.05);
            }

            else
                remainingBudget += budget * 0.05;

            if (threeAndOneSuccess > 0)
            {
                threeAndOneWinnings = (budget * 0.05);
                budget -= (budget * 0.05);
            }

            else
                remainingBudget += budget * 0.05;

            if (threeSuccess > 0)
            {
                threeWinnings = (budget * 0.04);
                budget -= (budget * 0.04);
            }

            else
                remainingBudget += budget * 0.04;

            if (twoAndOneSuccess > 0)
            {
                twoAndOneWinnings = (budget * 0.035);
                budget -= (budget * 0.035);
            }

            else
                remainingBudget += budget * 0.035;

            if (twoSuccess > 0)
            {
                twoWinnings = (budget * 0.015);
                budget -= (budget * 0.015);
            }

            else
                remainingBudget += budget * 0.015;

            if (oneAndOneSuccess > 0)
            {
                oneAndOneWinnings = (budget * 0.01);
                budget -= (budget * 0.01);
            }

            else
                remainingBudget += budget * 0.01;

            return remainingBudget;
        }
    }
}

