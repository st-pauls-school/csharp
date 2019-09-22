using System;

namespace LearningCSharp
{
    class Selection
    {
        public void IfThenElse(bool someCondition, int value)
        {
            // Use a double equals to compare values 
            if (someCondition == true)
            {
                Console.WriteLine("it was true perform this action");
            }
            else
            {
                Console.WriteLine("it was not true so perform this action");
            }

            if (someCondition)
            {
                // We don't need to explicitly compare the boolean to true 
            }

            if (!someCondition)
            {
                // The exclamation mark indicates not - so this will match with false 
            }

            if (value >= 0 && value < 100)
            {
                // the double ampersand is and 
                // note: that the expression is lazily evaluated, so if the first condition is false, the second condition will not be looked at 
            }

            if (someCondition || value > 0)
            {
                // the double pipe is or 
            }
        }

        public void SwitchStatement(int value)
        {
            switch(value)
            {
                case (0):
                    // if the value is 0 
                    break; // you must break each clause
                case (1):
                case (2):
                    // you can have multiple options for the same clause
                    break;
                default:
                    // an optional clause, effectively an else 
                    break;
            }
        }

        public void ConditionalOperator(bool someCondition)
        {
            // if you would write something like this 
            string value;
            if (someCondition)
            {
                value = "this";
            }
            else
            {
                value = "that";
            }
            // you could instead write 

            value = someCondition ? "this" : "that";
        }
    }
}
