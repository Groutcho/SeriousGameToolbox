using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class ParameterCollection
    {
        private Dictionary<string, Parameter> dict;

        private List<Parameter> parameters;
        public ICollection<Parameter> Parameters { get { return parameters; } }

        public T Get<T>(string name)
        {
            if (!dict.ContainsKey(name))
            {
                throw new KeyNotFoundException("The key " + name + " cannot be found in the parameters.");
            }

            if (!(dict[name].Value is T))
            {
                throw new InvalidCastException("The parameter " + name + " has no value of type " + typeof(T).GetType());
            }

            return (T)dict[name].Value;
        }

        public ParameterCollection(ParameterCollection original)
        {
            if (original == null)
            {
                throw new ArgumentNullException("original");
            }

            dict = new Dictionary<string, Parameter>(original.dict);

            parameters = new List<Parameter>(original.parameters);
        }

        public ParameterCollection(IEnumerable<Parameter> original)
        {
            if (original == null)
            {
                throw new ArgumentNullException("original");
            }

            parameters = new List<Parameter>(original);
            dict = new Dictionary<string, Parameter>(parameters.Count);

            foreach (var item in parameters)
            {
                dict[item.Id] = item;
            }
        }
    }
}
