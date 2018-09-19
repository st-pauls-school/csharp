using System;

namespace ObjectLibrary
{
    public enum ChineseSign
    {
        Monkey, Rooster, Dog, Pig, Rat, Ox, Tiger, Rabbit, Dragon, Snake, Horse, Goat
    }

    public static class Utilities
    {
        public static ChineseSign ToChineseSign(this DateTime dob)
        {
            // todo: this still needs to consider the Chinese New Year isn't 1st January http://www.chinesenewyears.info/chinese-new-year-calendar.php  
            return (ChineseSign)(dob.Year%12);
        }
    }

}
