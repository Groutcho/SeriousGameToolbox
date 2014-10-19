using System;

namespace SeriousGameToolbox.Pedagogy.Sessions
{
    public class Score
    {
        public enum ScorePercentageFormatting { Integer, Float, Default }

        private int raw;
        private int max;
        private int min;
        private float scaled;

        public int Raw { get { return raw; } set { raw = value; } }
        public int Min { get { return min; } set { min = value; } }
        public int Max { get { return max; } set { max = value; } }

        public Score(int raw, int min, int max)
        {
            if (raw > max)
            {
                throw new ArgumentOutOfRangeException("The raw score cannot be greater than the maximum score.");
            }
            if (raw < min)
            {
                throw new ArgumentOutOfRangeException("The raw score cannot be greater than the maximum score.");
            }

            this.raw = raw;
            this.max = max;
            this.min = min;

            this.scaled = (float)raw / (float)(max - min);
        }

        public string ToPercent()
        {
            return ToPercent(ScorePercentageFormatting.Default);
        }

        public string ToPercent(ScorePercentageFormatting format)
        {
            double percent = scaled * 100;

            switch (format)
            {
                case ScorePercentageFormatting.Integer: return string.Format("{0:F0}%", percent);
                case ScorePercentageFormatting.Float: return string.Format("{0:F}%", percent);
                default: return string.Format("{0:F0}%", percent);
            }
        }

        private readonly static Score defaultScore = new Score(0, 0, 0);
        public static Score Default
        {
            get { return defaultScore; }
        }
    }
}
