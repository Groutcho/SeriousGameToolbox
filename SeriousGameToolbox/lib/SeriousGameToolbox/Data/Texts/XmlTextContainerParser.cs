using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SeriousGameToolbox.Data.Texts
{
    public class XmlTextContainerParser : ITextContainerParser
    {
        XElement root;
        List<CultureInfo> supportedCultures;
        Dictionary<string, TextUnit> texts;

        public TextContainer Parse(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentException("The content to deserialize cannot be null nor empty.");
            }

            XDocument doc = XDocument.Parse(content);
            root = doc.Root;

            supportedCultures = ParseSupportedCultures(root.Element("supported_cultures"));
            texts = ParseTexts(root.Element("texts"));

            var result = new TextContainer(supportedCultures, texts);

            var nameAttr = root.Attribute("name");

            if (nameAttr != null)
            {
                result.Name = nameAttr.Value;
            }
            else
            {
                result.Name = string.Empty;
            }

            return result;
        }

        private Dictionary<string, TextUnit> ParseTexts(XElement textNode)
        {
            if (textNode == null)
            {
                throw new ArgumentNullException("textNode");
            }

            var textNodes = textNode.Elements("text");
            Dictionary<string, TextUnit> result = new Dictionary<string, TextUnit>(textNodes.Count());

            foreach (var item in textNodes)
            {
                TextUnit text = ParseSingleTextUnit(item);
                result[text.Key] = text;
            }

            return result;
        }

        private TextUnit ParseSingleTextUnit(XElement textNode)
        {
            if (textNode == null)
            {
                throw new ArgumentNullException("textNode");
            }

            //<text key="text 1">
            //    <culture name="invariant" uses="en"/>
            //    <culture name="en">This is text 1</culture>
            //    <culture name="fr">Ceci est texte 1</culture>
            //</text>

            string key = textNode.Attribute("key").Value;

            var valueNodes = textNode.Elements("culture");

            Dictionary<string, string> substitutes = new Dictionary<string, string>(2);

            Dictionary<CultureInfo, string> values = new Dictionary<CultureInfo, string>(valueNodes.Count());

            foreach (var item in valueNodes)
            {
                string name = item.Attribute("name").Value;
                var uses = item.Attribute("uses");

                if (uses != null)
                {
                    substitutes[name] = uses.Value;
                }
                else
                {
                    values[CultureInfo.GetCultureInfo(name)] = item.Value;
                }
            }

            foreach (var item in substitutes)
            {
                string cultureName = item.Value;
                CultureInfo culture = cultureName == "invariant" ? CultureInfo.InvariantCulture : CultureInfo.GetCultureInfo(cultureName);
                string valueToSubsitute = values[culture];

                string substitutedCultureName = item.Key;
                CultureInfo substitutedCulture = substitutedCultureName == "invariant" ? CultureInfo.InvariantCulture : CultureInfo.GetCultureInfo(substitutedCultureName);

                values[substitutedCulture] = valueToSubsitute;
            }

            return new TextUnit(key, values);
        }

        private List<CultureInfo> ParseSupportedCultures(XElement cultureNode)
        {
            if (cultureNode == null)
            {
                throw new ArgumentNullException("cultureNode");
            }

            var cultureNodes = cultureNode.Elements("culture");

            var result = new List<CultureInfo>(cultureNodes.Count());

            foreach (var item in cultureNodes)
            {
                string cultureName = item.Value;
                CultureInfo culture = cultureName == "invariant" ? CultureInfo.InvariantCulture : CultureInfo.GetCultureInfo(cultureName);

                result.Add(culture);
            }

            return result;
        }
    }
}
