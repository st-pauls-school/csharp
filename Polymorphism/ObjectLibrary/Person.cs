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

    /// <summary>
    /// The base person class 
    /// </summary>
    public class Person
    {
        readonly protected string _first;
        readonly protected string _last;
        readonly protected string _email;
        readonly protected DateTime _dob;

        public Person(string f, string l, string e, DateTime dt)
        {
            _first = f;
            _last = l;
            _email = e;
            _dob = dt;
        }

        public Person(string f, string l, DateTime dt) : this(f, l, string.Empty, dt)
        {

        }

        public bool IsValidAge
        {
            get
            {
                if (_dob > DateTime.Today)
                    return false;     
                return true;
            }
        }

        public bool IsAdult
        {
            get
            {
                return (DateTime.Today.Year - _dob.Year) >= 18;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _dob.Month == DateTime.Today.Month && _dob.Date == DateTime.Today.Date;
            }
        }

        public ChineseSign ToChineseSign => _dob.ToChineseSign();

        public virtual string ScreenName
        {
            get
            {
                return string.Format("{0}{1}{2}{3}", _first.Replace(" ", string.Empty), _last.Replace(" ", string.Empty), _dob.Month, _dob.Day);
            }
        }
    }
    public class Student : Person
    {
        readonly string _yearGroup;

        public Student(string f, string l, string e, DateTime dt, string yg) : base(f, l, e, dt)
        {
            _yearGroup = yg;
        }

        public Student(string f, string l, string e, DateTime dt) : base(f, l, e, dt)
        {
            // todo: define the year group calculation 
            _yearGroup = "??";
        }

        public string YearGroup => _yearGroup;

        public override string ScreenName
        {
            get
            {
                return string.Format("{0}{1}{2}", _first.Replace(" ", string.Empty), _last.Replace(" ", string.Empty), _yearGroup);
            }
        }
    }

    public class Teacher : Person
    {
        public Teacher(string f, string l, string e, DateTime dt) : base(f, l, e, dt)
        {
            // todo: teacher needs a subject 
        }

        public override string ScreenName
        {
            get
            {
                return string.Format("{0}{1}Staff", _first.Replace(" ", string.Empty), _last.Replace(" ", string.Empty));
            }
        }
    }

}
