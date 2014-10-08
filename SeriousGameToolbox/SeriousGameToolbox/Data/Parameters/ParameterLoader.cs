using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SeriousGameToolbox.Data.Parameters
{
    public class ParameterLoader
    {
        public class InvalidParameterTypeException : Exception
        {
            public InvalidParameterTypeException(string message) : base(message) { }
        }

        private string filename;
        protected IFormatProvider formatProvider = CultureInfo.InvariantCulture;

        public ParameterLoader(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException("filename");
            }

            if (filename == string.Empty)
            {
                throw new ArgumentException("filename cannot be empty");
            }

            this.filename = filename;
        }

        #region SAVING

        public void Save(ParameterCollection parameters)
        {
            XDocument doc = new XDocument(
                new XElement("parameters", from p in parameters.Parameters select GetParameter(p))
                );

            doc.Save(filename);
        }

        private XElement GetParameter(Parameter parameter)
        {
            if (parameter is IntRangeParameter)
            {
                return GetIntRangeParameter(parameter as IntRangeParameter);
            }
            else if (parameter is IntegerParameter)
            {
                return GetIntegerParameter(parameter as IntegerParameter);
            }
            if (parameter is FloatRangeParameter)
            {
                return GetFloatRangeParameter(parameter as FloatRangeParameter);
            }
            else if (parameter is FloatParameter)
            {
                return GetFloatParameter(parameter as FloatParameter);
            }
            if (parameter is BooleanParameter)
            {
                return GetBooleanParameter(parameter as BooleanParameter);
            }
            if (parameter is StringParameter)
            {
                return GetStringParameter(parameter as StringParameter);
            }

            throw new InvalidParameterTypeException("Le type " + parameter.GetType() + " n'est pas pris en charge");
        }

        private XElement GetFloatParameter(FloatParameter parameter)
        {
            XElement result = new XElement("parameter",
                                    new XAttribute("id", parameter.Id),
                                    new XAttribute("caption", parameter.Caption),
                                    new XAttribute("type", "float"),
                            new XElement("values",
                                        new XElement("current", (float)parameter.GetValue())));

            return result;
        }

        private XElement GetStringParameter(StringParameter parameter)
        {
            XElement result = new XElement("parameter",
                        new XAttribute("id", parameter.Id),
                        new XAttribute("caption", parameter.Caption),
                        new XAttribute("type", "string"),
                new XElement("values",
                            new XElement("current", parameter.GetValue())));

            return result;
        }

        private XElement GetIntegerParameter(IntegerParameter parameter)
        {
            XElement result = new XElement("parameter",
                                    new XAttribute("id", parameter.Id),
                                    new XAttribute("caption", parameter.Caption),
                                    new XAttribute("type", "integer"),
                            new XElement("values",
                                        new XElement("current", (int)parameter.GetValue())));

            return result;
        }

        private XElement GetFloatRangeParameter(FloatRangeParameter parameter)
        {
            XElement result = new XElement("parameter",
                        new XAttribute("id", parameter.Id),
                        new XAttribute("caption", parameter.Caption),
                        new XAttribute("type", "range_float"),
                new XElement("values",
                            new XElement("current", (float)parameter.GetValue()),
                            new XElement("min", parameter.Minimum),
                            new XElement("max", parameter.Maximum)
                            ));

            return result;
        }

        private XElement GetIntRangeParameter(IntRangeParameter parameter)
        {
            XElement result = new XElement("parameter",
                        new XAttribute("id", parameter.Id),
                        new XAttribute("caption", parameter.Caption),
                        new XAttribute("type", "range_int"),
                new XElement("values",
                            new XElement("current", (int)parameter.GetValue()),
                            new XElement("min", parameter.Minimum),
                            new XElement("max", parameter.Maximum)
                            ));

            return result;
        }

        private XElement GetBooleanParameter(BooleanParameter parameter)
        {
            XElement result = new XElement("parameter",
                        new XAttribute("id", parameter.Id),
                        new XAttribute("caption", parameter.Caption),
                        new XAttribute("type", "boolean"),
                new XElement("values",
                            new XElement("current", (bool)parameter.GetValue())));

            return result;
        }

        #endregion

        #region LOADING

        public ParameterCollection Load()
        {
            XDocument doc = XDocument.Load(filename);

            if (doc.Root.HasElements)
            {
                var elements = doc.Root.Elements("parameter");
                var parameters = new List<Parameter>(elements.Count());

                foreach (var item in elements)
                {
                    Parameter p = LoadParameter(item);

                    if (p == null)
                    {
                        throw new NullReferenceException("Aucun paramètre n'a pu être extrait du noeud xml.");
                    }

                    if (string.IsNullOrEmpty(p.Id))
                    {
                        throw new NullReferenceException("Parameter Id");
                    }

                    parameters.Add(p);
                }

                return new ParameterCollection(parameters);
            }
            else
            {
                throw new System.Xml.XmlException("There is no root element");
            }
        }

        private Parameter LoadParameter(XElement item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            string id = item.Attribute("id").Value;
            string caption = item.Attribute("caption").Value;
            string type = item.Attribute("type").Value;

            switch (type)
            {
                case "boolean": return LoadBooleanParameter(id, caption, item);
                case "integer": return LoadIntegerParameter(id, caption, item);
                case "range_int": return LoadIntRangeParameter(id, caption, item);

                case "float": return LoadFloatParameter(id, caption, item);
                case "range_float": return LoadFloatRangeParameter(id, caption, item);

                case "string": return LoadStringParameter(id, caption, item);
            }

            throw new Exception("Aucun paramètre n'a pu être extrait du noeud xml pour le type " + type);
        }

        private string GetStringValue(XElement item, string name)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            return item.Element("values").Element(name).Value;
        }

        private string GetStringValue(XElement item)
        {
            return GetStringValue(item, "current");
        }

        private Parameter LoadStringParameter(string id, string caption, XElement item)
        {
            return new StringParameter(id, caption, GetStringValue(item));
        }

        private Parameter LoadFloatParameter(string id, string caption, XElement item)
        {
            string stringValue = GetStringValue(item);

            float value = float.Parse(stringValue, formatProvider);
            return new FloatParameter(id, caption, value);
        }

        private Parameter LoadIntegerParameter(string id, string caption, XElement item)
        {
            string stringValue = GetStringValue(item);

            int value = int.Parse(stringValue, formatProvider);
            return new IntegerParameter(id, caption, value);
        }

        private Parameter LoadIntRangeParameter(string id, string caption, XElement item)
        {
            string stringValue = GetStringValue(item);

            string stringMaxValue = GetStringValue(item, "max");
            string stringMinValue = GetStringValue(item, "min");

            int value = int.Parse(stringValue, formatProvider);
            int minValue = int.Parse(stringMinValue, formatProvider);
            int maxValue = int.Parse(stringMaxValue, formatProvider);

            return new IntRangeParameter(id, caption, minValue, maxValue, value);
        }

        private Parameter LoadFloatRangeParameter(string id, string caption, XElement item)
        {
            string stringValue = GetStringValue(item);

            string stringMaxValue = GetStringValue(item, "max");
            string stringMinValue = GetStringValue(item, "min");

            float value = float.Parse(stringValue, formatProvider);
            float minValue = float.Parse(stringMinValue, formatProvider);
            float maxValue = float.Parse(stringMaxValue, formatProvider);

            return new FloatRangeParameter(id, caption, minValue, maxValue, value);
        }

        private Parameter LoadBooleanParameter(string id, string caption, XElement item)
        {
            string stringValue = GetStringValue(item);

            bool value = bool.Parse(stringValue);
            return new BooleanParameter(id, caption, value);
        }

        #endregion
    }
}
