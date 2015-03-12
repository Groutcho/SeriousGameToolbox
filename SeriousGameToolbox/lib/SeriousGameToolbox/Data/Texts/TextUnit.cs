using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SeriousGameToolbox.Data.Texts
{
    public class TextUnit
    {
        string key;

        public string Key { get { return key; } }

        IDictionary<CultureInfo, string> texts;
        string defaultValue;

        public TextUnit(string key, IDictionary<CultureInfo, string> texts)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null nor empty.");
            }

            if (texts == null)
            {
                throw new ArgumentNullException("texts");
            }

            if (texts.Count == 0)
            {
                throw new ArgumentException("The text dictionary cannot be empty");
            }

            this.key = key;
            this.texts = texts;
            defaultValue = texts.Values.First();
        }

        public static implicit operator string(TextUnit text)
        {
            return text.defaultValue;
        }

        public override string ToString()
        {
            return defaultValue;
        }

        public string ToString(CultureInfo culture)
        {
            if (!texts.ContainsKey(culture))
            {
                throw new KeyNotFoundException(string.Format("The culture {0} is not available for this text ({1})", culture.EnglishName, key));
            }

            return texts[culture];
        }

        public bool IsCultureSupported(CultureInfo culture)
        {
            return texts.ContainsKey(culture);
        }
    }
}
