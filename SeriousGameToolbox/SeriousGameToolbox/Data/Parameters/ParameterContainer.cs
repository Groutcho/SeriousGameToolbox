using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class ParameterContainer : IEquatable<ParameterContainer>
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

        public ParameterContainer(ParameterContainer original)
        {
            if (original == null)
            {
                throw new ArgumentNullException("original");
            }

            dict = new Dictionary<string, Parameter>(original.dict);

            parameters = new List<Parameter>(original.parameters);
        }

        public ParameterContainer(IEnumerable<Parameter> original)
        {
            if (original == null)
            {
                throw new ArgumentNullException("original");
            }

            if (DoesListContainsDuplicateValues(original))
            {
                throw new ArgumentException("Several parameters in the list have the same id. This is not permitted.");
            }

            parameters = new List<Parameter>(original);
            dict = new Dictionary<string, Parameter>(parameters.Count);

            foreach (var item in parameters)
            {
                dict[item.Id] = item;
            }
        }

        private bool DoesListContainsDuplicateValues(IEnumerable<Parameter> original)
        {
            List<string> ids = new List<string>(original.Count());

            foreach (var item in original)
            {
                if (ids.Contains(item.Id))
                {
                    return true;
                }
                else
                {
                    ids.Add(item.Id);
                }
            }

            return false;
        }

        public bool Equals(ParameterContainer other)
        {
            if (other == this)
            {
                return true;
            }

            if (other.Parameters.Count != parameters.Count)
            {
                return false;
            }

            for (int i = 0; i < parameters.Count; i++)
            {
                if (!other.parameters[i].Equals(parameters[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
