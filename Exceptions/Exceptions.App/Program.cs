using Exceptions.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Division(25, 5);
            Division(25, 0);

            SetExamScore(-2, 72);
            SetExamScore(5, 0);

            Console.ReadKey();
        }

        static void Division(int num1, int num2)
        {
            int result = 0;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }
        }

        static void SetExamScore(int score, int total)
        {
            try
            {
                Console.WriteLine("{0}/{1} = {2}%", new ExamScore(score, total).Percentage);
            }
            catch (ExamScoreException ese)
            {
                Console.WriteLine("Invalid score: {0}", ese.Message);
            }

        }
    }
}
