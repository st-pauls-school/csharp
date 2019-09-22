using System;

namespace StaffAllocation.Lib
{
    public class TeachingSet
    {
        string _name;
        Teacher _teacher;

        public TeachingSet(string name)
        {
            _name = name;
        }

        public Teacher Teacher => _teacher;

        public string Name => _name;
    }

    public class Period : IEquatable<Period>
    {
        string _description;
        int _size;

        public Period(string description)
        {
            _size = 1;
            _description = description;
        }

        public int Size => _size;
        public string Description => _description;

        public bool Equals(Period other)
        {
            return _description == other.Description;
        }
    }

    public class Teacher
    {
        string _name;

        public Teacher(string name)
        {
            _name = name;
        }

        public string Name => _name;
    }
}
