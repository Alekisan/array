/* 
 * Name: Alexander D. Martinez
 * Date: 09/29/09
 * Purpose: allows user to roll two dice and get the stats on what results appear more frequently
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace RollTheDice
{
    class RollEm
    {
        static void Main(string[] args)
        {
            //init variables
            int numberOfRolls;
            int die1 = 0;
            int die2 = 0;
            int rollSum;
            int faceCounter = 2;
            int myCounter = 0;
            int mostRolls;
            int[] rollResults = new int[11];
            double[] expectedRolls = {2.78, 5.56, 8.33, 11.11, 13.89, 16.67, 13.89, 11.11, 8.37, 5.56, 2.78};
            double[] resultPercent = new double[11];
            double[] resultVariance = new double[11];
            Random randomNumber = new Random();

            
            //request user input
            Console.Write("Enter the number of times to roll the two dice: ");
            numberOfRolls = Convert.ToInt32(Console.ReadLine());

            
            //roll the dice and fill array with the result counts
            for (int i = 0; i < numberOfRolls; i++)
            {
                die1 = randomNumber.Next(1, 7);
                die2 = randomNumber.Next(1, 7);

                rollSum = die1 + die2;

                switch (rollSum)
                {
                    case 2:
                        ++rollResults[0];
                        break;
                    case 3:
                        ++rollResults[1];
                        break;
                    case 4:
                        ++rollResults[2];
                        break;
                    case 5:
                        ++rollResults[3];
                        break;
                    case 6:
                        ++rollResults[4];
                        break;
                    case 7:
                        ++rollResults[5];
                        break;
                    case 8:
                        ++rollResults[6];
                        break;
                    case 9:
                        ++rollResults[7];
                        break;
                    case 10:
                        ++rollResults[8];
                        break;
                    case 11:
                        ++rollResults[9];
                        break;
                    case 12:
                        ++rollResults[10];
                        break;
                    default:
                        break;
                }              
               
                
            }//end for loop which counts itterations of results
            

            //do maths and populate supporting arrays
            foreach (int i in rollResults)
            {
                double rR;
                
                rR = rollResults[myCounter];               
                
                if (rollResults[myCounter] > 0)
                {
                    resultPercent[myCounter] = (rR / numberOfRolls) * 100;
                }
                

                resultVariance[myCounter] = expectedRolls[myCounter] - resultPercent[myCounter];                
                
                ++faceCounter;
                ++myCounter;
            } // end loop to fill remaining arrays

            //reset counters
            faceCounter = 2;
            myCounter = 0;


            //begin output
            Console.WriteLine("\n\nSum\tCount\tPct\tExpected\tVariance");

            //generate chart of results
            foreach (int i in rollResults)
            {
                Console.WriteLine("{0,3}\t{1,5}\t{2:0.0,3}\t{3,8}\t{4:0.0,8}", faceCounter, rollResults[myCounter], resultPercent[myCounter], expectedRolls[myCounter], resultVariance[myCounter]);
                ++faceCounter;
                ++myCounter;
            }

            //reset counters
            faceCounter = 2;
            myCounter = 0;

            //figure out the highest ammout of results
            mostRolls = rollResults[0];

            foreach (int i in rollResults)
            {
                if (i >= mostRolls)
                {
                    mostRolls = i;                    
                }
                
            }

            //figure out which number it was that had highest ammount of hits
            while (rollResults[myCounter] != mostRolls)
            {
                ++myCounter;
                ++faceCounter;
            }




            Console.WriteLine("\nThe number with the highest occurences was {0} with {1}", faceCounter, mostRolls);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

    }
}
