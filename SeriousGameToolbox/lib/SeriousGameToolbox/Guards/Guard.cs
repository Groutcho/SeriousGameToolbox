using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Guards
{
    public static class Guard
    {
        public static void AgainstNullArgument(string name, object arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void AgainstNullOrEmptyString(string name, string objectToTest)
        {
            if (string.IsNullOrEmpty(objectToTest))
            {
                throw new ArgumentException("The string " + name + " cannot be " + objectToTest == null ? "null" : "empty");
            }
        }

        internal static void AgainstEmptyCollection(string name, IEnumerable collection)
        {
            Guard.AgainstNullArgument("collection", collection);

           if (!collection.GetEnumerator().MoveNext())
           {
               throw new ArgumentException("Collection cannot be empty : " + name);
           }
        }
    }
}
