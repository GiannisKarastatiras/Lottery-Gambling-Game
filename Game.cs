using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1stProject
{
    class Game
    {
        private const double defaultBudget = 1000; //default budget of every Draw

        private double remainingBudget = 0; //remaining budget from previous Draw
        private double budget; //current budget that will be given to the next Draw
        private List<Player> players;
        private List<Draw> draws;
        private List<Result> results;
        private Statistic stats;



        //At every Draw the budget will be calculated: budget = defaultBudget + remainingBugdet


        public Game()
        {

            players = new List<Player>();
            draws = new List<Draw>();
            results = new List<Result>();
            budget = defaultBudget;
            stats = new Statistic();
        }


        public void ExecuteGame()
        {
            Console.WriteLine("How many players will play in this game");
            int numberOfPlayers = int.Parse(Console.ReadLine());

            Console.WriteLine("How many draws do you want?");
            int numberOfDraws = int.Parse(Console.ReadLine());



            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = new Player();
                players.Add(player);
                player.ManuallyOrRandomly();
            }
            Console.WriteLine("\n");
            for (int i = 0; i < numberOfDraws; i++)
            {
                Draw draw = new Draw();

                draw.GenerateRandomNumbers();
                Console.WriteLine("\n");
                draws.Add(draw);

                Result result = new Result();
                results.Add(result);



                //For every Player check the results of this Draw
                foreach (var player in players)
                {
                    result.CategoriesOfWinners(draw.drawNumbers, draw.drawJoker, player.choises, player.Joker);

                }
                budget = 0;
                budget = defaultBudget + remainingBudget;
                remainingBudget = result.CalculateRemainingBudget(budget);


                result.PrintCategoriesOfWinning();
                Console.WriteLine("\n");

            }
            stats.ExecuteStatistics(draws);
        }
    }
}

