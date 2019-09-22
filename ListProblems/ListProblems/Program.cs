using System.Collections.Generic;

namespace ListProblems
{
    class Program
    {
        static void Main(string[] args)
        {
    

            var listA1 = new List<int>{1,2,4,6,5,3,7,8};
            var listA2 = new List<int>{1,2,4,6,5,3,7,8};
            var listA3 = new List<int> { 1, 2, 4, 6, 5, 3, 7, 8, 10 };

            Test("the lists are ordered the same", AreExactlyEqual(listA1, listA2));
            Test("the lists are not the same length", !AreExactlyEqual(listA1, listA2));

            var listB1 = new List<int> { 10, 9, 8, 7, 65, 4};
            var listB2 = new List<int> { 4, 7, 8, 65, 9, 10 };
            Test("the lists are ordered the same", ContainTheSameValues(listB1, listB2));

            var listC1 = new List<int> { 10, 9, 8, 7, 65, 4 };
            var item1 = 7;
            var item2 = 17;
            Test("the item is in the list", IsIn(item1, listC1));
            Test("the item is not in the list", !IsIn(item2, listC1));

            var listD1 = new List<int> { 10, 9, 8, 7, 65, 4 };
            var listD2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var listE1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var listE2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };


        }

        /// <summary>
        /// This function should take a boolean and output an appropiate message depending on the 
        /// value of the condition - success or failure 
        /// </summary>
        /// <param name="message">the description of the test</param>
        /// <param name="condition">the input condition</param>
        private static void Test(string message, bool condition)
        {
        }

        /// <summary>
        /// Tests where
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        private static bool AreExactlyEqual(List<int> list1, List<int> list2)
        {
            return false;
        }

        /// <summary>
        /// This function should return whether the two lists contain the same values, whether or not
        /// they are ordered the same
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        private static bool ContainTheSameValues(List<int> list1, List<int> list2)
        {
            return false;
        }

        /// <summary>
        /// Determines if the item is in the list. 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private static bool IsIn(int item, List<int> list)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string DoesSomething(int number)
        {
            return string.Empty;
        }
    }
}
