using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SeriousGameToolbox.Data.Parameters
{
    public class ParameterLoader
    {
        private string filename;

        public ParameterLoader(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException("filename");
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
            if (parameter is IntegerParameter)
            {
                return GetIntegerParameter(parameter as IntegerParameter);
            }
            if (parameter is FloatRangeParameter)
            {
                return GetRangeParameter(parameter as FloatRangeParameter);
            }
            if (parameter is IntRangeParameter)
            {
                return GetRangeParameter(parameter as IntRangeParameter);
            }
            if (parameter is BooleanParameter)
            {
                return GetBooleanParameter(parameter as BooleanParameter);
            }

            throw new Exception("Le type " + parameter.GetType() + " n'est pas pris en charge");
        }

        private XElement GetIntegerParameter(IntegerParameter parameter)
        {
            XElement result = new XElement("parameter",
                                    new XAttribute("id", parameter.Id),
                                    new XAttribute("caption", parameter.Caption),
                                    new XAttribute("type", "integer"),
                            new XElement("values",
                                        new XElement("current", parameter.Value)));

            return result;
        }

        private XElement GetRangeParameter(FloatRangeParameter parameter)
        {
            XElement result = new XElement("parameter",
                        new XAttribute("id", parameter.Id),
                        new XAttribute("caption", parameter.Caption),
                        new XAttribute("type", "range_float"),
                new XElement("values",
                            new XElement("current", parameter.Value),
                            new XElement("min", parameter.Minimum),
                            new XElement("max", parameter.Maximum)
                            ));

            return result;
        }

        private XElement GetRangeParameter(IntRangeParameter parameter)
        {
            XElement result = new XElement("parameter",
                        new XAttribute("id", parameter.Id),
                        new XAttribute("caption", parameter.Caption),
                        new XAttribute("type", "range_int"),
                new XElement("values",
                            new XElement("current", parameter.Value),
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
                            new XElement("current", parameter.Value)));

            return result;
        }

        #endregion

        #region LOADING

        public ParameterCollection Load()
        {
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException("settingsPath");
            }

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
                case "range_float": return LoadFloatRangeParameter(id, caption, item);
                case "range_int": return LoadIntRangeParameter(id, caption, item);
                case "integer": return LoadIntegerParameter(id, caption, item);
            }

            throw new Exception("Aucun paramètre n'a pu être extrait du noeud xml pour le type " + type);
        }

        private Parameter LoadIntegerParameter(string id, string caption, XElement item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            string stringValue = item.Element("values").Element("current").Value;

            int value;

            if (!int.TryParse(stringValue, out value))
            {
                throw new System.Xml.XmlException("la valeur " + stringValue + " n'est pas un entier");
            }

            return new IntegerParameter(id, caption, value);
        }

        private Parameter LoadIntRangeParameter(string id, string caption, XElement item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            string stringValue = item.Element("values").Element("current").Value;
            string stringMaxValue = item.Element("values").Element("max").Value;
            string stringMinValue = item.Element("values").Element("min").Value;

            int value, minValue, maxValue;

            if (!int.TryParse(stringValue, out value))
            {
                throw new System.Xml.XmlException("la valeur " + stringValue + " n'est pas un entier");
            }
            if (!int.TryParse(stringMaxValue, out maxValue))
            {
                throw new System.Xml.XmlException("la valeur " + stringMaxValue + " n'est pas un entier");
            }
            if (!int.TryParse(stringMinValue, out minValue))
            {
                throw new System.Xml.XmlException("la valeur " + stringMinValue + " n'est pas un entier");
            }

            return new IntRangeParameter(id, caption, minValue, maxValue, value);
        }

        private Parameter LoadFloatRangeParameter(string id, string caption, XElement item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            string stringValue = item.Element("values").Element("current").Value;
            string stringMaxValue = item.Element("values").Element("max").Value;
            string stringMinValue = item.Element("values").Element("min").Value;

            float value, minValue, maxValue;

            if (!float.TryParse(stringValue, out value))
            {
                throw new System.Xml.XmlException("la valeur " + stringValue + " n'est pas un float");
            }
            if (!float.TryParse(stringMaxValue, out maxValue))
            {
                throw new System.Xml.XmlException("la valeur " + stringMaxValue + " n'est pas un float");
            }
            if (!float.TryParse(stringMinValue, out minValue))
            {
                throw new System.Xml.XmlException("la valeur " + stringMinValue + " n'est pas un float");
            }

            return new FloatRangeParameter(id, caption, minValue, maxValue, value);
        }

        private Parameter LoadBooleanParameter(string id, string caption, XElement item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            string stringValue = item.Element("values").Element("current").Value;

            bool value;

            if (!bool.TryParse(stringValue, out value))
            {
                throw new System.Xml.XmlException("la valeur " + stringValue + " n'est pas un bool");
            }

            return new BooleanParameter(id, caption, value);
        }

        #endregion
    }
}
