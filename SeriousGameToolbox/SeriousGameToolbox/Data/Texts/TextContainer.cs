using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Texts
{
    public class TextContainer
    {
        IDictionary<string, TextUnit> texts;
        IEnumerable<CultureInfo> supportedCultures;
        CultureInfo currentCulture;
        string name = string.Empty;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != null)
                {
                    name = value;
                }
                else
                {
                    name = string.Empty;
                }
            }
        }

        public CultureInfo CurrentCulture { get { return currentCulture; } }

        static ITextContainerParser defaultSerializer = new XmlTextContainerSerializer();
        public static ITextContainerParser Serializer { get; set; }

        public static TextContainer Load(string filename)
        {
            if (filename == null)
            {
                throw new ArgumentNullException("filename");
            }

            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("The text container file could not be found", filename);
            }

            string content = string.Empty;
            using (StreamReader r = new StreamReader(filename))
            {
                content = r.ReadToEnd();
            }

            return LoadFromContent(content);
        }

        public static TextContainer LoadFromContent(string content)
        {
            ITextContainerParser serializerToUse = Serializer ?? defaultSerializer;
            return serializerToUse.Parse(content);
        }

        public TextContainer()
        {
            texts = new Dictionary<string, TextUnit>(20);
            supportedCultures = new List<CultureInfo>(4);
        }

        public TextContainer(IEnumerable<CultureInfo> supportedCultures, IDictionary<string, TextUnit> texts)
        {
            if (supportedCultures == null)
            {
                throw new ArgumentNullException("supportedCultures");
            }
            if (texts == null)
            {
                throw new ArgumentNullException("texts");
            }

            this.supportedCultures = supportedCultures;
            this.texts = texts;
        }

        public void SetCulture(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

            if (!supportedCultures.Any(c => c.LCID == culture.LCID))
            {
                throw new KeyNotFoundException("The culture " + culture.EnglishName + " is not supported by this container.");
            }

            currentCulture = culture;
        }

        public string GetText(string key)
        {
            if (!texts.ContainsKey(key))
            {
                throw new KeyNotFoundException("the key " + key + " could not be found in the text container " + name);
            }

            return texts[key].ToString(currentCulture);
        }
    }
}
