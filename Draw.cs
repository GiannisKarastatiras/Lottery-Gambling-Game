using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Final1stProject
{
    class Draw : RandomNumber
    {
        public const int MinDrawNumber = 1;
        public const int MaxDrawNumber = 46;
        public const int MaxDrawNumberJoker = 21;


        public List<int> drawNumbers;



        public int drawJoker;

        public Draw()
        {
            drawNumbers = new List<int>();
            drawJoker = 0;
        }

        public List<int> GenerateRandomNumbers()
        {
            Thread.Sleep(500);

            Random r = new Random();


            for (int i = 0; i < 5; i++)
            {
                drawNumbers.Add(r.Next(MinDrawNumber, MaxDrawNumber));
            }



            foreach (var drawnumber in drawNumbers)
            {
                Console.WriteLine($"draw:{drawnumber}");
            }

            //Thread.Sleep(500);
            drawJoker = r.Next(MinDrawNumber, MaxDrawNumberJoker);
            Console.WriteLine($"DrawJoker:{drawJoker}");

            return drawNumbers;
        }
    }
}

