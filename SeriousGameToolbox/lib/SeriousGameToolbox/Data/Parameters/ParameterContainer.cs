using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Parameters
{
    public class ParameterContainer : IEquatable<ParameterContainer>
    {
        private Dictionary<string, Parameter> dict;

        static IParameterContainerParser currentParser = new XmlParameterContainerParser();
        public static IParameterContainerParser Parser { get; set; }

        public static ParameterContainer Load(string filename)
        {
            Guards.Guard.AgainstNullArgument("filename", filename);

            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("The text container file could not be found", filename);
            }

            string content = string.Empty;
            using (StreamReader r = new StreamReader(filename))
            {
                content = r.ReadToEnd();
            }

            currentParser = Parser ?? new XmlParameterContainerParser();

            return Parse(content);
        }

        public static ParameterContainer Parse(string content)
        {
            return currentParser.Parse(content);
        }

        public void Save(string filename)
        {
            currentParser = Parser ?? new XmlParameterContainerParser();
            currentParser.Save(this, filename);
        }

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

        public Parameter GetParameter(string name)
        {
            if (!dict.ContainsKey(name))
            {
                throw new KeyNotFoundException("the parameter " + name + " is not present in the parameter container.");
            }

            return dict[name];
        }

        public ParameterContainer(ParameterContainer original)
        {
            Guards.Guard.AgainstNullArgument("original", original);

            dict = new Dictionary<string, Parameter>(original.dict);

            parameters = new List<Parameter>(original.parameters);
        }

        public ParameterContainer(IEnumerable<Parameter> original)
        {
            Guards.Guard.AgainstNullArgument("original", original);

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
