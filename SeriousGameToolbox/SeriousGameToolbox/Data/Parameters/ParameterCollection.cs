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

            Parameter p = dict[name];

            if (!(p.GetValue() is T))
            {
                Type expected = typeof(T);

                throw new InvalidCastException(string.Format("The parameter {0} has an invalid type. Expected {1}", name, expected));
            }

            return (T)p.GetValue();
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
