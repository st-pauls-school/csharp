using System;
using System.Collections.Generic;
using UCO.GraphExercise.Lib.Interfaces;

namespace UCO.GraphExercise.Lib.Classes
{
    public static class ExtensionMethods 
    {
        public static int IndexOf<T>(this IList<IVertex<T>> vertices, T value) where T : IEquatable<T>
        {
            for (int i = 0; i < vertices.Count; ++i)
                if (vertices[i].Value.Equals(value))
                    return i;
            return -1;
        }
    }
}
