using System;

namespace FactoryPattern.Lib
{
    /// <summary>
    /// This <see cref="Thing"/> 
    /// </summary>
    internal class Thing : IThing
    {
        public Thing(string s, int i)
        {

        }

        public Thing(string s) : this(s, 0)
        {

        }

        public Thing(int i) : this(string.Empty, i)
        {

        }

        public int CompareTo(IThing other)
        {
            throw new NotImplementedException();
        }

        public string SaySomething(string s)
        {
            throw new NotImplementedException();
        }

        public int SomeIntegerFunction(int i)
        {
            throw new NotImplementedException();
        }
    }

    public class ThingFactory : IThingFactory
    {
        int? _i = null;
        string _s = null;

        public static IThingFactory GiveMeAFactory()
        {
            return new ThingFactory();
        }



        public IThingFactory AddInteger(int i)
        {
            _i = i;
            return this;
        }

        public IThingFactory AddString(string s)
        {
            _s = s;
            return this;
        }

        public IThing Create()
        {
            if (!string.IsNullOrEmpty(_s) && _i.HasValue)
                return new Thing(_s, _i.Value);
            if (string.IsNullOrEmpty(_s) && _i.HasValue)
                return new Thing(_i.Value);
            if (!string.IsNullOrEmpty(_s))
                return new Thing(_s);
            throw new NotEnoughIngredientsException();
        }
    }
}
