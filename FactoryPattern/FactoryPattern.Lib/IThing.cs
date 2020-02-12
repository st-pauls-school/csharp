using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Lib
{
    /// <summary>
    /// A public interface, this will be accessible from outside of the lib namespace. It will contain function 
    /// definitions for everything we're interested in. 
    /// The important thing is that while <see cref="Thing"/> implements the interface, it is not public so 
    /// while the <seealso cref="IThingFactory"/> can create it, nothing outside the lib can see it.  
    /// </summary>
    public interface IThing : IComparable<IThing>
    {
        int SomeIntegerFunction(int i);
        string SaySomething(string s);

    }

    public interface IThingFactory
    {
        IThing Create();
        IThingFactory AddString(string s);
        IThingFactory AddInteger(int i);
    }

}
