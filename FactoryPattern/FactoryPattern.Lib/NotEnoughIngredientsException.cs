using System;
using System.Runtime.Serialization;

namespace FactoryPattern.Lib
{
    [Serializable]
    internal class NotEnoughIngredientsException : Exception
    {
        public NotEnoughIngredientsException()
        {
        }

        public NotEnoughIngredientsException(string message) : base(message)
        {
        }

        public NotEnoughIngredientsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotEnoughIngredientsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}