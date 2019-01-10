using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final1stProject
{
    class Statistic
    {
        private List<int> allDrawNumbers;
        private List<int> allJokerNumbers;
        //private List<int> hotDrawNumbers;
        //private List<int> coldDrawNumbers;
        //private List<int> hotJokerNumbers;
        //private List<int> coldJokerNumbers;
        private int firstMostCommonDrawNumber;
        private int secondMostCommonDrawNumber;
        private int thirdMostCommonDrawNumber;
        private int firstLessCommonDrawNumber;
        private int secondLessCommonDrawNumber;
        private int thirdLessCommonDrawNumber;
        private int firstMostCommonJokerNumber;
        private int secondMostCommonJokerNumber;
        private int thirdMostCommonJokerNumber;
        private int firstLessCommonJokerNumber;
        private int secondLessCommonJokerNumber;
        private int thirdLessCommonJokerNumber;
        private int count;


        public Statistic()
        {
            allDrawNumbers = new List<int>();
            allJokerNumbers = new List<int>();
            //hotDrawNumbers = new List<int>();
            //coldDrawNumbers = new List<int>();
            //hotJokerNumbers = new List<int>();
            //coldJokerNumbers = new List<int>();
            firstMostCommonDrawNumber = 0;
            secondMostCommonDrawNumber = 0;
            thirdMostCommonDrawNumber = 0;
            firstLessCommonDrawNumber = 0;
            secondLessCommonDrawNumber = 0;
            thirdLessCommonDrawNumber = 0;
            firstMostCommonJokerNumber = 0;
            secondMostCommonJokerNumber = 0;
            thirdMostCommonJokerNumber = 0;
            firstLessCommonJokerNumber = 0;
            secondLessCommonJokerNumber = 0;
            thirdLessCommonJokerNumber = 0;
            count = 0;
        }


        public void ExecuteStatistics(List<Draw> listDraw)
        {
            foreach (var draw in listDraw)
            {
                foreach (var numbers in draw.drawNumbers)
                {
                    allDrawNumbers.Add(numbers);
                }
                allJokerNumbers.Add(draw.drawJoker);
            }
            //choise 1--mostDraw,2--less draw,3--most joker,4--less joker


            EditStatistics(firstMostCommonDrawNumber, 1, 1);


            EditStatistics(secondMostCommonDrawNumber, 1, 1);



            EditStatistics(thirdMostCommonDrawNumber, 1, 1);

            EditStatistics(firstLessCommonDrawNumber, 2, 2);

            EditStatistics(secondLessCommonDrawNumber, 2, 2);

            EditStatistics(thirdLessCommonDrawNumber, 2, 2);

            EditStatistics(firstMostCommonJokerNumber, 3, 1);

            EditStatistics(secondMostCommonJokerNumber, 3, 1);

            EditStatistics(thirdMostCommonJokerNumber, 3, 1);

            EditStatistics(firstLessCommonJokerNumber, 4, 2);

            EditStatistics(secondLessCommonJokerNumber, 4, 2);

            EditStatistics(thirdLessCommonJokerNumber, 4, 2);

        }



        public int FindHotOrColdNumbers(List<int> draws, int choise)
        {
            var mode = 0;


            Dictionary<int, int> numbers = new Dictionary<int, int>();

            switch (choise)
            {
                case 1:
                    foreach (var drawNumber in draws)
                    {
                        if (numbers.ContainsKey(drawNumber))
                            numbers[drawNumber]++;
                        else
                            numbers.Add(drawNumber, 1);
                    }

                    int max = 0;

                    foreach (KeyValuePair<int, int> num in numbers)
                    {
                        if (num.Value > max)
                        {
                            mode = num.Key;
                            max = num.Value;
                            count = max;



                        }

                    }
                    break;
                case 2:
                    foreach (var drawNumber in draws)
                    {
                        if (numbers.ContainsKey(drawNumber))
                            numbers[drawNumber]++;
                        else
                            numbers.Add(drawNumber, 1);
                    }


                    int min = numbers.Count;

                    foreach (KeyValuePair<int, int> num in numbers)
                    {
                        if (num.Value < min)
                        {
                            mode = num.Key;
                            min = num.Value;
                            count = min;

                        }
                    }
                    break;
                default:
                    Console.WriteLine("Something Got Wrong With the Statistics!");
                    break;
            }
            return mode;
        }



        public void EditStatistics(int commonNumber, int choise, int hotOrCold)    //choise 1--mostDraw,2--less draw,3--most joker,4--less joker
        {                                                                          //hotorcold=1---hotnumber,hotorcold=2--coldnumber
            switch (choise)
            {
                case 1:
                    Console.WriteLine("-----Most Common Draw Numbers-----");
                    commonNumber = FindHotOrColdNumbers(allDrawNumbers, hotOrCold);
                    Console.WriteLine($"The number {commonNumber} displayed {count} times in draws!");

                    foreach (var num in allDrawNumbers.ToList())
                    {
                        allDrawNumbers.Remove(commonNumber);
                    }
                    count = 0;
                    Console.WriteLine("\n");
                    break;
                case 2:
                    Console.WriteLine("-----Less Common Draw Numbers-----");
                    commonNumber = FindHotOrColdNumbers(allDrawNumbers, hotOrCold);
                    Console.WriteLine($"The number {commonNumber} displayed {count} times in draws!");

                    foreach (var num in allDrawNumbers.ToList())
                    {
                        allDrawNumbers.Remove(commonNumber);
                    }

                    count = 0;
                    Console.WriteLine("\n");
                    break;
                case 3:
                    Console.WriteLine("-----Most Common Joker Numbers-----");
                    commonNumber = FindHotOrColdNumbers(allJokerNumbers, hotOrCold);
                    Console.WriteLine($"The number {commonNumber} displayed {count} times in draws!");

                    foreach (var num in allJokerNumbers.ToList())
                    {
                        allJokerNumbers.Remove(commonNumber);
                    }

                    count = 0;
                    Console.WriteLine("\n");
                    break;
                case 4:
                    Console.WriteLine("-----Less Common Joker Numbers-----");
                    commonNumber = FindHotOrColdNumbers(allJokerNumbers, hotOrCold);
                    Console.WriteLine($"The number {commonNumber} displayed {count} times in draws!");

                    foreach (var num in allJokerNumbers.ToList())
                    {
                        allJokerNumbers.Remove(commonNumber);
                    }

                    count = 0;
                    Console.WriteLine("\n");
                    break;
                default:
                    Console.WriteLine("Something Got Wrong with the Edit of the statistics!!!");
                    break;
            }
        }
    }
}
